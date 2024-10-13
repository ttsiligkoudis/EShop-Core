using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Client;
using DataModels.Dtos;
using Enums;
using EShop.Helpers;
using FilesClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ViewModels;
using ViewModels.helpers;

namespace EShop.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(
            IHttpContextAccessor accessor, 
            IConfiguration configuration, 
            IClient client, 
            FilesClientHandler filesClient) : base(accessor, configuration, client, filesClient)
        {
        }

        public async Task<IActionResult> AdminIndex(Category? category = null)
        {
            var str = "Products" + (category.HasValue ? "/?category=" + category.Value.ToString() : "");
            var products = await _client.GetAsync<List<ProductDto>>(str);
            return View(products);
        }

        public async Task<IActionResult> Index(short id)
        {
            var str = "Products";
            if (Enum.TryParse<Category>(id.ToString(), out var category))
                str += "/?category=" + category.ToString();
            var products = await _client.GetAsync<List<ProductDto>>(str);
            return View(products);
        }

        public IActionResult Create()
        {
            var product = new ProductDto();
            return View("ProductForm", product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _client.GetAsync<ProductDto>("Products/" + id);
            if (product == null) return RedirectToAction("AdminIndex", "Products");

            return View("ProductForm", product);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _client.GetAsync<ProductDto>("Products/" + id);
            if (product == null) return RedirectToAction("Index", "Products");
            var vm = new ProductViewModel
            {
                Product = product,
                Rates = (await _client.GetAsync<List<ProductRatesDto>>("Products/Rates/" + id) ?? new List<ProductRatesDto>()).ToList()
            };

            ViewBag.ProductExistsInCart = CartProducts?.Any(w => w.Id == id) ?? false;

            return View("Details", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto product, IFormFile Image)
        {
            
            if (Image != null)
            {
                using var stream = Image.OpenReadStream();
                var key = (product.Image?.Contains("fileservice") ?? false) ? product.Image : null;
                var uploadResult = await FilesClient.UploadFileAsync(stream, Image.FileName, Image.ContentType, true, key);
                if (uploadResult.Item1)
                {
                    product.Image = uploadResult.Item2;
                }
                //var gDrive = new GoogleDrive();
                //product.Image = await gDrive.UploadFile(Image, product.Category);
            }

            if (product.Id == 0)
                await _client.PostAsync(product, "Products");
            else
                await _client.PutAsync(product, "Products/" + product.Id);

            return RedirectToAction("AdminIndex");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _client.GetAsync<ProductDto>("Products/" + id);
            if (product != null)
            {
                var orderProducts = await _client.GetAsync<List<OrderProductsDto>>("Orders/Products/" + id);
                if (orderProducts != null && orderProducts.Any())
                {
                    ModelState.AddModelError("", @"Cannot delete a product that is already ordered");
                    return View("AdminIndex", await _client.GetAsync<List<ProductDto>>("Products"));
                }
                await _client.DeleteAsync($"Products/{id}");
            }
            return RedirectToAction("AdminIndex");
        }

        public async Task<List<ProductDto>> AddToCart(bool add, int quantity, int id)
        {
            if (id == 0)
                return null;

            ProductDto product = null;
            var cartExists = CartProducts?.Any() ?? false;

            if (cartExists)
                product = CartProducts.Where(w => w.Id == id).FirstOrDefault();

            var productExistsInCart = product != null;

            product ??= await _client.GetAsync<ProductDto>("Products/" + id);

            if (product == null)
                return null;

            product.Quantity = quantity;

            if (add)
            {
                if (cartExists && !productExistsInCart)
                {
                    CartProducts.Add(product);
                }
                else if (!cartExists)
                {
                    CartProducts = new List<ProductDto>()
                    {
                        product
                    };
                }
            }
            else
            {
                if (cartExists && productExistsInCart)
                {
                    CartProducts.Remove(product);
                }
            }

            SetProducts(CartProducts);
            return CartProducts;
        }

        public async Task<IActionResult> GetRate(int productId, int customerId)
        {
            if (productId == 0 || customerId == 0)
            {
                return null;
            }

            var rate = await _client.GetAsync<ProductRatesDto>($"Products/Rate/?productId={productId}&customerId={customerId}");

            return new JsonResult(rate);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRate(ProductRatesDto rateDto)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            if (rateDto.Id == 0)
            {
                rateDto = await _client.PostAsync(rateDto, "Products/Rate");
            }
            else
            {
                await _client.PutAsync(rateDto, $"Products/Rate/{rateDto.Id}");
            }

            return new JsonResult(rateDto);
        }

        [HttpPost]
        public ContentResult Filter(ProductsFilterHelper helper)
        {
            List<ProductDto> results = helper.products;
            helper.pageNumber = (short)(helper.pageNumber > 0 ? helper.pageNumber - 1 : 0);
            var skip = helper.pageNumber * (short)helper.pageSize;
            var take = (int)helper.pageSize;
            Func<ProductDto, bool> wherePredicate = null;

            Func<ProductDto, object> orderPredicate = o => helper.orderBy switch
            {
                OrderBy.Price => o.Price,
                OrderBy.Quantity => o.Quantity,
                OrderBy.Rate => o.Rate,
                _ => o.Name
            };

            if (!string.IsNullOrEmpty(helper.keyWord))
            {
                var search = helper.keyWord.Trim();
                wherePredicate = w => w.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) != -1
                    //|| w.Description.IndexOf(search, StringComparison.OrdinalIgnoreCase) != -1
                    || (w.Quantity ?? 0).ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) != -1
                    || w.Price.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) != -1
                    || (w.Rate ?? 0).ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) != -1;
            }

            if (wherePredicate != null)
            {
                results = helper.products
                .Where(wherePredicate)
                .ToList();
            }

            if (helper.orderType == OrderType.Descending)
                results = results.OrderByDescending(orderPredicate).ToList();
            else
                results = results.OrderBy(orderPredicate).ToList();


            var vm = new ProductsFullViewModel
            {
                totalCount = helper.products.Count,
                filteredCount = results.Count,
                pages = (results.Count / (short)helper.pageSize) + (results.Count % (short)helper.pageSize > 0 ? 1 : 0),
                products = results.Skip(skip).Take(take).ToList()
            };

            return SerializeJSON(vm);
        }

        public IActionResult CardView(List<ProductDto> products)
        {
            return PartialView("_CardView", products);
        }

        private ContentResult SerializeJSON(object obj)
        {
            var data = JsonConvert.SerializeObject(obj);
            var result = new ContentResult
            {
                Content = data,
                ContentType = "application/json"
            };
            return result;
        }
    }
}