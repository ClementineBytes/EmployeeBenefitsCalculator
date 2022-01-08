using Models;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeBenefitsService : IEmployeeBenefitsService
    {
        public async Task<Employee> CalculateEmployeeBenefitsCost(Employee emp)
        {
            double annualBenefitsRate = 1000;
            double dependentsRate = 500;
            double discountRate = 0.1;

            double annualBenefitsDiscountAmount = annualBenefitsRate * discountRate;
            double dependentsDiscountAmount = dependentsRate * discountRate;

            double dependentsCost = 0;
            double annualBenefitsCost = 0;

            if (emp.Dependents != null && emp.Dependents.Count > 0)
            {
                foreach (Person dependent in emp.Dependents)
                {
                    if (dependent.FirstName.ToUpper().StartsWith("A"))
                    {
                        dependentsCost += dependentsRate - dependentsDiscountAmount;
                    }
                    else
                    {
                        dependentsCost += dependentsRate;
                    }
                }
            }
            if (emp.FirstName.ToUpper().StartsWith("A"))
            {
                annualBenefitsCost = annualBenefitsRate - annualBenefitsDiscountAmount;
            }
            else
            {
                annualBenefitsCost = annualBenefitsRate;
            }
            emp.BenefitsCost = (decimal)(annualBenefitsCost + dependentsCost);
            return await Task.FromResult(emp);
        }
    }
}
