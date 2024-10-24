namespace Hw_week7.Contracts
{
    public interface IStoreService
    {
        public void GetProduct(int number);
        public string SelectProduct(int id, int count);
        public int CheckShoppingCart(int productId);
        public bool ComplateBuy();


    }
}
