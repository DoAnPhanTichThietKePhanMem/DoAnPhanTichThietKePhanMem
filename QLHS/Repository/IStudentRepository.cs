using QLHS.DBContext;
using System.Collections.Generic;

namespace QLHS.Repository
{
    public interface IStudentRepository
    {
        List<TbStudent> ListStudentRecord();
        List<TbStudent> SearchStudent(string stringSearch);
        bool AddStudent(TbStudent Students);
        bool DeleteStudent(int ID);
        bool UpdateStudent(TbStudent students);
    }
}
