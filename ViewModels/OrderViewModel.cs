using DataModels.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public OrderDto Order { get; set; }
        public List<CustomerDto> Customers { get; set; }
        public List<ProductDto> Products { get; set; }
        public List<OrderProductsDto> OrderProducts { get; set; }
        [Required(ErrorMessage = "Selecting a Product is Required")]
        [Display(Name = "Product")]
        public int[] ProductList { get; set; }

        public OrderViewModel()
        {
            Order = new();
            Customers = new();
            OrderProducts = new();
        }
    }
}