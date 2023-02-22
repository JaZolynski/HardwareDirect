using HardwareDirect.Entities;
using HardwareDirect.Models;
using HardwareDirect.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HardwareDirect.Controllers
{
    [Route("task")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<StatusTask>> GetAllStatuses()
        {
            var statuses = _taskService.GetAllStatuses();
            return Ok(statuses.Result);
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody] EmployeeTask employeeTask)
        {
            try
            {
                await _taskService.CreateTaskAsync(employeeTask);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTasksByEmployeeId")]
        public ActionResult<IEnumerable<EmployeeTask>> GetByEmployeeId(int employeeId)
        {
            var tasks = _taskService.GetEmployeeTasksAsync(employeeId);
            return Ok(tasks.Result);
        }
    }
}