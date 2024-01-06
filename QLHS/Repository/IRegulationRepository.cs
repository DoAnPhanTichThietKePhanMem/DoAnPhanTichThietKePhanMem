using QLHS.DBContext;

namespace QLHS.Repository
{
    public interface IRegulationRepository
    {
        TbRegulation GetInfoRegulation();
        int getQuantityClass();
        int getQuantitySubject();
        bool UpdateRegulation(TbRegulation newRegulation);
    }
}
