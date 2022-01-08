using Models;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmployeeBenefitsService
    {
        Task<Employee> CalculateEmployeeBenefitsCost(Employee emp);
    }
}
