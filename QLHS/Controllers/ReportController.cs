using Microsoft.AspNetCore.Mvc;
using QLHS.DBContext;
using QLHS.Services;
using QLHS.ViewModel;
using static Common.GeneralModel;

namespace QLHS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("BaoCaoTongKetHocKy")]
        public ResponeseMessage BaoCaoTongKetHocKy(int semeterID)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _reportService.BaoCaoTongKetHocKy(semeterID);
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

        [HttpGet("BaoCaoTongKetMon")]
        public ResponeseMessage BaoCaoTongKetMon(int subjectID, int semeterID)
        {
            ResponeseMessage rs = new ResponeseMessage();
            var model = _reportService.BaoCaoTongKetMon(subjectID, semeterID);
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
        
    }
}
