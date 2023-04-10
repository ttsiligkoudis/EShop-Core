
using DataModels.Dtos;
using Enums;

namespace ViewModels.helpers
{
    public class ProductsFilterHelper
    {
        public PageSize pageSize { get; set; }
        public short pageNumber { get; set; }
        public string? keyWord { get; set; }
        public OrderBy orderBy { get; set; }
        public OrderType orderType { get; set; }
        public List<ProductDto> products { get; set; } = new();
    }
}
