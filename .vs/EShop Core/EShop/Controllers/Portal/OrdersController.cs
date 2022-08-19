using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EShop.Helpers;
using EShop.Models;
using EShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis;
using ISession = EShop.Helpers.ISession;

namespace EShop.Controllers.Portal
{
    public class OrdersController : Controller
    {
        private readonly IUserAccess _userAccess;
        private readonly ISession _session;
        private readonly IMapper _mapper;
        private ClientHelper _client;

        public OrdersController(IUserAccess userAccess, ISession session, IMapper mapper)
        {
            _userAccess = userAccess;
            _session = session;
            _mapper = mapper;
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
            IEnumerable<OrderDto> orders;
            var customer = _session.GetCustomer();
            if (!_userAccess.IsCustomer(customer))
            {
                return RedirectToAction("Index", "Home");
            }
            if (!_userAccess.IsAdmin(customer))
            {
                orders = await _client.OrderClient.GetListAsync("Orders/Customer/" + customer.Id);
            }
            else
            {
                orders = await _client.OrderClient.GetListAsync("Orders");
            }
            return View(orders);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = new OrderViewModel
            {
                Order = await _client.OrderClient.GetAsync("Orders/" + id),
                OrderProducts = await _client.OrderProductClient.GetListAsync("Orders/" + id + "/Products") as List<OrderProductsDto>
            };
            return View("OrderForm", viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var customers = _mapper.Map<IEnumerable<Customer>>(await _client.CustomerClient.GetListAsync("Customers"));
            var products = _mapper.Map<IEnumerable<Product>>(await _client.ProductClient.GetListAsync("Products/?checkQuantity=true"));
            var viewModel = new OrderViewModel
            {
                Customers = customers.ToList(),
                Products = products.ToList()
            };
            var customer = _session.GetCustomer();
            if (_userAccess.IsCustomer(customer))
            {
                viewModel.Order.Customer = _mapper.Map<CustomerDto>(customer);
                viewModel.Order.CustomerId = customer.Id;
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Save(OrderViewModel viewModel)
        {
            if (!ModelState.IsValid || (viewModel.ProductList.Length == 1 && viewModel.ProductList.Contains(-1)))
            {
                if ((viewModel.ProductList.Length == 1 && viewModel.ProductList.Contains(-1)))
                {
                    ModelState.AddModelError("", @"You need to select at least one Product");
                }
                var customers = _mapper.Map<IEnumerable<Customer>>(await _client.CustomerClient.GetListAsync("Customers"));
                var products = _mapper.Map<IEnumerable<Product>>(await _client.ProductClient.GetListAsync("Products/?checkQuantity=true"));
                viewModel.Customers = customers.ToList();
                viewModel.Products = products.ToList();
                return View("Create", viewModel);
            }

            if (viewModel.Order.CustomerId == 0)
            {
                viewModel.Order.Customer = await _client.CustomerClient.PostAsync(viewModel.Order.Customer, "Customers");
                viewModel.Order.CustomerId = viewModel.Order.Customer.Id;
            }

            if (viewModel.Order.Id == 0)
            {
                viewModel.Order.Customer = null;
                viewModel.Order = await _client.OrderClient.PostAsync(viewModel.Order, "Orders");
            }
            viewModel.Order.Customer = await _client.CustomerClient.GetAsync("Customers/" + viewModel.Order.CustomerId);
            var productsDto = await _client.ProductClient.GetListAsync("Products");
            productsDto = productsDto.Where(p => viewModel.ProductList.Contains(p.Id)).ToList();
            foreach (var product in productsDto)
            {
                viewModel.Order.FinalPrice += product.Price;
                product.Quantity--;
                await _client.ProductClient.PutAsync(product, "Products/" + product.Id);
                viewModel.OrderProducts.Add(new OrderProductsDto()
                {
                    OrderId = viewModel.Order.Id,
                    ProductId = product.Id,
                    ProductPrice = product.Price,
                    ProductName = product.Name,
                    ProductCategory = product.Category
                }); 
            }
            viewModel.OrderProducts =await _client.OrderProductClient.PostListAsync(viewModel.OrderProducts, "Orders/" + viewModel.Order.Id + "/Products") as List<OrderProductsDto>;
            viewModel.Order = await _client.OrderClient.PutAsync(viewModel.Order, "Orders/" + viewModel.Order.Id);
            return RedirectToAction("Edit", new RouteValueDictionary(
                new { controller = "Orders", action = "Edit", Id = viewModel.Order.Id }));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var customer = _session.GetCustomer();
            if (!_userAccess.IsCustomer(customer))
            {
                RedirectToAction("Index", "Home");
            }
            var order = await _client.OrderClient.GetAsync("Orders/" + id);
            if (order == null) return RedirectToAction("Index");
            if (order.Completed && !_userAccess.IsAdmin(customer))
            {
                ModelState.AddModelError("", @"Cannot delete a completed order");
                return View("Index", await _client.OrderClient.GetListAsync("Orders/Customer/" + customer.Id));
            }

            await _client.OrderClient.DeleteAsync(id, "Orders/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CompleteOrder(int id)
        {
            var order = await _client.OrderClient.GetAsync("Orders/" + id);
            if (order != null)
            {
                order.Completed = true;
                await _client.OrderClient.PutAsync(order, "Orders/" + order.Id);
            }
            return RedirectToAction("Index");
        }
    }
}