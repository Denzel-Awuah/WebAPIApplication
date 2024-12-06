using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiApplication.Data;
using WebApiApplication.Interfaces;
using WebApiApplication.Models;
using WebApiApplication.Models.DTOs;

namespace WebApiApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        //Services
        private IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //GET: api/Employees
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        //GET: api/Employees/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
             
            if(employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        //POST: api/Employees
        [HttpPost]  
        public IActionResult AddNewEmployee([FromBody] AddEmployeeDto addEmployeeDto) 
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            var newEmployee = _employeeService.AddNewEmployee(employeeEntity);

            return Ok(newEmployee);
            
        }

        
        [HttpPost("collection")]
        public IActionResult AddNewEmployees([FromBody] List<Employee> employeesCollection)
        {
           
            var newEmployees = _employeeService.AddNewEmployeeCollection(employeesCollection);

            return Ok(employeesCollection);

        }

        //PUT: api/Employees/{id}
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmployee([FromRoute] int id,[FromBody] UpdateEmployeeDto updateEmployeeDto) 
        {
            var employee = _employeeService.GetEmployeeById(id);

            if(employee == null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            _employeeService.UpdateEmployee(id, employee);

            return Ok(employee);
        }

        //DELETE: api/Employee/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee()
        {
            return NotFound();
        }
    }
}
