using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Ukr.DBContext;
using Test_Ukr.Model;

namespace Test_Ukr.View
{
    public partial class AddDepartmentForm : Form
    {
        private Test_UkrContext test_UkrContext;
        private DepartmentRepository repository;

        public AddDepartmentForm()
        {
            test_UkrContext = new Test_UkrContext();
            repository = new DepartmentRepository(test_UkrContext);
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department.Name = textBoxName.Text;
            repository.CreateDepartment(department);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
