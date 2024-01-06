using QLHS.DBContext;
using System.Collections.Generic;

namespace QLHS.Services
{
    public interface ISubjectService
    {
        List<TbSubject> GetInfoSubjects();
        TbSubject GetSubjectByName(string name);
        bool AddInfoSubject(TbSubject newSubject);
        bool UpdateInfoNameSubject(int subjectId, string newName);
        bool DeleteInfoSubject(int subjectId);
    }
}
