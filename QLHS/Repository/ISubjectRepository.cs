using QLHS.DBContext;
using System.Collections.Generic;

namespace QLHS.Repository
{
    public interface ISubjectRepository
    {
        List<TbSubject> GetInfoSubjects();
        TbSubject GetSubjectByName(string name);
        bool AddInfoSubject(TbSubject newSubject);
        bool UpdateInfoNameSubject(int subjectId, string newName);
        bool DeleteInfoSubject(int subjectId);
    }
}
