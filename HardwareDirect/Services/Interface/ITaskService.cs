using HardwareDirect.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HardwareDirect.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<StatusTask>> GetAllStatuses();
        Task CreateTaskAsync(EmployeeTask employeeTask);
        Task<IEnumerable<EmployeeTask>> GetEmployeeTasksAsync(int employeeId);
    }
}