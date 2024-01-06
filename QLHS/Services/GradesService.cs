using QLHS.DBContext;
using QLHS.Repository;
using QLHS.ViewModel;
using System.Collections.Generic;

namespace QLHS.Services
{
    public class GradesService:IGradesService
    {
        private readonly IGradesRepository _gradesRepository;
        public GradesService(IGradesRepository gradesRepository)
        {
            _gradesRepository = gradesRepository;
        }
        public List<GradesVM> GetGradesList(int ClassID, int SemeterID, int SubjectID)
        {
            return _gradesRepository.GetGradesList(ClassID, SemeterID, SubjectID);
        }
        public List<TbStudent> GetInfoStudentsOfClass(int classId)
        {
            return _gradesRepository.GetInfoStudentsOfClass(classId);
        }
        public List<TbSemester> GetInfoSemeters()
        {
            return _gradesRepository.GetInfoSemeters();
        }
        public bool AddGrades(TbTranScript ts)
        {
            return _gradesRepository.AddGrades(ts);
        }
        public bool UpdateGrades(TbTranScript ts)
        {
            return _gradesRepository.UpdateGrades(ts);
        }
        public bool CheckGrades(TbTranScript ts)
        {
            return _gradesRepository.CheckGrades(ts);
        }
        public bool DeleteGrades(int ID)
        {
            return _gradesRepository.DeleteGrades(ID);
        }
    }
}
