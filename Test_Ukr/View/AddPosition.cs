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
    public partial class AddPosition : Form
    {
        PositionRepository PositionRepository;
        Test_UkrContext context;
        DepartmentRepository departmentRepository;
        public AddPosition()
        {
            context = new Test_UkrContext();
            PositionRepository = new PositionRepository(context);
            departmentRepository = new DepartmentRepository(context);

            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Position position = new Position();
            position.Name = textBoxNamePos.Text;


            position.Department = (Department)comboBoxDepartment.SelectedItem;

            PositionRepository.CreatePosition(position);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ItemsComboBox()
        {
            List<Department> departmentsList = new List<Department>();
            departmentsList = departmentRepository.GetAllDepartments();
            foreach(var item in departmentsList)
            {
                comboBoxDepartment.Items.Add(item);
            }
            //comboBoxDepartment.Items.AddRange(departmentsList);
        }

        private void AddPosition_Load(object sender, EventArgs e)
        {
            ItemsComboBox();
        }
    }
}
