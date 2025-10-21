
using Models.Employees;

namespace Models.Payroll
{
    public interface IBenefitsCalculator
    {
        double CalculateBenefitsCost(IEmployee employee);
    }
}
