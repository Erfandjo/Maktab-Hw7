using Hw_week7.Data;
using Hw_week7.Entities;
using Hw_week7.Enum;
using Hw_week7.Service;


string userName = string.Empty;
string password = string.Empty;
bool IsRegister = false;
bool IsLogin = false;
int bookId = -1;

Authentication authentication = new Authentication();
StoreService storeService = new StoreService();

int option2 = 0;
int option = 0;
int option3 = 0;

while (true)
{
    Console.Clear();
    Console.WriteLine("1)Login");
    Console.WriteLine("2)Register");
    Console.Write("Please Enter Option : ");
    option = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
    switch (option)
    {
        case 1:
            do
            {
                Console.Write("Please Enter UserName : ");
                userName = Console.ReadLine();
                Console.Write("Please Enter Password : ");
                password = Console.ReadLine();
                IsLogin = authentication.Login(userName, password);
                if (!IsLogin)
                {
                    Console.Clear();
                    Console.WriteLine("UserName Or Password Incorrect");
                }
                else
                {
                    Storage.onlineUser = Customer.GetCustomer(userName);
                    Storage.onlineUser.ShoppingCart = new ShoppingCart();
                }

            } while (!IsLogin);
            break;

        case 2:
            do
            {
                Console.Write("Please Enter UserName : ");
                userName = Console.ReadLine();
                Console.Write("Please Enter Password : ");
                password = Console.ReadLine();
                Console.WriteLine("Please Enter Role :  Admin = 0 ,  Member = 1");
                int role = Convert.ToInt32(Console.ReadLine());
                IsRegister = authentication.Register(userName, password);
                if (!IsRegister)
                {
                    Console.Clear();
                    Console.WriteLine("UserName Is Exist");
                }
                else
                {
                    Storage.onlineUser = Customer.GetCustomer(userName);
                }
            } while (!IsRegister);
            break;
    }

    if (Storage.onlineUser.Role == RoleEnum.Member)
    {
        do
        {
            Console.Clear();
            MenuMember();
            switch (option2)
            {

                case 1:
                    Console.Clear();
                    Console.WriteLine($"Accessory = {(int)CategoryEnum.Accessory} , Digital = {(int)CategoryEnum.Digital} , Sports = {(int)CategoryEnum.Sports} , Game = {(int)CategoryEnum.Game} , Home Appliances = {(int)CategoryEnum.HomeAppliances} , Travel = {(int)CategoryEnum.Travel} , Books = {(int)CategoryEnum.Books} , Stationery = {(int)CategoryEnum.Stationery} ");
                    int category = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    storeService.GetProduct(category);
                    Console.Write("Please Enter Item For Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please Enter Count : ");
                    int count = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(storeService.SelectProduct(id, count));
                     
                        Console.ReadKey();
                    
                    break;

                case 2:
                    Console.Clear();
                    storeService.GetShoppingCart();
                    Console.ReadKey();
                    break;

                case 3:
                    storeService.GetShoppingCart();
                    Console.Write("Do you Complate Purchases ? (1)yes , 2)No ) ");
                    int complate = Convert.ToInt32(Console.ReadLine());
                    if (complate == 1)
                    {
                        storeService.ComplateBuy();
                    }
                    break;

                case 4:
                    storeService.GetComplateProduct();
                    break;
                case 5:
                    Storage.onlineUser = null;
                    break;
            }
        } while (option2 != 5);
    }
    else if (Storage.onlineUser.Role == RoleEnum.Admin)
    {

        do
        {
            Console.Clear();
            MenuAdmin();
            switch (option3)
            {

                case 1:
                    storeService.GetRegisteredShoppingCartOfAllUser();
                    Console.Write("Please Enter Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    storeService.ConfirmedShappingCart(id);
                    break;
                case 2:
                    Console.Write("Please Enter Name Product : ");
                    string name = Console.ReadLine();
                    Console.Write("Please Enter Description : ");
                    string description = Console.ReadLine();
                    Console.WriteLine($"Accessory = {(int)CategoryEnum.Accessory} , Digital = {(int)CategoryEnum.Digital} , Sports = {(int)CategoryEnum.Sports} , Game = {(int)CategoryEnum.Game} , Home Appliances = {(int)CategoryEnum.HomeAppliances} , Travel = {(int)CategoryEnum.Travel} , Books = {(int)CategoryEnum.Books} , Stationery = {(int)CategoryEnum.Stationery} ");
                    Console.Write("Please Enter Category : ");
                    int category = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please Enter Price : ");
                    int price = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please Enter Color : ");
                    string color = Console.ReadLine();
                    Console.Write("Please Enter Quantity : ");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    storeService.AddProduct(name, description, (CategoryEnum)category,  price, color , quantity);
                    break;
                case 3:
                    storeService.GetAllProduct();
                    Console.Write("Please Enter Id : ");
                    int idd = Convert.ToInt32(Console.ReadLine());
                    Console.Write("How Many Quantity ? ");
                    int newQuantity = Convert.ToInt32(Console.ReadLine());
                    storeService.ChangeQuantity(idd , newQuantity);
                    break;

                case 4:
                    storeService.GetAllProduct();
                    Console.Write("Please Enter Id : ");
                    int iddd = Convert.ToInt32(Console.ReadLine());
                    storeService.RemoveProduct(iddd);
                    break;
                case 5:
                    storeService.GetAllShappingCart();
                    Console.ReadKey();
                    break;
                    case 6:
                    Storage.onlineUser = null;
                    break;
            }
        } while (option3 != 6);



    }



}








void MenuMember()
{
    Console.WriteLine("1) Buy Product");
    Console.WriteLine("2) Shopping Cart");
    Console.WriteLine("3) Complate Purchases");
    Console.WriteLine("4) List Previous Purchases");
    Console.WriteLine("5) log Out");
    Console.Write("Please Enter Option : ");
    option2 = Convert.ToInt32(Console.ReadLine());
}

void MenuAdmin()
{
    Console.WriteLine("1) Confirmed Shapping Cart");
    Console.WriteLine("2) Add Product");
    Console.WriteLine("3) Change Quantity");
    Console.WriteLine("4) Remove");
    Console.WriteLine("5) Get All Shopping Cart");
    Console.WriteLine("6) log Out");
    Console.Write("Please Enter Option : ");
    option3 = Convert.ToInt32(Console.ReadLine());
}


DateTime date;
date.AddHours(14);
date.AddMinutes(15);
date.AddSeconds(15);

Console.WriteLine(date);
