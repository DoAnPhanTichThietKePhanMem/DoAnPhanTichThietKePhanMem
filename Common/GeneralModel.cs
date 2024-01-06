using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class GeneralModel
    {
        public class ResponeseMessage
        {
            public bool IsSuccess { get; set; }
            public int Status { get; set; }
            public string Message { get; set; }
            public object Data { get; set; }
        }

        public class UserLoginRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class UserRegisterRequest
        {

            public string Email { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }

        }
    }
}
