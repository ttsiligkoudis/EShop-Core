
using DataModels.Dtos;

namespace ViewModels
{
    public class ProductsFullViewModel
    {
        public List<ProductDto> products { get; set; }
        public int totalCount { get; set; }
        public int filteredCount { get; set; }
        public int pages { get; set; }
    }
}
