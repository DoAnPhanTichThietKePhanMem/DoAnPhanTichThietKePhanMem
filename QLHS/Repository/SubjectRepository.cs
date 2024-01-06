using QLHS.DBContext;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace QLHS.Repository
{
    public class SubjectRepository:ISubjectRepository
    {
        private readonly iyjh6fZpyWContext _dbContext;
        public SubjectRepository(iyjh6fZpyWContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TbSubject> GetInfoSubjects()
        {
            var list = new List<TbSubject>(_dbContext.TbSubjects.Where(sj => sj.IsDeleted == false).ToList());

            return list;
        }

        public TbSubject GetSubjectByName(string name)
        {
            return _dbContext.TbSubjects.FirstOrDefault(sj => sj.Name == name && sj.IsDeleted == false);
        }

        public bool AddInfoSubject(TbSubject newSubject)
        {
            _dbContext.TbSubjects.Add(newSubject);
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateInfoNameSubject(int subjectId, string newName)
        {
            var subjectInfo = _dbContext.TbSubjects.Single(st => st.Id == subjectId && st.IsDeleted == false);
            subjectInfo.Name = newName;

            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteInfoSubject(int subjectId)
        {
            var subjectInfo = _dbContext.TbSubjects.Single(st => st.Id == subjectId);
            subjectInfo.IsDeleted = true;

            return _dbContext.SaveChanges() > 0;
        }
    }
}
