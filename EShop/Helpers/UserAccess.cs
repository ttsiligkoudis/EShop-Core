using DataModels;
using Enums;

namespace EShop.Helpers
{
    public class UserAccess : IUserAccess
    {
        public bool IsAdmin(Customer customer)
        {
            return customer?.User?.UserType == UserType.Admin;
        }

        public bool IsCustomer(Customer customer)
        {
            return customer != null;
        }
    }
}
