using Microsoft.AspNetCore.Mvc;
using QLHS.Services;
using static Common.GeneralModel;

namespace QLHS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public ResponeseMessage Login([FromBody] UserLoginRequest accountInput)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _userService.Login(accountInput.UserName, accountInput.Password);
            if (model == 1)
            {
                rs.Status = 200;
                rs.Message = "Login successfully!";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Login failed!";
                rs.Data = model;
            }
            return rs;
        }


        [HttpPost("Register")]
        public ResponeseMessage Register([FromBody] UserRegisterRequest accountInput)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _userService.Register(accountInput.Email,accountInput.UserName, accountInput.Password, accountInput.ConfirmPassword);
            if (model == 1)
            {
                rs.Status = 200;
                rs.Message = "Register successfully!";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Register failed!";
                rs.Data = model;
            }
            return rs;
        }

        [HttpPost("CheckUserForGetPass")]
        public ResponeseMessage CheckUserForGetPass([FromBody] UserRegisterRequest accountInput)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _userService.CheckUserForGetPass(accountInput.Email, accountInput.UserName);
            if (model)
            {
                rs.Status = 200;
                rs.Message = "User exist!";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "User not exist!";
                rs.Data = model;
            }
            return rs;
        }

        [HttpPut("ResetPass")]
        public ResponeseMessage ResetPass([FromBody] UserRegisterRequest accountInput)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _userService.ResetPass(accountInput.Email, accountInput.UserName, accountInput.Password);
            if (model)
            {
                rs.Status = 200;
                rs.Message = "Reset password successfully!";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Reset password failed!";
                rs.Data = model;
            }
            return rs;
        }


    }
}
