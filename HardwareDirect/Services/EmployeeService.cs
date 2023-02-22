using HardwareDirect.Entities;
using HardwareDirect.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareDirect.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ExerciseDbContext _dbContext;

        public EmployeeService(ExerciseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EmployeesListViewModel GetEmployeesListViewModel()
        {
            EmployeesListViewModel model = new EmployeesListViewModel
            {
                Employees = _dbContext.Employees.ToList(),
                Positions = _dbContext.Positions.ToList()
            };

            return model;
        }

        public async Task<int> CreateEmployeeAsync(Employee employee)
        {
            try
            {
                await _dbContext.Employees.AddAsync(employee);
                await _dbContext.SaveChangesAsync();

                return employee.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create employee", ex);
            }
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new ArgumentException($"Employee with id {id} not found");
            }

            _dbContext.Employees.Remove(employee);

            await _dbContext.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new ArgumentException($"Employee with id {id} not found");
            }

            return employee;
        }

    }
}