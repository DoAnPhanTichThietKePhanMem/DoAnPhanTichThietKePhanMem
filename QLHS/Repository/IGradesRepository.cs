using QLHS.DBContext;
using QLHS.ViewModel;
using System.Collections.Generic;

namespace QLHS.Repository
{
    public interface IGradesRepository
    {
        List<GradesVM> GetGradesList(int ClassID, int SemeterID, int SubjectID);
        List<TbStudent> GetInfoStudentsOfClass(int classId);
        List<TbSemester> GetInfoSemeters();
        bool AddGrades(TbTranScript ts);
        bool UpdateGrades(TbTranScript ts);
        bool CheckGrades(TbTranScript ts);
        bool DeleteGrades(int ID);
    }
}
