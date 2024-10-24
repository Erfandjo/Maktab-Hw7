using Hw_week7.Contracts;
using Hw_week7.Data;
using Hw_week7.Entities;
using Hw_week7.Enum;

namespace Hw_week7.Service
{
    public class StoreService : IStoreService
    {
        public void GetProduct(int number)
        {
            foreach (var product in Storage.Products)
            {
                if (product.Category == (CategoryEnum)number)
                {
                    Console.WriteLine($"Id Product : {product.Id} , Name : {product.Name} , Descreption : {product.Description} , Price : {product.Price} , Color : {product.Color} , Quantity : {product.Quantity}");
                }
            }
        }



        public string SelectProduct(int id, int count)
        {

            foreach (var product in Storage.Products)
            {

                if (product.Id == id)
                {
                    if (product.Quantity >= count)
                    {
                        if (CheckShoppingCart(id) == 0)
                        {
                            Entities.Product p = new Entities.Product()
                            {
                                Color = product.Color,
                                Name = product.Name,
                                Count = count,
                                Quantity = product.Quantity,
                                Category = product.Category,
                                Description = product.Description,
                                Id = id,
                                Price = product.Price,
                            };

                            Storage.onlineUser.ShoppingCart.Products.Add(p);


                            product.Count = count;
                            return "Sucsses";
                        }
                        else if (CheckShoppingCart(id) != 0)
                        {

                            foreach (var item in Storage.onlineUser.ShoppingCart.Products)
                            {
                                if (item.Id == id)
                                {
                                    item.Count = item.Count + count;

                                    return "Sucsses";
                                }
                            }
                        }
                    }
                    else
                    {
                        return "mojodi kafi nist";
                    } 
                }
               
            }
            return "Product Not Found";

        }

        public void GetShoppingCart()
        {
            foreach (var product in Storage.onlineUser.ShoppingCart.Products)
            {

                Console.WriteLine($"Id Product : {product.Id} , Name : {product.Name} , Descreption : {product.Description} , Price : {product.Price} , Color : {product.Color} , Count : {product.Count}");

            }
        }

        public int CheckShoppingCart(int ProductId)
        {
            foreach (var product in Storage.onlineUser.ShoppingCart.Products)
            {
                if (product.Id == ProductId)
                {
                    return product.Count;
                }
            }
            return 0;
        }

        public bool ComplateBuy()

        { 
            if (Storage.onlineUser.ShoppingCart.Products != null)
            {
                double price = 0;
                foreach (var item in Storage.onlineUser.ShoppingCart.Products)
                {
                   price  = price + (item.Price * item.Count);
                }

                Storage.onlineUser.ShoppingCart.Status = StatusShappingCardComplateEnum.Registered;


                Storage.onlineUser.ShoppingCart.UserId = Storage.onlineUser.Id;




                Storage.onlineUser.ShoppingCart.Date = DateTime.Now;
                Storage.onlineUser.ShoppingCart.TotalPrice = price;
                Storage.onlineUser.ShoppingCartComplate.ShoppingCartsComplate.Add(Storage.onlineUser.ShoppingCart);
                Storage.ShoppingCartsComplateAllUser.Add(Storage.onlineUser.ShoppingCart);

               


                foreach (var item in Storage.onlineUser.ShoppingCart.Products)
                {
                    foreach (var item2 in Storage.Products)
                    {
                        if (item.Id == item2.Id)
                        {
                            item2.Quantity -= item.Count;
                        }
                    }
                }
                Storage.onlineUser.ShoppingCart = new Entities.ShoppingCart();
                return true;
            }
            return false;
        }

        public void GetComplateProduct()
        {
            foreach (var product in Storage.onlineUser.ShoppingCartComplate.ShoppingCartsComplate)
            {
                Console.WriteLine($"Id : {product.Id} Status : {product.Status} , Total Price {product.TotalPrice} ,  Date : {product.Date}");
                foreach (var item in product.Products)
                {

                    Console.WriteLine($"Id Product : {item.Id} , Name : {item.Name} , Descreption : {item.Description} , Price : {item.Price} , Color : {item.Color} , Count : {item.Count}");
                }
                Console.WriteLine("*****************************************************************************");
            }
            Console.ReadKey();
        }


        public void GetRegisteredShoppingCartOfAllUser()
        {
            foreach (var item in Storage.ShoppingCartsComplateAllUser)
            {
                if (item.Status == StatusShappingCardComplateEnum.Registered)
                {
                    Console.WriteLine($"Id : {item.Id} , Status : {item.Status} : , User : {GetUserNameForId(item.UserId)} , Total Price {item.TotalPrice} , Date : {item.Date}");
                    foreach (var product in item.Products)
                    {
                        Console.WriteLine($"Id Product : {product.Id} , Name : {product.Name} , Descreption : {product.Description} , Price : {product.Price} , Color : {product.Color} , Count : {product.Count}");
                    }
                }
            }
        }

        public void ConfirmedShappingCart(int Id)
        {
            foreach (var item in Storage.ShoppingCartsComplateAllUser)
            {
                if (item.Id == Id)
                {
                    item.Status = StatusShappingCardComplateEnum.Confirmed;
                }
            }
        }

        public void AddProduct(string name, string description, CategoryEnum category, int price, string color, int quantity)
        {
            Product product = new Product(name, description, category, price, color, quantity);
            Storage.Products.Add(product);
        }

        public void ChangeQuantity(int productId, int quantity)
        {
            foreach (var item in Storage.Products)
            {
                if (item.Id == productId)
                {
                    item.Quantity = quantity;
                }
            }
        }

        public void RemoveProduct(int productId)
        {
            foreach (var item in Storage.Products)
            {
                if (item.Id == productId)
                {
                    Storage.Products.Remove(item);
                    break;
                }
            }
        }

        public void GetAllShappingCart()
        {
            foreach (var item in Storage.ShoppingCartsComplateAllUser)
            {
                    Console.WriteLine($"Id : {item.Id} , Status : {item.Status} , User : {GetUserNameForId(item.UserId)} , Date : {item.Date} , Total Price {item.TotalPrice}");
                    foreach (var product in item.Products)
                    {
                        Console.WriteLine($"Id Product : {product.Id} , Name : {product.Name} , Descreption : {product.Description} , Price : {product.Price} , Color : {product.Color} , Count : {product.Count}");
                    }
            }
        }

        public void GetAllProduct()
        {
            foreach (var item in Storage.Products)
            {
                Console.WriteLine($"Id Product : {item.Id} , Name : {item.Name} , Descreption : {item.Description} , Price : {item.Price} , Color : {item.Color} , Quantity : {item.Quantity}");
            }
        }

        public string GetUserNameForId(int id)
        {
            foreach(var item in Storage.Customers)
            {
                if (item.Id == id)
                {
                    return item.UserName;
                }
            }
            return null;
        }
        

    }
}
