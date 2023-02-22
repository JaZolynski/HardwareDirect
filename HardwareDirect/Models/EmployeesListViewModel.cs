using HardwareDirect.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareDirect.Models
{
    public class EmployeesListViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<Position> Positions { get; set; }
    }
}
