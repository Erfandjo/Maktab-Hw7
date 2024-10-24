using System.Security.Cryptography.X509Certificates;
using Hw_week7.Data;
using Hw_week7.Enum;

namespace Hw_week7.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; private set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public RoleEnum Role { get; set; }
        public ShoppingCart ShoppingCart { get; set; } = new ShoppingCart();
        public ShoppingCartComplate ShoppingCartComplate { get; set; } = new ShoppingCartComplate();


        public Customer(string userName, string fullName, string address , RoleEnum role = RoleEnum.Member)
        {
            UserName = userName;
            FullName = fullName;
            Address = address;
            Role = role;
            Id = GetId();
        }

        public Customer(string userName)
        {
            UserName = userName;
            Id = GetId();
        }

        public int GetId()
        {
            int count = 0;
            foreach (var p in Storage.Customers)
            {
                count++;
            }
            return count;
        }

        public static Customer GetCustomer(string username)
        {
            foreach (var item in Storage.Customers)
            {
                if (item.UserName == username)
                {
                    return item;
                }
            }
            return null;
        }

        public void SetPassword(string password)
        {
            Password = password;

        }


    }
}
