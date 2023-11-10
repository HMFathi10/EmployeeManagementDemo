namespace EmployeeManagement.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employee;
        public EmployeeRepository()
        {
            _employee = new List<Employee>{
                new Employee { Id = 1, Name = "Ahmed", Department = Dept.CS },
                new Employee { Id = 2, Name = "Mohamed", Department = Dept.IT },
                new Employee { Id = 3, Name = "Ali", Department = Dept.IS }};
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _employee.Max(x => x.Id) + 1;
            _employee.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employee;
        }

        public Employee? GetEmployee(int Id)
        {
            return _employee.FirstOrDefault(e => e.Id == Id);
        }
        public Employee Delete(int Id)
        {
            Employee employee = _employee.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                _employee.Remove(employee);
            }
            return employee;
        }
        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employee.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }
    }
}
