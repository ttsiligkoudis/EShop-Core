using EShop.Models;

namespace EShop.Helpers
{
    public interface ISession
    {
        Customer GetCustomer();
    }
}
