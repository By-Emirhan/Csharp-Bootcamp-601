using MongoDB.Driver.Core.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_Bootcamp_601
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        string connectionLink = "server=localhost;port=5432;Database=customer;user Id=postgres;password=1";

        void EmployeeList()
        {
            var connection = new NpgsqlConnection(connectionLink);
            connection.Open();
            string query = "select * from employees";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            dataGridView1.DataSource = datatable;
            connection.Close();
        }
        
        void DepartmentList()
        {
            var connection = new NpgsqlConnection(connectionLink);
            connection.Open();
            string query = "select * from departments";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            cmbDepartment.DisplayMember= "departmentname";
            cmbDepartment.ValueMember = "departmentid";
            cmbDepartment.DataSource = datatable;
            connection.Close();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            EmployeeList();
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            DepartmentList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string employeeName = txtEmployeeName.Text;
            string employeeSurname = txtEmployeeSurname.Text;
            decimal employeeSalary = decimal.Parse(txtEmployeeSalary.Text);
            int departmentId = int.Parse(cmbDepartment.SelectedValue.ToString());

            var connection = new NpgsqlConnection(connectionLink);
            connection.Open();
            string query = "insert into Employees (EmployeeName, EmployeeSurname, EmployeeSalary, Departmentid) values (@employeeName, @employeeSurname, @employeeSalary, @departmentid)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@employeeName", employeeName);
            command.Parameters.AddWithValue("@employeeSurname", employeeSurname);
            command.Parameters.AddWithValue("@employeeSalary", employeeSalary);
            command.Parameters.AddWithValue("@departmentid", departmentId);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme işlemi başarılı!");
            connection.Close();
            EmployeeList();
        }
    }
}