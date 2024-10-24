using Hw_week7.Data;
using Hw_week7.Enum;

namespace Hw_week7.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryEnum Category { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public int Count { get; set; }



        public Product()
        {
            Id = GetId();
        }
        public Product(string name, string description, CategoryEnum category, int price, string color, int quantity)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Color = color;
            Quantity = quantity;
            Id = GetId();
        }

        public int GetId()
        {
            int count = 0;
            foreach (Product p in Storage.Products)
            {
                count++;
            }
            return count;
        }


    }
}
