using AutoMapper;
using Models.DTO;
using Models.Employees;
using Models.Payroll;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeBenefitsService : IEmployeeBenefitsService
    {
        private readonly IBenefitsCalculatorFactory _benefitsCalculatorFactory;
        private readonly IMapper _mapper;

        public EmployeeBenefitsService(IBenefitsCalculatorFactory benefitsCalculatorFactory, IMapper mapper)
        {
            _benefitsCalculatorFactory = benefitsCalculatorFactory;
            _mapper = mapper;
        }
        public Task<BenefitDTO> CalculateBenefitsCost(EmployeeDTO emp)
        {
            var employee = _mapper.Map<Employee>(emp);
            var benefitsCalculator = _benefitsCalculatorFactory.Create(employee.CompType);
            var calculatedBenefit = new Benefit();

            var cost = benefitsCalculator.CalculateBenefitsCost(employee);
            calculatedBenefit.Cost = cost;

            var result = _mapper.Map<BenefitDTO>(calculatedBenefit);
            return Task.FromResult(result);
        }
    }
}
