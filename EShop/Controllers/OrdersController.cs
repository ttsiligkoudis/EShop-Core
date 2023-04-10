using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Client;
using DataModels;
using DataModels.Dtos;
using Enums;
using EShop.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using ViewModels;
using ISession = EShop.Helpers.ISession;

namespace EShop.Controllers
{
    public class OrdersController : BaseController
    {
        public OrdersController(IUserAccess userAccess, ISession session, IMapper mapper) : base(userAccess, session, mapper)
        {
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
                viewModel.Order.CustomerName = customer.Name;
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Save(OrderViewModel viewModel)
        {
            if (viewModel.ProductList.Length == 0)
            {
                ModelState.AddModelError("", @"You need to select at least one Product");
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
                viewModel.Order.OrderDate = DateTime.Now;
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
                    Price = product.Price,
                    ProductName = product.Name
                });
            }
            viewModel.OrderProducts = await _client.OrderProductClient.PostListAsync(viewModel.OrderProducts, "Orders/" + viewModel.Order.Id + "/Products") as List<OrderProductsDto>;
            viewModel.Order = await _client.OrderClient.PutAsync(viewModel.Order, "Orders/" + viewModel.Order.Id);
            return RedirectToAction("Edit", new RouteValueDictionary(
                new { controller = "Orders", action = "Edit", viewModel.Order.Id }));
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

        public  IActionResult Cart()
        {
            var cartProducts = _session.GetProducts();

            if (cartProducts != null && cartProducts.Any())
                ViewBag.FinalPrice = cartProducts.Sum(s => s.Price * s.Quantity);

            var vm = new FinalOrderViewModel()
            {
                CartProducts = cartProducts
            };
            var customer = _session.GetCustomer();
            ViewBag.NewCustomer = customer == null;
            customer ??= new Customer();
            vm.RegisterVM.Customer = _mapper.Map<CustomerDto>(customer);
            vm.RegisterVM.Email = vm.RegisterVM.Customer.Email;
            vm.RegisterVM.Password = customer.User?.Password ?? "123456";
            vm.RegisterVM.ConfirmPassword = customer.User?.Password ?? "123456";

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> FinaliseOrder(FinalOrderViewModel vm)
        {
            if (!ModelState.IsValid || vm.CartProducts.Count == 0)
            {
                var errors = new List<string>();

                foreach (var value in ModelState.Values.Where(w => w.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid))
                    errors.AddRange(value.Errors.Select(s => s.ErrorMessage).ToList());

                if (vm.CartProducts.Count == 0)
                    errors.Add("There is no Product in cart");

                if (errors.Any())
                    ModelState.AddModelError("", string.Join(", ", errors.ToArray()));

                return View("Cart", vm);
            }

            if (vm.RegisterVM.Customer.Id == 0)
            {
                if (vm.CreateAccount)
                {
                    var user = await _client.UserClient.GetAsync("Users/GetUserByEmail/?email=" + vm.RegisterVM.Email);
                    if (user != null)
                    {
                        ModelState.AddModelError("", @"Email already exists");
                        return View("Cart", vm);
                    }
                    user = new UserDto
                    {
                        Email = vm.RegisterVM.Email,
                        Password = vm.RegisterVM.Password,
                        RegDate = DateTime.Now,
                        LoginDate = DateTime.Now,
                        UserType = UserType.User
                    };
                    user = await _client.UserClient.PostAsync(user, "Users");
                    vm.RegisterVM.Customer.UserId = user.Id;

                    vm.RegisterVM.Customer = await _client.CustomerClient.PostAsync(vm.RegisterVM.Customer, "Customers");

                    var customer = _mapper.Map<Customer>(vm.RegisterVM.Customer);
                    customer.User = _mapper.Map<User>(user);
                    HttpContext.Session.SetString("Customer", JsonConvert.SerializeObject(_mapper.Map<Customer>(customer)));
                }
                else
                {
                    vm.RegisterVM.Customer = await _client.CustomerClient.PostAsync(vm.RegisterVM.Customer, "Customers");
                }
            }

            vm.CartProducts = await _client.ProductClient.PutListAsync(vm.CartProducts, "Products");

            var orderDto = new OrderDto
            {
                CustomerName = vm.RegisterVM.Customer.Name,
                CustomerId = vm.RegisterVM.Customer.Id,
                FinalPrice = vm.CartProducts.Select(s => s.Price * s.Quantity ?? 0).Sum(),
                OrderDate = DateTime.Now,
                Completed = true
            };

            orderDto = await _client.OrderClient.PostAsync(orderDto, "Orders");
            orderDto.Customer = vm.RegisterVM.Customer;

            var orderProductsDto = vm.CartProducts
                .Select(s => new OrderProductsDto
                {
                    OrderId = orderDto.Id,
                    ProductName = s.Name,
                    Quantity = s.Quantity,
                    ProductId = s.Id,
                    Price = s.Price
                })
                .ToList();

            orderProductsDto = (await _client.OrderProductClient.PostListAsync(orderProductsDto, "Orders/" + orderDto.Id + "/Products")).ToList();
            HttpContext.Session.SetString("Products", string.Empty);

            return new JsonResult(orderDto.Id);
        }
    }
}