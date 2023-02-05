using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollAdo.Net
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime startDate { get; set; }
        public char Gender { get; set; }
        public string Department { get; set; }
        public long PhoneNumber { get; set; }
        public string Address
        {
            get; set;
        }
    }
}
