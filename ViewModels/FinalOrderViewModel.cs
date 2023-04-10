using DataModels.Dtos;

namespace ViewModels
{
    public class FinalOrderViewModel
    {
        public List<ProductDto> CartProducts { get; set; } = new List<ProductDto>();
        public RegisterViewModel RegisterVM { get; set; } = new RegisterViewModel();
        public bool CreateAccount { get; set; }
    }
}
