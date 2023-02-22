using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareDirect.Entities
{
    public class EmployeeTask
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? TaskDoneDate { get; set; }
        public int? TaskStatusId { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual StatusTask? TaskStatus { get; set; }
    }
}
