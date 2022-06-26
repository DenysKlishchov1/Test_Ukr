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
    public partial class AddEmployeeForm : Form
    {
        private Test_UkrContext context;
        private EmployeeRepository employeeRepository;
        private PositionRepository positionRepository;
        private DepartmentRepository departmentRepository;

        private Employee _employee;
        public AddEmployeeForm()
        {
            context = new Test_UkrContext();
            employeeRepository = new EmployeeRepository(context);
            positionRepository = new PositionRepository(context);
            departmentRepository = new DepartmentRepository(context);
            InitializeComponent();
        }

        public AddEmployeeForm(Employee employee)
        {
            _employee = employee;
            context = new Test_UkrContext();
            positionRepository = new PositionRepository(context);
            employeeRepository = new EmployeeRepository(context);
            departmentRepository = new DepartmentRepository(context);
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee {
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Patronymic = textBoxPatronymic.Text,
                PhoneNumber = textBoxPhoneNumber.Text,
                Address = textBoxAddress.Text,
                Salary = Convert.ToDecimal(textBoxSalary.Text),
                Position = (Position)comboBoxPosition.SelectedItem,
                KPI = comboBoxKpi.SelectedItem.ToString()
                
            };
            employeeRepository.CreateEmployee(employee);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPosition.Items.Clear();

            var selected = (Department)comboBoxDepartment.SelectedItem;

            List<Position> positionList = new List<Position>();
            positionList = positionRepository.GetAllPositions();

            foreach (Position position in positionList)
            {
                if(position.DepartmentId == selected.Id)
                {
                    comboBoxPosition.Items.Add(position);
                }
            }
            
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            if (_employee != null)
            {
                btnUpdate.Visible = true;
                btnAdd.Visible = false;
                btnAdd.Enabled = false;
                textBoxName.Text = _employee.Name;
                textBoxSurname.Text = _employee.Surname;
                textBoxPatronymic.Text = _employee.Patronymic;
                textBoxPhoneNumber.Text = _employee.PhoneNumber;
                textBoxAddress.Text = _employee.Address;
                textBoxSalary.Text = _employee.Salary.ToString();
                comboBoxDepartment.Items.Clear();
                comboBoxDepartment.Items.Add(departmentRepository.GetDepartment(_employee.Position.DepartmentId));
                comboBoxDepartment.SelectedIndex = 0;
                AddItemsCBDepartment();
                comboBoxPosition.Items.Clear();
                comboBoxPosition.Items.Add(_employee.Position);
                comboBoxPosition.SelectedIndex = 0;
                comboBoxKpi.Items.Clear();
                comboBoxKpi.Items.Add(_employee.KPI);
                comboBoxKpi.SelectedIndex = 0;
            }
            else
            {
                btnUpdate.Visible = false;
                AddItemsCBDepartment();
            }
            comboBoxKpi.Items.AddRange(new string[] { "A", "B", "C" });
        }


        private void AddItemsCBDepartment()
        {
            List<Department> departmentsList = new List<Department>();
            departmentsList = departmentRepository.GetAllDepartments();
            foreach (var item in departmentsList)
            {
                comboBoxDepartment.Items.Add(item);
            }
        }

        private void textBoxSalary_TextChanged(object sender, EventArgs e)
        {
            if(!double.TryParse(textBoxSalary.Text, out var salary)) 
            {
                MessageBox.Show("Неверно введены данные в строку з/п");
                textBoxSalary.Text = string.Empty;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _employee.Name = textBoxName.Text;
            _employee.Surname = textBoxSurname.Text;
            _employee.Patronymic = textBoxPatronymic.Text;
            _employee.PhoneNumber = textBoxPhoneNumber.Text;
            _employee.Address = textBoxAddress.Text;
            _employee.Salary = Convert.ToDecimal(textBoxSalary.Text);
            _employee.Position = (Position)comboBoxPosition.SelectedItem;
            _employee.KPI = comboBoxKpi.SelectedItem.ToString();
            employeeRepository.UpdateEmployee(_employee);
            MessageBox.Show("ok");
            Close();
        }
    }
}
