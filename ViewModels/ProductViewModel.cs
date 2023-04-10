using DataModels.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class ProductViewModel
    {
        public ProductDto Product { get; set; }
        public List<ProductRatesDto> Rates { get; set; }
    }
}