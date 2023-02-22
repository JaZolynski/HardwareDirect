using HardwareDirect.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareDirect.Services
{
    public class TaskService : ITaskService
    {
        private readonly ExerciseDbContext _dbContext;

        public TaskService(ExerciseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<StatusTask>> GetAllStatuses()
        {
            var statuses = await _dbContext.TaskStatuses.ToListAsync();
            return statuses;
        }

        public async Task CreateTaskAsync(EmployeeTask employeeTask)
        {
            try
            {
                await _dbContext.EmplooyeesTasks.AddAsync(employeeTask);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating task: " + ex.Message);
            }
        }

        public async Task<IEnumerable<EmployeeTask>> GetEmployeeTasksAsync(int employeeId)
        {
            var result = await _dbContext.EmplooyeesTasks
                .Include(et => et.TaskStatus)
                .Where(et => et.EmployeeId == employeeId)
                .ToListAsync();

            return result;
        }
    }
}