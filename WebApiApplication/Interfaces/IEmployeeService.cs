using WebApiApplication.Models;

namespace WebApiApplication.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployees();
        public Employee GetEmployeeById(int id);

        public Employee AddNewEmployee(Employee newEmployee);

        public List<Employee> AddNewEmployeeCollection(List<Employee> employeeCollection);
        public Employee UpdateEmployee(int id, Employee newEmployee);
    }
}
