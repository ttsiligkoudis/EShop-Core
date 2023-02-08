using DataModels.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
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