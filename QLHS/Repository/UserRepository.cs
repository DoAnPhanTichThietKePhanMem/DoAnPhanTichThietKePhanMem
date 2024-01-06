using QLHS.DBContext;
using System.Linq;
using System.Text;
using System;
using Common;
using System.Security.Cryptography;

namespace QLHS.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly iyjh6fZpyWContext _dbContext;
        public UserRepository(iyjh6fZpyWContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Login(string username, string password)
        {
            // return 0 : Sai tên tài khoản
            // return 1 : Đăng nhập thành công
            // return 2 : Sai mật khẩu
            var user = _dbContext.TbUsers.SingleOrDefault(u => u.Username == username && u.IsDeleted == false);


            if (user != null)
            {
                var sha1 = new SHA1CryptoServiceProvider();
                var bytesPwhashSalt = Helpers.StringToByteArray(user.Password);
                //SHA1 hash -> 20 byte => bytesPwhashSalt - 20 = byteSalt
                var LenPwhash = 20;
                var bytesPwhash = new byte[LenPwhash];
                Array.Copy(bytesPwhashSalt, bytesPwhash, LenPwhash);

                //hash password user input
                var PwUserInput = ASCIIEncoding.ASCII.GetBytes(password);
                var bytesPwUserHash = sha1.ComputeHash(PwUserInput);

                // chuyển array byte to string
                var strPwhash =Helpers.ArrByteToString(bytesPwhash);
                var strPwUserIpHash = Helpers.ArrByteToString(bytesPwUserHash);

                // Đăng nhập thành công
                if (strPwhash == strPwUserIpHash)
                {
                    return 1;
                }

                // Sai mật khẩu
                else
                {
                    return 2;
                }
            }

            // tên đăng nhập không tồn tại
            else
            {
                return 0;
            }
        }

        public int Register(string email, string username, string password, string confirmpass)
        {
            // return 0 : tài khoản đã tồn tại
            // return 1 : Đăng ký thành công
            // return 2 : Mật khẩu xác nhận lại ko đúng


            string strPwHash = Helpers.HasPassword(password);
            // Lấy Username kiểm tra tồn tại chưa
            var user = _dbContext.TbUsers.SingleOrDefault(u => u.Username == username);

            // Tên tài khoản đã tồn tại
            if (user != null)
            {
                return 0;
            }
            else
            {
                // Đăng ký thành công
                if (confirmpass == password)
                {
                    TbUser users = new TbUser();
                    users.Email = email;
                    users.Username = username;
                    users.Password = strPwHash;
                    users.RoleId = 1;
                    users.CreatedDate = DateTime.Now;
                    users.LastUpdatedDate = DateTime.Now;
                    users.IsDeleted = false;

                    _dbContext.TbUsers.Add(users);
                    _dbContext.SaveChanges();

                    return 1;
                }

                // Mật khẩu xác nhận lại không đúng
                else
                {
                    return 2;
                }
            }

        }

        public bool CheckUserForGetPass(string email, string username)
        {
            var user = _dbContext.TbUsers.SingleOrDefault(u => u.Username == username && u.Email == email);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ResetPass(string email, string username, string password)
        {
            var user = _dbContext.TbUsers.SingleOrDefault(u => u.Username == username && u.Email == email);
            if (user != null)
            {
                user.Password = Helpers.HasPassword(password);
                user.LastUpdatedDate = DateTime.Now;
                return _dbContext.SaveChanges() > 1;
            }
            else
            {
                return false;
            }
        }
        
    }
}
