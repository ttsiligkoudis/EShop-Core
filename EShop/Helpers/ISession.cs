using DataModels;
using DataModels.Dtos;
using System.Collections.Generic;

namespace EShop.Helpers
{
    public interface ISession
    {
        Customer GetCustomer();
        List<ProductDto> GetProducts();
    }
}
