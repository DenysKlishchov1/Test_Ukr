using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ukr.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(80)]
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [MaxLength(1)]
        public string KPI { get; set; }
        [Required]
        public decimal Salary { get; set; }

        
        public int PositionId { get; set; }
        public Position Position { get; set; }

        [NotMapped]
        public string PositionName { get; set; }
        [NotMapped]
        public string DepartmentName { get; set; }
    }
}
