using QLHS.Repository;
using QLHS.ViewModel;
using System.Collections.Generic;

namespace QLHS.Services
{
    public class ReportServices:IReportService
    {
        private IReportRepository _reportRepository;
        public ReportServices(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public List<ReportVM> BaoCaoTongKetMon(int SubjectID, int SemeterID)
        {
            return _reportRepository.BaoCaoTongKetMon(SubjectID, SemeterID);
        }
        public List<ReportVM> BaoCaoTongKetHocKy(int SemeterID)
        {
            return _reportRepository.BaoCaoTongKetHocKy(SemeterID);
        }
    }
}
