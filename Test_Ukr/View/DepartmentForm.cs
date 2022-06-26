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
    public partial class DepartmentForm : Form
    {
        private List<Department> departmentsList;
        private Test_UkrContext test_UkrContext;
        private DepartmentRepository repository;
        public DepartmentForm()
        {
            departmentsList = new List<Department>();

            test_UkrContext = new Test_UkrContext();
            repository = new DepartmentRepository(test_UkrContext);

            InitializeComponent();
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            departmentsList = repository.GetAllDepartments();
            dataGridDepartment.DataSource = departmentsList;
            //dataGridDepartment.Columns["Id"].Visible = false;
            dataGridDepartment.Columns["Name"].Width = 278;
            dataGridDepartment.Columns["Positions"].Visible = false;
            dataGridDepartment.Columns["Id"].Visible = false;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var department = repository.GetDepartment(Convert.ToInt32(textBoxId.Text));
            if (department == null)
            {
                MessageBox.Show("Отдел не найден!");
                return;
            }
            department.Name = textBoxName.Text;
            repository.UpdateDepartment(department);
            RefreshDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var department = repository.GetDepartment(Convert.ToInt32(textBoxId.Text));
            if (department == null)
            {
                MessageBox.Show("Отдел уже удален!");
                return;
            }
            repository.DeleteDepartment(department);
            RefreshDataGrid();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            AddDepartmentForm addDepartment = new AddDepartmentForm();
            addDepartment.ShowDialog();
            RefreshDataGrid();
        }

        private void dataGridDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                var selectedDepartment = dataGridDepartment.SelectedRows[0].DataBoundItem as Department;
                textBoxId.Text = selectedDepartment.Id.ToString();
                textBoxName.Text = selectedDepartment.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
    }
}
