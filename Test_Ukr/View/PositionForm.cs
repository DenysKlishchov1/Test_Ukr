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
    public partial class PositionForm : Form
    {
        private List<Department> departmentsList;
        private List<Position> positionsList;

        private Test_UkrContext test_UkrContext;
        private DepartmentRepository departmentRepository;
        private PositionRepository positionRepository;
        public PositionForm()
        {
            departmentsList = new List<Department>();
            positionsList = new List<Position>();

            test_UkrContext = new Test_UkrContext();
            departmentRepository = new DepartmentRepository(test_UkrContext);
            positionRepository = new PositionRepository(test_UkrContext);
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedPosition = dataGridView1.SelectedRows[0].DataBoundItem as Position;
                textBoxId.Text = selectedPosition.Id.ToString();
                textBoxPosition.Text = selectedPosition.Name;
                departmentsList = departmentRepository.GetAllDepartments();
                comboBoxDepartment.Items.Clear();
                foreach(var department in departmentsList)
                {
                    comboBoxDepartment.Items.Add(department);
                }
                comboBoxDepartment.Text = selectedPosition.Department.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var position = positionRepository.GetPosition(Convert.ToInt32(textBoxId.Text));
            if (position == null)
            {
                MessageBox.Show("Должность не найдена!");
                return;
            }
            position.Name = textBoxPosition.Text;
            position.Department = comboBoxDepartment.SelectedItem as Department;
            positionRepository.UpdatePosition(position);
            RefreshDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var position = positionRepository.GetPosition(Convert.ToInt32(textBoxId.Text));
            if (position == null)
            {
                MessageBox.Show("Должность уже удалена!");
                return;
            }
            positionRepository.DeletePosition(position);
            RefreshDataGrid();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            AddPosition addPosition = new AddPosition();
            addPosition.ShowDialog();
            RefreshDataGrid();
        }

        private void PositionForm_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }



        private void RefreshDataGrid()
        {
            positionsList = positionRepository.GetAllPositions();
            departmentsList = departmentRepository.GetAllDepartments();

            for(int i = 0; i < positionsList.Count; i++)
            {
                var dep = departmentsList.FirstOrDefault(x => x.Id == positionsList[i].DepartmentId);
                positionsList[i].DepartmentName = dep.Name;
            }

            dataGridView1.DataSource = positionsList;

            dataGridView1.Columns["DepartmentId"].Visible = false;
            dataGridView1.Columns["Department"].Visible = false;
            dataGridView1.Columns["Employees"].Visible = false;
        }
    }
}
