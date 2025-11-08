using Models.Employees;
using System.Linq;

namespace Models.Payroll
{
    public class SalaryEmployeeBenefitsCalculator : IBenefitsCalculator
    {
        private readonly double annualBenefitsRate = 1000;
        private readonly double dependentsRate = 500;
        private readonly double discountRate = 0.1;

        public double CalculateBenefitsCost(IEmployee emp)
        {
            double dependentsCost = 0;
            double annualBenefitsCost = 0;

            var annualBenefitsDiscountAmount = CalculateAnnualBenefitsDiscount();
            var dependentsDiscountAmount = CalculateDependentsDiscount();

            if (emp.Dependents != null && emp.Dependents.Any())
            {
                foreach (var dependent in emp.Dependents)
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

            return annualBenefitsCost + dependentsCost;
        }

        private double CalculateAnnualBenefitsDiscount()
        {
            return annualBenefitsRate * discountRate;
        }

        private double CalculateDependentsDiscount()
        {
            return dependentsRate * discountRate;
        }
    }
}
