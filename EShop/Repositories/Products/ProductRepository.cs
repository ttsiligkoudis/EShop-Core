using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Repositories.Products
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private ApplicationDbContext _context = ApplicationDbContext.Create();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public async Task<List<Product>> GetProducts(bool checkQuantity)
        {
            var productsInDb = _context.Products;
            if (checkQuantity)
            {
                return await productsInDb.Where(p => p.Quantity > 0).ToListAsync();
            }
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> Put(Product product)
        {
            _context.Products.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Post(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ActionResult> Delete(int id)
        {
            var products = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (products != null)
            {
                _context.Products.Remove(products);
                await _context.SaveChangesAsync();
            }
            return null;
        }
    }
}
