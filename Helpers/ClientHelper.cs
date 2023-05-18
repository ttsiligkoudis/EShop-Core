using DataModels.Dtos;

namespace Client
{
    public class ClientHelper
    {
        public Client<CustomerDto> CustomerClient { get; set; }
        public Client<OrderDto> OrderClient { get; set; }
        public Client<ProductDto> ProductClient { get; set; }
        public Client<UserDto> UserClient { get; set; }
        public Client<OrderProductsDto> OrderProductClient { get; set; }
        public Client<ProductRatesDto> ProductRatesClient { get; set; }
        public Client<MessageDto> MessagesClient { get; set; }

        public ClientHelper()
        {
            CustomerClient = new Client<CustomerDto>();
            OrderClient = new Client<OrderDto>();
            ProductClient = new Client<ProductDto>();
            UserClient = new Client<UserDto>();
            OrderProductClient = new Client<OrderProductsDto>();
            ProductRatesClient = new Client<ProductRatesDto>();
            MessagesClient = new Client<MessageDto>();
        }

        public void Dispose()
        {
            CustomerClient.Dispose();
            OrderClient.Dispose();
            ProductClient.Dispose();
            UserClient.Dispose();
            OrderProductClient.Dispose();
            ProductRatesClient.Dispose();
            MessagesClient.Dispose();
        }
    }
}