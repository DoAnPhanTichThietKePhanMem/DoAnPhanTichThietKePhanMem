using QLHS.DBContext;
using QLHS.Repository;
using System.Collections.Generic;

namespace QLHS.Services
{
    public class SubjectService:ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public bool AddInfoSubject(TbSubject newSubject)
        {
            return _subjectRepository.AddInfoSubject(newSubject);
        }

        public bool DeleteInfoSubject(int subjectId)
        {
            return _subjectRepository.DeleteInfoSubject(subjectId);
        }

        public List<TbSubject> GetInfoSubjects()
        {
            return _subjectRepository.GetInfoSubjects();
        }

        public TbSubject GetSubjectByName(string name)
        {
            return _subjectRepository.GetSubjectByName(name);
        }

        public bool UpdateInfoNameSubject(int subjectId, string newName)
        {
            return _subjectRepository.UpdateInfoNameSubject(subjectId, newName);
        }
    }
}
