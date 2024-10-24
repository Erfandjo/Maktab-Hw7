using Hw_week7.Entities;
using Hw_week7.Enum;

namespace Hw_week7.Data
{
    public static class Storage
    {
        public static Customer onlineUser { get; set; }
        public static List<Customer> Customers { get; set; } = new List<Customer>();
        public static List<Product> Products { get; set; } = new List<Product>();
        public static List<ShoppingCart> ShoppingCartsComplateAllUser { get; set; } = new List<ShoppingCart>();
        //  public static List<ShoppingCart> Factor { get; set; } = new List<ShoppingCart>();

        static Storage()
        {
            Products.Add(new Product("Iphone 16", "acndnajvfs", CategoryEnum.Digital, 20000, "Black", 100));
            Products.Add(new Product("Iphone 11", "acndnajvfs", CategoryEnum.Digital, 20000, "Black", 30));
            Products.Add(new Product("Tv", "acndnajvfs", CategoryEnum.Digital, 20000, "Black", 40));
            Products.Add(new Product("Ball", "acndnajvfs", CategoryEnum.Sports, 20000, "Black", 40));
            Products.Add(new Product("Gas", "acndnajvfs", CategoryEnum.HomeAppliances, 20000, "Black", 40));

            Customer c1 = new Customer("erfan", "Erfan Joharzadeh", "tehran" , RoleEnum.Admin);
            c1.SetPassword("12345");
            Customers.Add(c1);

            Customer c2 = new Customer("hassan", "Erfan Joharzadeh", "esfehan");
            c2.SetPassword("12345");
            Customers.Add(c2);

            Customer c3 = new Customer("farzan", "Farzan Joharzadeh", "behbohan");
            c3.SetPassword("12345");
            Customers.Add(c3);

        }



    }
}
