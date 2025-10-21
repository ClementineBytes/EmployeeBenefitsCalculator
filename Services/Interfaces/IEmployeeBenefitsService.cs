using Models.DTO;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmployeeBenefitsService
    {
        Task<BenefitDTO> CalculateBenefitsCost(EmployeeDTO emp);
    }
}
