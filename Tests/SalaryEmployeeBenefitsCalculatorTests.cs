using Models;
using Models.Employees;
using Models.Payroll;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class SalaryEmployeeBenefitsCalculatorTests
    {
        private double _calculatedCost = 0;

        [Fact]
        public async Task EmployeeFirstNameDiscount() 
        {
            //arrange
            var employee = new SalaryEmployee { FirstName = "Anakin", LastName = "Skywalker" };

            //act
            WhenCalculatingBenefitCostForEmployee(employee);

            //assert
            ThenTheExpectedCostWasCalculated(900);
        }

        [Fact]
        public async Task EmployeeFirstNameNoDiscount()
        {
            //arrange
            var employee = new SalaryEmployee { FirstName = "Luke", LastName = "Skyalker" };

            //act
            WhenCalculatingBenefitCostForEmployee(employee);

            //assert
            ThenTheExpectedCostWasCalculated(1000);
        }

        [Fact]
        public async Task EmployeeDependentDiscount()
        {
            //arrange
            var employee = new SalaryEmployee { FirstName = "Luke", LastName = "Skywalker" };
            var dependent = new Dependent { FirstName = "Andy", LastName = "Skywalker" };
            employee.Dependents = new List<Dependent> { dependent };

            //act
            WhenCalculatingBenefitCostForEmployee(employee);

            //assert
            ThenTheExpectedCostWasCalculated(1450);
        }

        [Fact]
        public async Task EmployeeDependentNoDiscount()
        {
            //arrange
            var employee = new SalaryEmployee { FirstName = "Hon", LastName = "Solo" };
            var dependent = new Dependent { FirstName = "Ben", LastName = "Solo" };
            employee.Dependents = new List<Dependent> { dependent };

            //act
            WhenCalculatingBenefitCostForEmployee(employee);

            //assert
            ThenTheExpectedCostWasCalculated(1500);
        }

        private void WhenCalculatingBenefitCostForEmployee(IEmployee emp)
        {
            SalaryEmployeeBenefitsCalculator calculator = new SalaryEmployeeBenefitsCalculator();
            _calculatedCost = calculator.CalculateBenefitsCost(emp);
        }

        private void ThenTheExpectedCostWasCalculated(double expectedCost)
        {
            Assert.True(_calculatedCost == expectedCost);
        }
    }
}
