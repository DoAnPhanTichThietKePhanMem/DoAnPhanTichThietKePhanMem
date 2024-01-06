namespace QLHS.Repository
{
    public interface IUserRepository
    {
        int Login(string username, string password);
        int Register(string email, string username, string password, string confirmpass);
        bool CheckUserForGetPass(string email, string username);
        bool ResetPass(string email, string username, string password);
    }
}
