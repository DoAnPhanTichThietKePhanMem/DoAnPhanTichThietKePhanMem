namespace QLHS.Services
{
    public interface IUserService
    {
        int Login(string username, string password);
        int Register(string email, string username, string password, string confirmpass);
        bool CheckUserForGetPass(string email, string username);
        bool ResetPass(string email, string username, string password);
    }
}
