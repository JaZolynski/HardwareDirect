using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareDirect.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public virtual List<EmployeeTask> EmployeeTask { get; set; }
    }
}
