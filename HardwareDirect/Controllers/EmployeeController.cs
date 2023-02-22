using HardwareDirect.Entities;
using HardwareDirect.Models;
using HardwareDirect.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareDirect.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            EmployeesListViewModel model = _employeeService.GetEmployeesListViewModel();
            return View(model);
        }

        [HttpPost]
        [Route("Employee/CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                await _employeeService.CreateEmployeeAsync(employee);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<int> DeleteEmployeeAsync(int id)
        {
            int deletedEmployeeId = await _employeeService.DeleteEmployeeAsync(id);

            return deletedEmployeeId;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            var employees = _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet]
        [Route("getById")]
        public ActionResult<IEnumerable<Employee>> GetById([FromQuery] int employeeId)
        {
            var employee = _employeeService.GetEmployeeByIdAsync(employeeId);
            return Ok(employee);
        }

    }
}
