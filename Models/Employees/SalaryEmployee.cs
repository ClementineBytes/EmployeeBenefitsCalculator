using Models.Payroll;
using System.Collections.Generic;

namespace Models.Employees
{
    public class SalaryEmployee : IEmployee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CompensationType CompType => CompensationType.Salary;
        public Benefit Benefits { get; set; }
        public decimal AnnualSalary { get; set; }
        public int NumberOfPaychecksAYear { get; set; }
        public List<Dependent> Dependents { get; set; }

    }
}
