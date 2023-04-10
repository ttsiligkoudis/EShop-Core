using DataModels;
using DataModels.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using static Newtonsoft.Json.JsonConvert;

namespace EShop.Helpers
{
    public class Session : ISession
    {
        public IHttpContextAccessor HttpContextAccessor;

        public Session(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public Customer GetCustomer()
        {
            var customerStr = HttpContextAccessor.HttpContext.Session.GetString("Customer");

            return !string.IsNullOrEmpty(customerStr) ? DeserializeObject<Customer>(customerStr) : null;
        }

        public List<ProductDto> GetProducts()
        {
            var productsStr = HttpContextAccessor.HttpContext.Session.GetString("Products");

            return !string.IsNullOrEmpty(productsStr) ? DeserializeObject<List<ProductDto>>(productsStr) : null;
        }
    }
}
