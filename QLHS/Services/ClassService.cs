using QLHS.DBContext;
using QLHS.Repository;
using QLHS.ViewModel;
using System.Collections.Generic;

namespace QLHS.Services
{
    public class ClassService:IClassService
    {
        private IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public List<TbGroup> GetInfoGroup()
        {
            return _classRepository.GetInfoGroup();
        }
        public List<TbClass> GetInfoClass(int gradeId)
        {
            return _classRepository.GetInfoClass(gradeId);
        }
        public TbClass GetInfoClassByName(string name) 
        {
            return _classRepository.GetInfoClassByName(name); 
        }
        public List<TbStudent> GetInfoStudentsOfClass(GetInfoStudentsOfClassRequest input)
        {
            return _classRepository.GetInfoStudentsOfClass(input);
        }
        public List<TbStudent> GetInfoStudentsWithoutClass(string studentNameSearch) 
        { 
            return _classRepository.GetInfoStudentsWithoutClass(studentNameSearch); 
        }
        public bool CheckQuantityStudentOfclass(CheckQuantityStudentOfclassRequest input) 
        {
            return _classRepository.CheckQuantityStudentOfclass(input);
        }
        public bool AddStudentIntoClass(AddStudentIntoClassRequest input) 
        { 
            return _classRepository.AddStudentIntoClass(input); 
        }

        public bool DeleteStudentFromClass(int studentId) 
        { 
            return _classRepository.DeleteStudentFromClass(studentId); 
        }
        public bool AddInfoClass(TbClass newClass) 
        { 
            return _classRepository.AddInfoClass(newClass); 
        }

        public bool UpdateInfoNameClass(UpdateInfoNameClassRequest input) 
        { 
            return _classRepository.UpdateInfoNameClass(input); 
        }
        public bool DeleteInfoClass(int classId) 
        { 
            return _classRepository.DeleteInfoClass(classId); 
        }
    }
}
