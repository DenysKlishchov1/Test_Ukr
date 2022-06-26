using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Ukr.Model;

namespace Test_Ukr.DBContext
{
    public class EmployeeRepository
    {
        private readonly Test_UkrContext _context;
        private PositionRepository _positionRepository;
        private List<Position> _positions;
        private List<Employee> _employees;

        public EmployeeRepository(Test_UkrContext context)
        {
            _positionRepository = new PositionRepository(context);
            _positions = new List<Position>();
            _employees = new List<Employee>();
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
        public List<Employee> GetEmployeesByDepartment(Department department)
        {
            _positions.Clear();
            _positions = _positionRepository.GetPositionByDepartment(department);
            _employees.Clear();
            _employees = GetAllEmployees();

            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < _positions.Count; i++)
            {
                employees.AddRange(_employees.Where(b => b.PositionId == _positions[i].Id));
            }
            return employees;
        }
        public Employee GetEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);

            if (employee == null)
                throw new ArgumentException($"Должности с заданым id: {id} не существует");

            return employee;
        }

        public void CreateEmployee(Employee employee)
        {
            if (employee == null)
                return;
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch
            {
                throw new InvalidOperationException($"Не удалось создать работника {employee.Name} {employee.Surname}");
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            if (employee == null)
                return;

            try
            {
                var emp = _context.Employees.FirstOrDefault(x => x.Id == employee.Id);

                emp.Name = employee.Name;
                emp.Surname = employee.Surname;
                emp.Patronymic = employee.Patronymic;
                emp.PhoneNumber = employee.PhoneNumber;
                emp.Address = employee.Address;
                emp.Salary = employee.Salary;
                emp.PositionId = employee.Position.Id;
                emp.KPI = employee.KPI;
                
                _context.SaveChanges();
            }
            catch
            {
                throw new InvalidOperationException($"Не удалось обновить работника {employee.Name} {employee.Surname}");
            }
        }
    }
}
