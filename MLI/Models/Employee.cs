using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public DateTime Hierdate { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
    }
}
