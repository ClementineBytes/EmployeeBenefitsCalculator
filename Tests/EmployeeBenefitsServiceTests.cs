using AutoMapper;
using Models;
using Models.DTO;
using Models.Employees;
using Models.Payroll;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class EmployeeBenefitsServiceTests
    {
        private BenefitDTO _calculatedBenefit;

        [Fact]
        public async Task EmployeeFirstNameDiscount()
        {
            //arrange
            var employee = new EmployeeDTO { FirstName = "Anakin", LastName = "Skywalker", CompType = CompensationType.Salary };

            //act
            await WhenCalculatingBenefitCostForEmployee(employee);

            //assert
            ThenTheExpectedCostWasCalculated(900);
        }

        [Fact]
        public async Task EmployeeFirstNameNoDiscount()
        {
            //arrange
            var employee = new EmployeeDTO { FirstName = "Luke", LastName = "Skyalker", CompType = CompensationType.Salary };

            //act
            await WhenCalculatingBenefitCostForEmployee(employee);

            //assert
            ThenTheExpectedCostWasCalculated(1000);
        }

        [Fact]
        public async Task EmployeeDependentDiscount()
        {
            //arrange
            var employee = new EmployeeDTO { FirstName = "Luke", LastName = "Skywalker", CompType = CompensationType.Salary };
            var dependent = new Dependent { FirstName = "Andy", LastName = "Skywalker" };
            employee.Dependents = new List<Dependent> { dependent };

            //act
            await WhenCalculatingBenefitCostForEmployee(employee);

            //assert
            ThenTheExpectedCostWasCalculated(1450);
        }

        [Fact]
        public async Task EmployeeDependentNoDiscount()
        {
            //arrange
            var employee = new EmployeeDTO { FirstName = "Hon", LastName = "Solo", CompType = CompensationType.Salary };
            var dependent = new Dependent { FirstName = "Ben", LastName = "Solo" };
            employee.Dependents = new List<Dependent> { dependent };

            //act
            await WhenCalculatingBenefitCostForEmployee(employee);

            //assert
            ThenTheExpectedCostWasCalculated(1500);
        }

        private async Task WhenCalculatingBenefitCostForEmployee(EmployeeDTO emp)
        {
            var calculatorFactory = new BenefitsCalculatorFactory();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>().ReverseMap();
                cfg.CreateMap<BenefitDTO, Benefit>().ReverseMap();
                
            });

            var mapper = config.CreateMapper();
            EmployeeBenefitsService service = new EmployeeBenefitsService(calculatorFactory, mapper);
            _calculatedBenefit = await service.CalculateBenefitsCost(emp);
        }

        private void ThenTheExpectedCostWasCalculated(double expectedCost)
        {
            Assert.True(_calculatedBenefit.Cost == expectedCost);
        }
    }
}
