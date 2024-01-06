using QLHS.ViewModel;
using System.Collections.Generic;

namespace QLHS.Services
{
    public interface IReportService
    {
        List<ReportVM> BaoCaoTongKetMon(int SubjectID, int SemeterID);
        List<ReportVM> BaoCaoTongKetHocKy(int SemeterID);
    }
}
