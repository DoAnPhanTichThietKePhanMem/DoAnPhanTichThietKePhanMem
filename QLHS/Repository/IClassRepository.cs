using QLHS.DBContext;
using QLHS.ViewModel;
using System.Collections.Generic;

namespace QLHS.Repository
{
    public interface IClassRepository
    {
        List<TbGroup> GetInfoGroup();
        List<TbClass> GetInfoClass(int gradeId);
        TbClass GetInfoClassByName(string name);
        List<TbStudent> GetInfoStudentsOfClass(GetInfoStudentsOfClassRequest input);
        List<TbStudent> GetInfoStudentsWithoutClass(string studentNameSearch);
        bool CheckQuantityStudentOfclass(CheckQuantityStudentOfclassRequest input);
        bool AddStudentIntoClass(AddStudentIntoClassRequest input);
        bool DeleteStudentFromClass(int studentId);
        bool AddInfoClass(TbClass newClass);
        bool UpdateInfoNameClass(UpdateInfoNameClassRequest input);
        bool DeleteInfoClass(int classId);
    }
}
