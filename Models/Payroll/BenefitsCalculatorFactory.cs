using System;

namespace Models.Payroll
{
    public interface IBenefitsCalculatorFactory
    {
        IBenefitsCalculator Create(CompensationType compType);
    }

    public class BenefitsCalculatorFactory : IBenefitsCalculatorFactory
    {
        public IBenefitsCalculator Create(CompensationType compType)
        {
            switch (compType)
            {
                case CompensationType.Salary:
                    return new SalaryEmployeeBenefitsCalculator();
                case CompensationType.Hourly:
                    throw new NotImplementedException();
                case CompensationType.Seasonal:
                    throw new NotImplementedException();
                default: throw new NotImplementedException();
            }
        }
    }

}
