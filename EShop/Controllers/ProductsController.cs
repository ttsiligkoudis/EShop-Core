using System.Linq;
using System.Threading.Tasks;
using Client;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace EShop.Controllers
{
    public class ProductsController : Controller
    {
        private ClientHelper _client;

        public ProductsController()
        {
            _client = new ClientHelper();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_client != null)
                {
                    _client.Dispose();
                    _client = null;
                }
            }
        }

        public async Task<IActionResult> Index()
        {
            var products = await _client.ProductClient.GetListAsync("Products");
            return View(products);
        }

        public IActionResult Create()
        {
            var viewModel = new ProductViewModel();
            return View("ProductForm", viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _client.ProductClient.GetAsync("Products/" + id);
            if (product == null) return RedirectToAction("Index", "Products");

            var viewModel = new ProductViewModel
            {
                Product = product,
                Price = product.Price
            };
            return View("ProductForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductViewModel viewModel)
        {
            if (viewModel.Price != null) viewModel.Product.Price = (float)viewModel.Price;
            if (!ModelState.IsValid) return View("ProductForm", viewModel);
            if (viewModel.Product.Id == 0)
            {
                viewModel.Product = await _client.ProductClient.PostAsync(viewModel.Product, "Products");
            }
            else
            {
                viewModel.Product = await _client.ProductClient.PutAsync(viewModel.Product, "Products/" + viewModel.Product.Id);
            }
            return RedirectToAction("Index", "Products");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _client.ProductClient.GetAsync("Products/" + id);
            if (product != null)
            {
                var orderProducts = await _client.OrderProductClient.GetListAsync("Orders/Products/" + id);
                if (orderProducts != null && orderProducts.Any())
                {
                    ModelState.AddModelError("", @"Cannot delete a product that is already ordered");
                    return View("Index", await _client.ProductClient.GetListAsync("Products"));
                }
                await _client.ProductClient.DeleteAsync(id, "Products/" + id);
            }
            return RedirectToAction("Index");
        }
    }
}