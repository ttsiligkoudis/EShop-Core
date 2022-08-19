using System.Collections.Generic;
using System.Threading.Tasks;
using EShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Repositories.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts(bool checkQuantity);
        Task<Product> GetProduct(int id);
        Task<Product> Put(Product product);
        Task<Product> Post(Product product);
        Task<ActionResult> Delete(int id);
    }
}