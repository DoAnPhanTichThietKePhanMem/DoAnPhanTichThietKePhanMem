using QLHS.DBContext;
using QLHS.Repository;
using System.Collections.Generic;

namespace QLHS.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public List<TbStudent> ListStudentRecord()
        {
            return _studentRepository.ListStudentRecord();
        }
        public List<TbStudent> SearchStudent(string stringSearch)
        {
            return _studentRepository.SearchStudent(stringSearch);
        }
        public bool AddStudent(TbStudent Students)
        {
            return _studentRepository.AddStudent(Students); 
        }
        public bool DeleteStudent(int ID)
        {
            return _studentRepository.DeleteStudent(ID);
        }
        public bool UpdateStudent(TbStudent students)
        {
            return _studentRepository.UpdateStudent(students);
        }
    }
}
