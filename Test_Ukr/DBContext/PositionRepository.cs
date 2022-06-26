using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Ukr.Model;

namespace Test_Ukr.DBContext
{
    public class PositionRepository
    {
        private readonly Test_UkrContext _context;

        public PositionRepository(Test_UkrContext context)
        {
            _context = context;
        }

        public List<Position> GetAllPositions()
        {
            return _context.Positions.ToList();
        }

        public List<Position> GetPositionByDepartment(Department department)
        {
            List<Position> positions = new List<Position>();
            positions = GetAllPositions();
            return positions.Where(x => x.DepartmentId == department.Id).ToList();
        }

        public Position GetPosition(int id)
        {
            var position = _context.Positions.FirstOrDefault(x => x.Id == id);

            if (position == null)
                throw new ArgumentException($"Должности с заданым id: {id} не существует");

            return position;
        }

        public void CreatePosition(Position position)
        {
            if (position == null)
                return;
            try
            {
                _context.Positions.Add(position);
                _context.SaveChanges();
            }
            catch
            {
                throw new InvalidOperationException($"Не удалось создать должность {position.Name}");
            }
        }

        public void DeletePosition(Position position)
        {
            if (position == null)
                return;
            try
            {
                _context.Positions.Remove(position);
                _context.SaveChanges();
            }
            catch
            {
                throw new InvalidOperationException($"Не удалось удалить должность {position.Id}");
            }
        }

        public void UpdatePosition(Position position)
        {
            if (position == null)
                return;

            try
            {
                var pos = _context.Positions.FirstOrDefault(x => x.Id == position.Id);
                pos.Name = position.Name;
                pos.Department = position.Department;
                _context.SaveChanges();
            }
            catch
            {
                throw new InvalidOperationException($"Не удалось обновить должность {position.Id}");
            }
        }
    }
}
