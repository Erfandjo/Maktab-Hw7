using Hw_week7.Contracts;
using Hw_week7.Data;
using Hw_week7.Entities;

namespace Hw_week7.Service
{
    public class Authentication : IAuthentication
    {
        public bool CkeckUserName(string username)
        {
            foreach (var customer in Storage.Customers)
            {
                if (customer.UserName == username)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Login(string username, string password)
        {
            foreach (var customer in Storage.Customers)
            {
                if (customer.UserName == username && customer.Password == password)
                {
                    return true;
                    
                }
            }
            return false;
        }

        public bool Register(string username, string password)
        {
            if (!CkeckUserName(username))
            {
                Customer c = new Customer(username);
                c.SetPassword(password);
                Storage.Customers.Add(c);
                return true;
                
            }
            return false;
        }
    }
}
