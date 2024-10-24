using Hw_week7.Data;
using Hw_week7.Enum;

namespace Hw_week7.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public StatusShappingCardComplateEnum Status { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public int UserId { get; set; }
        public DateTime Date { get; set; } 
        public double TotalPrice { get; set; }

        

        public ShoppingCart()
        {
            Id = GetId();
        }

        public int GetId()
        {
            int count = 0;
            
                foreach (var p in Storage.ShoppingCartsComplateAllUser)
                {
                    count++;
                }
            
                return count;
        }
        
    }
}
