using Microsoft.AspNetCore.Mvc;
using WebApiApplication.Data;
using WebApiApplication.Interfaces;
using WebApiApplication.Models;

namespace WebApiApplication.Service
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationDbContext _dbContext;

        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee AddNewEmployee(Employee newEmployee)
        {
            _dbContext.Employees.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }
        public List<Employee> AddNewEmployeeCollection(List<Employee> employeeCollection)
        {
            _dbContext.Employees.AddRange(employeeCollection);
            _dbContext.SaveChanges();
            return employeeCollection;
        }


        public Employee GetEmployeeById(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            return employee;
        }

        public Employee UpdateEmployee(int id, Employee newEmployee)
        {
            _dbContext.SaveChanges();
            return newEmployee;
        }


    }
}
