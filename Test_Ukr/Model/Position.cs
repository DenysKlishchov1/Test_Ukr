using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ukr.Model
{
    public class Position
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }


        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        [NotMapped]
        public string DepartmentName { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
