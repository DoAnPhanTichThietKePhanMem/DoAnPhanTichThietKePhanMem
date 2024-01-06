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
    public class RegulationController : ControllerBase
    {
        private readonly IRegulationService _regulationService;
        public RegulationController(IRegulationService regulationService)
        {
            _regulationService = regulationService;
        }


        [HttpGet("GetInfoRegulation")]
        public ResponeseMessage GetInfoRegulation()
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _regulationService.GetInfoRegulation();
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

        [HttpGet("getQuantityClass")]
        public ResponeseMessage getQuantityClass()
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _regulationService.getQuantityClass();
            if (model > 0)
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

        [HttpGet("getQuantitySubject")]
        public ResponeseMessage getQuantitySubject()
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _regulationService.getQuantitySubject();
            if (model > 0)
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

        [HttpPost("UpdateRegulation")]
        public ResponeseMessage UpdateRegulation([FromBody] TbRegulation input)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _regulationService.UpdateRegulation(input);
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
    }
}
