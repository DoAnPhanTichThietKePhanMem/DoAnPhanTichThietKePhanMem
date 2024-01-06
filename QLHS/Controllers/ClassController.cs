using Microsoft.AspNetCore.Mvc;
using QLHS.DBContext;
using QLHS.Services;
using QLHS.ViewModel;
using static Common.GeneralModel;

namespace QLHS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet("GetInfoGroup")]
        public ResponeseMessage GetInfoGroup()
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _classService.GetInfoGroup();
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

        [HttpGet("GetInfoClass")]
        public ResponeseMessage GetInfoClass(int gradeId)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _classService.GetInfoClass(gradeId);
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

        [HttpGet("GetInfoClassByName")]
        public ResponeseMessage GetInfoClassByName(string name)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _classService.GetInfoClassByName(name);
            if (model != null)
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

        [HttpPost("GetInfoStudentsOfClass")]
        public ResponeseMessage GetInfoStudentsOfClass([FromBody] GetInfoStudentsOfClassRequest input)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _classService.GetInfoStudentsOfClass(input);
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

        [HttpGet("GetInfoStudentsWithoutClass")]
        public ResponeseMessage GetInfoStudentsWithoutClass(string studentNameSearch)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _classService.GetInfoStudentsWithoutClass(studentNameSearch);
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

        [HttpPost("CheckQuantityStudentOfclass")]
        public ResponeseMessage CheckQuantityStudentOfclass([FromBody] CheckQuantityStudentOfclassRequest input)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _classService.CheckQuantityStudentOfclass(input);

            if (model)
            {
                rs.Status = 200;
                rs.Message = "Successfully";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Fail !!!";
            }
            return rs;
        }

        [HttpPost("AddStudentIntoClass")]
        public ResponeseMessage AddStudentIntoClass([FromBody] AddStudentIntoClassRequest input)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _classService.AddStudentIntoClass(input);
            if (model)
            {
                rs.Status = 200;
                rs.Message = "Add data successfully";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Add data fail !!!";
            }
            return rs;
        }

        [HttpDelete("DeleteStudentFromClass")]
        public ResponeseMessage DeleteStudentFromClass(int studentId)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _classService.DeleteStudentFromClass(studentId);
            if (model)
            {
                rs.Status = 200;
                rs.Message = "Delete successfully";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Delete data fail";
            }
            return rs;
        }


        [HttpPost("AddInfoClass")]
        public ResponeseMessage AddInfoClass(TbClass newClass)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _classService.AddInfoClass(newClass);
            if (model)
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

        [HttpPost("UpdateInfoNameClass")]
        public ResponeseMessage UpdateInfoNameClass(UpdateInfoNameClassRequest input)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _classService.UpdateInfoNameClass(input);
            if (model)
            {
                rs.Status = 200;
                rs.Message = "Update successfully";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Not Found data";
            }
            return rs;
        }

        [HttpDelete("DeleteInfoClass")]
        public ResponeseMessage DeleteInfoClass(int classId)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _classService.DeleteInfoClass(classId);
            if (model)
            {
                rs.Status = 200;
                rs.Message = "Delete successfully";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Not Found data";
            }
            return rs;
        }
        
    }
}
