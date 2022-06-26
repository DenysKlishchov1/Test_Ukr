using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Ukr.Model;

namespace Test_Ukr.DBContext
{
    public class Test_UkrContext : DbContext
    {
        public Test_UkrContext() : base("name = connectionString")
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
