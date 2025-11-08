using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Payroll
{
    public class Compensation
    {
        public CompensationType Type { get; set; }
        public Benefit Benefits { get; set; }
        public int PaychecksAYear { get; set; }
    }
}
