using QLHS.DBContext;
using QLHS.Repository;

namespace QLHS.Services
{
    public class RegulationService:IRegulationService
    {
        private readonly IRegulationRepository _regulationRepository;
        public RegulationService(IRegulationRepository regulationRepository)
        {
            _regulationRepository = regulationRepository;
        }

        public TbRegulation GetInfoRegulation()
        {
            return _regulationRepository.GetInfoRegulation();
        }
        public int getQuantityClass()
        {
            return _regulationRepository.getQuantityClass();
        }
        public int getQuantitySubject()
        {
            return _regulationRepository.getQuantitySubject();
        }
        public bool UpdateRegulation(TbRegulation newRegulation)
        {
            return _regulationRepository.UpdateRegulation(newRegulation);
        }
    }
}
