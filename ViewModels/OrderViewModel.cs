using DataModels.Dtos;
using DataModels;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public OrderDto Order { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<OrderProductsDto> OrderProducts { get; set; }
        [Required(ErrorMessage = "Selecting a Product is Required")]
        [Display(Name = "Product")]
        public int[] ProductList { get; set; }

        public OrderViewModel()
        {
            Order = new OrderDto();
            Customers = new List<Customer>();
            OrderProducts = new List<OrderProductsDto>();
        }
    }
}