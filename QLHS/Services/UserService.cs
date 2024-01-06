using QLHS.Repository;

namespace QLHS.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Login(string username, string password)
        {
            return _userRepository.Login(username, password);
        }
        public int Register(string email, string username, string password, string confirmpass)
        {
            return _userRepository.Register(email, username, password, confirmpass);
        }

        public bool CheckUserForGetPass(string email, string username)
        {
            return _userRepository.CheckUserForGetPass(email, username);
        }

        public bool ResetPass(string email, string username, string password)
        {
            return _userRepository.ResetPass(email, username, password);    
        }
    }
}
