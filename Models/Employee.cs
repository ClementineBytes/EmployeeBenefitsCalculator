using System.Collections.Generic;

namespace Models
{
    public class Employee : Person
    {
        public int ID { get; set; }
        public decimal AnnualSalary { get; set; }
        public int NumberOfPaychecksAYear { get; set; }
        public List<Person> Dependents { get; set; }
        public decimal BenefitsCost { get; set; }
    }
}
