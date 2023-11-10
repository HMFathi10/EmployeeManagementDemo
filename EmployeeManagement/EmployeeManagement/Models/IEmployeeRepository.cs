namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        Employee? GetEmployee(int Id);
        IEnumerable<Employee> GetAll();
        Employee AddEmployee(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int Id);
    }
}
