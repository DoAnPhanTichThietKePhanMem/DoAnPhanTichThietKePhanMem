using Microsoft.AspNetCore.Mvc;
using QLHS.DBContext;
using QLHS.Services;
using QLHS.ViewModel;
using System.Collections.Generic;
using static Common.GeneralModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLHS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet("ListStudentRecord")]
        public ResponeseMessage ListStudentRecord()
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _studentService.ListStudentRecord();
            if (model.Count > 0)
            {
                rs.Status = 200;
                rs.Message = "Get Data successfully";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Not Found data";
            }
            return rs;
        }

        [HttpGet("SearchStudent")]
        public ResponeseMessage SearchStudent(string stringSearch)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _studentService.SearchStudent(stringSearch);
            if (model.Count > 0)
            {
                rs.Status = 200;
                rs.Message = "Get Data successfully";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Not Found data";
            }
            return rs;
        }

        [HttpPost("AddStudent")]
        public ResponeseMessage AddStudent(TbStudent input)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _studentService.AddStudent(input);
            if (model)
            {
                rs.Status = 200;
                rs.Message = "Insert Data successfully";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Insert failed";
            }
            return rs;
        }

        [HttpDelete("DeleteStudent")]
        public ResponeseMessage DeleteStudent(int ID)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _studentService.DeleteStudent(ID);
            if (model)
            {
                rs.Status = 200;
                rs.Message = "Delete Data successfully";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Delete failed";
            }
            return rs;
        }

        [HttpPut("UpdateStudent")]
        public ResponeseMessage UpdateStudent([FromBody] TbStudent input)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _studentService.UpdateStudent(input);
            if (model)
            {
                rs.Status = 200;
                rs.Message = "Update Data successfully";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Update failed";
            }
            return rs;
        }

    }
}
