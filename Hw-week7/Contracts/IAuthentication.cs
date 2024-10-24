namespace Hw_week7.Contracts
{
    public interface IAuthentication
    {
        public bool Login(string username, string password);
        public bool Register(string username , string password);
        public bool CkeckUserName(string username);
    }
}
