using Models;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class EmployeeBenefitCostsTest
    {
        private readonly IEmployeeBenefitsService _employeeBenefitsServce;

        public EmployeeBenefitCostsTest()
        {
            _employeeBenefitsServce = new EmployeeBenefitsService();
        }
        [Fact]
        public async Task Employee_FirstName_Starts_With_A_Gets_DiscountAsync()
        {
            var testEmployee1 = new Employee { FirstName = "Anakin", LastName = "Skywalker"};
            var testEmployee2 = new Employee { FirstName = "Luke", LastName = "Skywalker"};

            testEmployee1 = await _employeeBenefitsServce.CalculateEmployeeBenefitsCost(testEmployee1);
            testEmployee2 = await _employeeBenefitsServce.CalculateEmployeeBenefitsCost(testEmployee2);

            Assert.True(testEmployee1.BenefitsCost < testEmployee2.BenefitsCost);
        }

        [Fact]
        public async Task Dependent_FirstName_Starts_With_A_Gets_DiscountAsync()
        {
            var testDependents1 = new List<Person>();
            var testDependents2 = new List<Person>();

            var testDependent1 = new Person { FirstName = "Ben", LastName = "Solo" };
            testDependents1.Add(testDependent1);

            var testDependent2 = new Person { FirstName = "Anakin JR", LastName = "Skywalker" };
            testDependents2.Add(testDependent2);
        
            var testEmployee1 = new Employee { FirstName = "Han", LastName = "Solo", Dependents = testDependents1 };
            var testEmployee2 = new Employee { FirstName = "Luke", LastName = "Skywalker", Dependents = testDependents2 };

            testEmployee1 = await _employeeBenefitsServce.CalculateEmployeeBenefitsCost(testEmployee1);
            testEmployee2 = await _employeeBenefitsServce.CalculateEmployeeBenefitsCost(testEmployee2);

            Assert.True(testEmployee2.BenefitsCost < testEmployee1.BenefitsCost);
        }
    }
}
