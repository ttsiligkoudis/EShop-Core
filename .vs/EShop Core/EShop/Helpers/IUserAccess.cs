using EShop.Models;

namespace EShop.Helpers
{
    public interface IUserAccess
    {
        bool IsAdmin(Customer customer);
        bool IsCustomer(Customer customer);
    }
}
