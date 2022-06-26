using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ukr.Model
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        public ICollection<Position> Positions { get; set; } = new List<Position>();

        public override string ToString()
        {
            return Name;
        }
    }
}
