using Microsoft.AspNetCore.Mvc;
using POC_SignalR.Model;
using POC_SignalR.Service;
using System.Collections.Generic;

namespace POC_SignalR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("add")]
        public void AddEmployee([FromBody] Employee employee)
        {
            _employeeService.AddEmployee(employee);
        }

        [HttpPost]
        [Route("update")]
        public void UpdateEmployee([FromBody] Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public void DeleteEmployee([FromRoute] int id)
        {
            _employeeService.DeleteEmployee(id);
        }

        [HttpGet]
        [Route("get")]
        public List<Employee> GetEmployee()
        {
            return _employeeService.GetEmployees();
        }
    }
}
