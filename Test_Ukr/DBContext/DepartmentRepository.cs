using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Ukr.Model;

namespace Test_Ukr.DBContext
{
    public class DepartmentRepository
    {
        private readonly Test_UkrContext _context;

        public DepartmentRepository(Test_UkrContext context)
        {
            _context = context;
        }

        public List<Department> GetAllDepartments()
        {
            var departments = new List<Department>();
            departments = _context.Departments.ToList();
            return departments;
        }
        public Department GetDepartment(int id) 
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == id);

            if (department == null)
                throw new ArgumentException($"Отдела с заданым id: {id} не существует");

            return department;
        }
        public void UpdateDepartment(Department department)
        {
            if (department == null)
                return;
            
            try
            {
                var dep = _context.Departments.FirstOrDefault(x => x.Id == department.Id);
                dep.Name = department.Name;
                _context.SaveChanges();
            }
            catch
            {
                throw new InvalidOperationException($"Не удалось обновить отдел {department.Id}");
            }
        }
        public void DeleteDepartment(Department department)
        {
            if (department == null)
                return;
            try
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
            catch
            {
                throw new InvalidOperationException($"Не удалось удалить отдел {department.Id}");
            }
        }
        public void CreateDepartment(Department department)
        {
            if (department == null)
                return;
            try
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            }
            catch
            {
                throw new InvalidOperationException($"Не удалось создать отдел {department.Name}");
            }
        }
    }
}
