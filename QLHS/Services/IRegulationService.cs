using QLHS.DBContext;

namespace QLHS.Services
{
    public interface IRegulationService
    {
        TbRegulation GetInfoRegulation();
        int getQuantityClass();
        int getQuantitySubject();
        bool UpdateRegulation(TbRegulation newRegulation);
    }
}
