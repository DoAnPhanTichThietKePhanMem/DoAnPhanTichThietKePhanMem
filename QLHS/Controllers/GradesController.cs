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
    public class GradesController : ControllerBase
    {
        private readonly IGradesService _gradesService;
        public GradesController(IGradesService gradesService)
        {
            _gradesService = gradesService;
        }


        [HttpGet("GetGradesList/{ClassID}/{SemeterID}/{SubjectID}")]
        public ResponeseMessage GetGradesList([FromRoute] int ClassID, [FromRoute] int SemeterID, [FromRoute] int SubjectID)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _gradesService.GetGradesList(ClassID, SemeterID, SubjectID);
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

        [HttpGet("GetInfoStudentsOfClass/{classId}")]
        public ResponeseMessage GetInfoStudentsOfClass([FromRoute] int classId)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _gradesService.GetInfoStudentsOfClass(classId);
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

        [HttpGet("GetInfoSemeters")]
        public ResponeseMessage GetInfoSemeters()
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _gradesService.GetInfoSemeters();
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

        [HttpPost("AddGrades")]
        public ResponeseMessage AddGrades([FromBody] TbTranScript input)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _gradesService.AddGrades(input);
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

        [HttpPut("UpdateGrades")]
        public ResponeseMessage UpdateGrades([FromBody] TbTranScript input)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _gradesService.UpdateGrades(input);
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

        [HttpPost("CheckGrades")]
        public ResponeseMessage CheckGrades([FromBody] TbTranScript input)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _gradesService.CheckGrades(input);
            if (model)
            {
                rs.Status = 200;
                rs.Message = "Successfully";
                rs.Data = model;
            }
            else
            {
                rs.Status = 0;
                rs.Message = "Not Found data";
            }
            return rs;
        }

        [HttpDelete("DeleteGrades")]
        public ResponeseMessage DeleteGrades(int ID)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _gradesService.DeleteGrades(ID);
            if (model)
            {
                rs.Status = 200;
                rs.Message = "Delete data successfully";
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
