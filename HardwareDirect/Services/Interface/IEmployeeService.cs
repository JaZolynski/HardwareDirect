using HardwareDirect.Entities;
using HardwareDirect.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HardwareDirect.Services
{
    public interface IEmployeeService
    {
        public EmployeesListViewModel GetEmployeesListViewModel();
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<int> DeleteEmployeeAsync(int id);
        Task<int> CreateEmployeeAsync(Employee employee);
    }
}