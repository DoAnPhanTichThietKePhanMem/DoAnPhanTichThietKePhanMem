using QLHS.ViewModel;
using System.Collections.Generic;

namespace QLHS.Repository
{
    public interface IReportRepository
    {
        List<ReportVM> BaoCaoTongKetMon(int SubjectID, int SemeterID);
        List<ReportVM> BaoCaoTongKetHocKy(int SemeterID);
    }
}
