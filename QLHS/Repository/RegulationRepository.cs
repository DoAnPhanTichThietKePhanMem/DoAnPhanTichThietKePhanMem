using QLHS.DBContext;
using System.Linq;

namespace QLHS.Repository
{
    public class RegulationRepository:IRegulationRepository
    {
        private readonly iyjh6fZpyWContext _dbContext;
        public RegulationRepository(iyjh6fZpyWContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TbRegulation GetInfoRegulation()
        {
            return _dbContext.TbRegulations.Where(re => re.IsDeleted == false).FirstOrDefault();
        }

        public int getQuantityClass()
        {
            return _dbContext.TbClasses.Where(cl => cl.IsDeleted == false).Count();
        }

        public int getQuantitySubject()
        {
            return _dbContext.TbSubjects.Where(sj => sj.IsDeleted == false).Count();
        }

        public bool UpdateRegulation(TbRegulation newRegulation)
        {

            TbRegulation oldRegulation = _dbContext.TbRegulations.Single(re => re.Id == newRegulation.Id);
            oldRegulation.MaxAge = newRegulation.MaxAge;
            oldRegulation.MinAge = newRegulation.MinAge;
            oldRegulation.MaxQuantity = newRegulation.MaxQuantity;
            oldRegulation.ClassQuantity = newRegulation.ClassQuantity;
            oldRegulation.SubjectQuantity = newRegulation.SubjectQuantity;
            oldRegulation.PassingGrade = newRegulation.PassingGrade;

            return _dbContext.SaveChanges() > 0;

        }
    }
}
