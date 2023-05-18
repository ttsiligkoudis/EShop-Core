using System;
using System.Threading.Tasks;
using DataModels.Dtos;
using Enums;
using Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using Microsoft.AspNetCore.Authentication.Google;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace EShop.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(IHttpContextAccessor accessor) : base(accessor)
        {
        }

        public async Task<IActionResult> Index()
        {
            if (!IsAdmin)
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

            user = new UserDto
            {
                Email = viewModel.Email,
                Password = viewModel.Password,
                RegDate = DateTime.Now,
                UserType = UserType.User
            };

            user = await _client.UserClient.PostAsync(user, "Users");
            user.Password = viewModel.Password;

            viewModel.Customer.UserId = user.Id;
            viewModel.Customer.RegDate = user.RegDate;
            viewModel.Customer.Email = user.Email;
            viewModel.Customer = await _client.CustomerClient.PostAsync(viewModel.Customer, "Customers");

            var message = new MessageDto
            {
                Email = user.Email,
                Subject = "New User Created",
                Body = EmailHelper.NewUserCreatedHtml(viewModel.Customer, user, "New User Created")
            };

            await _client.MessagesClient.PostAsync(message, $"Messages/SendMessage");

            return RedirectToAction("LoginViewResult", user);
        }
        public IActionResult Login()
        {
            if (User != null)
                return RedirectToAction("Index", "Home");

            return View("Login");
        }
        public async Task<IActionResult> LoginViewResult(UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", user);
            }

            var userInDb = await _client.UserClient.GetAsync("Users/GetUserByEmailAndPassword/?email=" + user.Email + "&password=" + user.Password);
            if (userInDb == null)
            {
                ModelState.AddModelError("", @"Invalid email or password");
                return View("Login", user);
            }

            userInDb.LoginDate = DateTime.Now;
            var customer = await _client.CustomerClient.GetAsync("Customers/User/" + userInDb.Id);
            if (customer != null)
            {
                SetCustomer(customer);
                SetUser(userInDb);
            }
            await _client.UserClient.PutAsync(userInDb, "Users/" + userInDb.Id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            SetCustomer(null);
            SetUser(null);
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

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _client.UserClient.GetAsync("Users/GetUserByEmail/?email=" + email);
            if (user == null)
            {
                ModelState.AddModelError("", @"Email does not exist");
                return View("ForgotPassword", email);
            }

            var token = Guid.NewGuid().ToString();
            user.PasswordResetToken = token;
            await _client.UserClient.PutAsync(user, "Users/" + user.Id);

            var message = new MessageDto
            {
                Email = user.Email,
                Subject = "Password Reset",
                Body = EmailHelper.PasswordResetHtml(user, "Password Reset")
            };

            await _client.MessagesClient.PostAsync(message, $"Messages/SendMessage");
            ViewBag.MessageSent = "An email was sent successfully, please follow the email instructions to reset your password.";

            return View();
        }

        public async Task<IActionResult> ResetPassword(int userID, string token)
        {
            var user = await _client.UserClient.GetAsync("Users/" + userID);

            if (user == null || user.PasswordResetToken != token)
            {
                ModelState.AddModelError("", @"The link is not valid please fill your email to try again");
                return View("ForgotPassword");
            }

            var vm = new ResetPasswordViewModel
            {
                Email = user.Email,
                PasswordResetToken = token
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("ResetPassword", viewModel);

            var user = await _client.UserClient.GetAsync("Users/GetUserByEmail/?email=" + viewModel.Email);

            if (user == null || user.PasswordResetToken != viewModel.PasswordResetToken)
            {
                ModelState.AddModelError("", @"The link is not valid please fill your email to try again");
                return View("ForgotPassword");
            }

            user.Password = viewModel.Password;
            user.PasswordResetToken = null;
            await _client.UserClient.PutAsync(user, "Users/" + user.Id);

            ViewBag.PasswordChangedMessage = "Password changed successfully, please procced with log in";

            return View("Login");
        }

        public async Task LoginWithGoogle(bool isMobile = false)
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = isMobile ? Url.Action(nameof(HandleGoogleLoginMobile)) : Url.Action(nameof(HandleGoogleLogin))
            });
        }

        public async Task<IActionResult> HandleGoogleLogin()
        {
            var authResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (authResult.Succeeded)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var identity = authResult.Principal.Identities.FirstOrDefault();

                (var customer, var user) = await GoogleHelper.GetSSOResponse(identity, accessToken, _client.CustomerClient, _client.UserClient, _client.MessagesClient);

                SetUser(user);
                SetCustomer(customer);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> HandleGoogleLoginMobile()
        {
            var authResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (authResult.Succeeded)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var identity = authResult.Principal.Identities.FirstOrDefault();

                (var customer, var user) = await GoogleHelper.GetSSOResponse(identity, accessToken, _client.CustomerClient, _client.UserClient, _client.MessagesClient);

                return RedirectToAction("Index", "Home", new 
                { 
                    customer = JsonConvert.SerializeObject(customer), 
                    user = JsonConvert.SerializeObject(user)
                });
            }

            return RedirectToAction("Index", "Home");
        }
    }
}