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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }


        [HttpGet("GetInfoSubjects")]
        public ResponeseMessage GetInfoSubjects()
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _subjectService.GetInfoSubjects();
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

        [HttpGet("GetSubjectByName")]
        public ResponeseMessage GetSubjectByName(string name)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _subjectService.GetSubjectByName(name);
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

        [HttpPost("AddInfoSubject")]
        public ResponeseMessage AddInfoSubject(TbSubject input)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _subjectService.AddInfoSubject(input);
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

        [HttpPost("UpdateInfoNameSubject")]
        public ResponeseMessage UpdateInfoNameSubject(UpdateSubjectInfoRequest input)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _subjectService.UpdateInfoNameSubject(input.SubjectID, input.NewName);
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

        [HttpDelete("DeleteInfoSubject")]
        public ResponeseMessage DeleteInfoSubject(int subjectId)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _subjectService.DeleteInfoSubject(subjectId);
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
