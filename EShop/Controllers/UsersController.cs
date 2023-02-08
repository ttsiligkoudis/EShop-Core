using System;
using System.Threading.Tasks;
using AutoMapper;
using Client;
using DataModels;
using DataModels.Dtos;
using Enums;
using EShop.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ViewModels;
using ISession = EShop.Helpers.ISession;

namespace EShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserAccess _userAccess;
        private readonly ISession _session;
        private readonly IMapper _mapper;
        private ClientHelper _client;

        public UsersController(IUserAccess userAccess, ISession session, IMapper mapper)
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
            var customer = _session.GetCustomer();
            if (!_userAccess.IsAdmin(customer))
            {
                return RedirectToAction("Index", "Home");
            }

            var users = await _client.UserClient.GetListAsync("Users");
            return View(users);
        }

        public IActionResult Register()
        {
            return View("Register", new RegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> RegisterViewResult(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("Register", viewModel);
            var user = await _client.UserClient.GetAsync("Users/GetUserByEmail/?email=" + viewModel.Email);
            if (user != null)
            {
                ModelState.AddModelError("", @"Email already exists");
                return View("Register", viewModel);
            }
            var userViewModel = new UserViewModel
            {
                User =
                {
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    RegDate = DateTime.Now,
                    UserType = UserType.User
                }
            };
            userViewModel.User = await _client.UserClient.PostAsync(userViewModel.User, "Users");
            _mapper.Map(userViewModel.User, viewModel.Customer);
            viewModel.Customer = await _client.CustomerClient.PostAsync(viewModel.Customer, "Customers");
            return RedirectToAction("LoginViewResult", userViewModel.User);
        }
        public IActionResult Login()
        {
            return View("Login");
        }
        public async Task<IActionResult> LoginViewResult(UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", user);
            }

            var userInDb =
                await _client.UserClient.GetAsync("Users/GetUserByEmailAndPassword/?email=" + user.Email + "&password=" + user.Password);
            if (userInDb == null)
            {
                ModelState.AddModelError("", @"Invalid email or password");
                return View("Login", user);
            }

            var customerDto = await _client.CustomerClient.GetAsync("Customers/User/" + userInDb.Id);
            if (customerDto != null)
            {
                var customer = _mapper.Map<Customer>(customerDto);
                customer.User = _mapper.Map<User>(userInDb);
                HttpContext.Session.SetString("Customer", JsonConvert.SerializeObject(_mapper.Map<Customer>(customer)));
            }
            userInDb.LoginDate = DateTime.Now;
            await _client.UserClient.PutAsync(userInDb, "Users/" + userInDb.Id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("Customer", string.Empty);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = new UserViewModel
            {
                User = await _client.UserClient.GetAsync("Users/" + id),
                Customer = await _client.CustomerClient.GetAsync("Customers/User/" + id)
            };
            return viewModel.User == null || viewModel.Customer == null
                ? (ActionResult)RedirectToAction("Index", "Home")
                : View("Details", viewModel);
        }

        public async Task<IActionResult> ConvertToAdmin(int id)
        {
            var user = await _client.UserClient.GetAsync("Users/" + id);
            if (user != null)
            {
                user.UserType = UserType.Admin;
                await _client.UserClient.PutAsync(user, "Users/" + user.Id);
            }
            return RedirectToAction("Index", "Users");
        }
    }
}