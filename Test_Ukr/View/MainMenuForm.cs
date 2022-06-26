using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Ukr.DBContext;
using Test_Ukr.Model;

namespace Test_Ukr.View
{
    public partial class MainMenuForm : Form
    {
        private List<Employee> employeesList;
        private List<Position> positionsList;
        private List<Department> departmensList;

        private Test_UkrContext context;
        private EmployeeRepository employeeRepo;
        private PositionRepository positionRepo;
        private DepartmentRepository departmentRepo;


        public MainMenuForm()
        {
            employeesList = new List<Employee>();
            positionsList = new List<Position>();
            departmensList = new List<Department>();

            context = new Test_UkrContext();
            employeeRepo = new EmployeeRepository(context);
            positionRepo = new PositionRepository(context);
            departmentRepo = new DepartmentRepository(context);

            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
            comboBoxItems();
            labelPayments.Text = String.Empty;
        }

        #region dataGridEmloyee
        private void dataGridEmloyee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedEmployee = dataGridEmloyee.SelectedRows[0].DataBoundItem as Employee;
                AddEmployeeForm addEmployee = new AddEmployeeForm(selectedEmployee);
                addEmployee.ShowDialog();
                RefreshDataGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RefreshDataGrid()
        {
            employeesList.Clear();
            positionsList.Clear();
            departmensList.Clear();

            employeesList = employeeRepo.GetAllEmployees();
            positionsList = positionRepo.GetAllPositions();
            departmensList = departmentRepo.GetAllDepartments();

            for(int i = 0; i < employeesList.Count; i++)
            {
                var pos = positionsList.FirstOrDefault(x => x.Id == employeesList[i].PositionId);
                var dep = departmensList.FirstOrDefault(y => y.Id == pos.DepartmentId);

                employeesList[i].PositionName = pos.ToString();
                employeesList[i].DepartmentName = dep.ToString();
            }
            
            dataGridEmloyee.DataSource = null;
            dataGridEmloyee.DataSource = employeesList;
            
            dataGridEmloyee.Columns["PositionId"].Visible = false;
            dataGridEmloyee.Columns["Position"].Visible = false;
            dataGridEmloyee.Columns["Id"].Visible = false;
        }
        private void dataGridEmloyee_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region btnDepartment
        private void btnDepartment_Click(object sender, EventArgs e)
        {
            DepartmentForm departmentForm = new DepartmentForm();
            departmentForm.Show();
        }
        #endregion

        #region btnPosition
        private void btnPosition_Click(object sender, EventArgs e)
        {
            PositionForm positionForm = new PositionForm();
            positionForm.Show();
        }
        #endregion

        #region btnCreateEmlpoyee
        private void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.ShowDialog();
        }
        #endregion

        #region ComboBoxPayments/Filter 
        private void comboBoxItems()
        {
            departmensList.Clear();


            departmensList = departmentRepo.GetAllDepartments();
            comboBoxPayments.Items.Clear();
            comboBoxPayments.Items.Add(new Department { Name = "Все отделы" });
            comboBoxFilter.Items.Add(new Department { Name = "Сбросить фильтр" });
            foreach (var department in departmensList)
            {
                comboBoxPayments.Items.Add(department);
                comboBoxFilter.Items.Add(department);
            }
        }
        private void comboBoxPayments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department depart = comboBoxPayments.SelectedItem as Department;

            decimal result = 0;
            if (depart.Name == "Все отделы")
            {
                employeesList.Clear();
                employeesList = employeeRepo.GetAllEmployees();
                foreach(Employee employee in employeesList)
                {
                    result += employee.Salary;
                }
                labelPayments.Text = result.ToString();

                return;
            }

            List<Employee> employees = new List<Employee>();
            employees = employeeRepo.GetEmployeesByDepartment(depart);
            
            foreach (Employee employee in employees)
            {
                result += employee.Salary;
            }
            labelPayments.Text = result.ToString();
        }
        #endregion

        #region btnFilter
        private void btnFilter_Click(object sender, EventArgs e)
        {
            Department depart = comboBoxFilter.SelectedItem as Department;
            if(depart.Name == "Сбросить фильтр")
            {
                RefreshDataGrid();
                return;
            }

            employeesList.Clear();
            employeesList = employeeRepo.GetEmployeesByDepartment(depart);
            
            dataGridEmloyee.DataSource = employeesList;
        }
        #endregion

        #region btnRefresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
        #endregion


        private async void btnReport_Click(object sender, EventArgs e)
        {
            if(dialogForReport.ShowDialog() == DialogResult.OK)
            {
                string path = dialogForReport.SelectedPath;
                path += "\\Report.txt";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                employeesList.Clear();
                employeesList = employeeRepo.GetAllEmployees();
                positionsList = positionRepo.GetAllPositions();
                departmensList = departmentRepo.GetAllDepartments();
                for (int i = 0; i < employeesList.Count; i++)
                {
                    var pos = positionsList.FirstOrDefault(x => x.Id == employeesList[i].PositionId);
                    var dep = departmensList.FirstOrDefault(y => y.Id == pos.DepartmentId);

                    employeesList[i].PositionName = pos.ToString();
                    employeesList[i].DepartmentName = dep.ToString();
                }
                try
                {
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        StringBuilder builder = new StringBuilder();
                        foreach (Employee employee in employeesList)
                        {
                            decimal award = employee.KPI == "A" ? employee.Salary * 0.2m :
                                employee.KPI == "B" ? employee.Salary * 0.3m :
                                employee.KPI == "C" ? employee.Salary * 0.4m : 0;
                            builder.AppendLine(
                                employee.Name + " " +
                                employee.Surname + " " +
                                employee.Patronymic + " " +
                                employee.PhoneNumber + " " +
                                employee.Address + " " +
                                employee.PositionName + " " +
                                employee.DepartmentName + " " +
                                employee.KPI + " " +
                                employee.Salary + " " +
                                award
                                );
                        }
                        await writer.WriteLineAsync(builder.ToString());
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show($"Отчет сформирован \n{path}");
            }
        }
    }
}
