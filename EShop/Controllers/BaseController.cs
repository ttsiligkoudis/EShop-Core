using Client;
using DataModels.Dtos;
using Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using static Newtonsoft.Json.JsonConvert;

namespace EShop.Controllers
{
    public class BaseController : Controller
    {
        protected ClientHelper _client;
        protected CustomerDto Customer { get; set; }
        protected new UserDto User { get; set; }
        protected bool IsAdmin { get; set; }
        protected bool IsCustomer { get; set; }
        protected List<ProductDto> CartProducts { get; set; }
        protected new HttpContext HttpContext { get; set; }

        public BaseController(IHttpContextAccessor accessor)
        {
            _client = new ClientHelper();
            HttpContext = accessor.HttpContext;

            User = GetUser();
            Customer = GetCustomer();
            IsAdmin = CheckUserType(UserType.Admin);
            IsCustomer = CheckUserType(UserType.User);
            CartProducts = GetProducts();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            ViewBag.Customer = Customer;
            ViewBag.User = User;
            ViewBag.IsAdmin = IsAdmin;
            ViewBag.IsCustomer = IsCustomer;
            ViewBag.CartProducts = CartProducts;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _client != null)
            {
                _client.Dispose();
                _client = null;
            }
        }

        public CustomerDto GetCustomer()
        {
            var objectStr = HttpContext.Session.GetString("Customer");

            return !string.IsNullOrEmpty(objectStr) ? DeserializeObject<CustomerDto>(objectStr) : null;
        }

        public void SetCustomer(CustomerDto obj)
        {
            HttpContext.Session.SetString("Customer", SerializeObject(obj));
            HttpContext.Items.Remove("Customer");
            HttpContext.Items.Add("Customer", obj);
        }

        public UserDto GetUser()
        {
            var objectStr = HttpContext.Session.GetString("User");

            return !string.IsNullOrEmpty(objectStr) ? DeserializeObject<UserDto>(objectStr) : null;
        }

        public void SetUser(UserDto obj)
        {
            HttpContext.Session.SetString("User", SerializeObject(obj));
            HttpContext.Items.Remove("User");
            HttpContext.Items.Add("User", obj);
        }

        public List<ProductDto> GetProducts()
        {
            var objectStr = HttpContext.Session.GetString("Products");

            return !string.IsNullOrEmpty(objectStr) ? DeserializeObject<List<ProductDto>>(objectStr) : null;
        }

        public void SetProducts(List<ProductDto> obj)
        {
            HttpContext.Session.SetString("Products", SerializeObject(obj));
            HttpContext.Items.Remove("Products");
            HttpContext.Items.Add("Products", obj);
        }

        public bool CheckUserType(UserType type)
        {
            return User?.UserType == type;
        }
    }
}
