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
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }
        string connectionLink = "server=localhost;port=5432;Database=customer;user Id=postgres;password=1";
        void GetAllCustomers()
        {
            var connection = new NpgsqlConnection(connectionLink);
            connection.Open();
            string query = "select * from customers order by customerId";
            var command = new NpgsqlCommand(query,connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            dataGridView1.DataSource = datatable;
            connection.Close();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            GetAllCustomers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string customerSurname = txtCustomerSurname.Text;
            string customerCity = txtCustomerCity.Text;
            var connection = new NpgsqlConnection(connectionLink);
            connection.Open();
            string query = "insert into customers (customername,customersurname,customercity) values (@customerName,@customerSurname,@customerCity)";
            var command = new NpgsqlCommand(query,connection);
            command.Parameters.AddWithValue("@customerName", customerName);
            command.Parameters.AddWithValue("@customerSurname", customerSurname);
            command.Parameters.AddWithValue("@customerCity", customerCity);
            command.ExecuteNonQuery();
            connection.Close();
            GetAllCustomers();
            MessageBox.Show("Ekleme işlemi Tamamlandı...");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var connection = new NpgsqlConnection(connectionLink);
            connection.Open();
            string query = "delete from customers where customerId=@customerId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId",id);
            command.ExecuteNonQuery();
            connection.Close();
            GetAllCustomers();
            MessageBox.Show("Silme işlemi Tamamlandı...");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string customerName = txtCustomerName.Text;
            string customerSurname = txtCustomerSurname.Text;
            string customerCity = txtCustomerCity.Text;
            var connection = new NpgsqlConnection(connectionLink);
            connection.Open();
            string query = "update customers set customername=@customerName,customersurname=@customerSurname,customercity=@customerCity where customerId=@customerId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", id);
            command.Parameters.AddWithValue("@customerName", customerName);
            command.Parameters.AddWithValue("@customerSurname", customerSurname);
            command.Parameters.AddWithValue("@customerCity", customerCity);
            command.ExecuteNonQuery();
            connection.Close();
            GetAllCustomers();
            MessageBox.Show("Güncelleme işlemi Tamamlandı...");
        }
    }
}
