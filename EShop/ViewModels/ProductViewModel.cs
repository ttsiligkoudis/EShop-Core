using EShop.Models;
using System.ComponentModel.DataAnnotations;

namespace EShop.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public float? Price { get; set; }
        public ProductDto Product { get; set; }

        public ProductViewModel()
        {
            Product = new ProductDto();
        }
    }
}