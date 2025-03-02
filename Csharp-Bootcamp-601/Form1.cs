using Csharp_Bootcamp_601.Entities;
using Csharp_Bootcamp_601.Services;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CustomerOperations customerOperations = new CustomerOperations();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                customerName = txtCustomerName.Text,
                customerSurname = txtCustomerSurname.Text,
                customerCity = txtCustomerCity.Text,
                customerBalance = decimal.Parse(txtCustomerBalance.Text),
                customerShoppingTotal = int.Parse(txtShoppingTotal.Text)
            };

            customerOperations.AddCustomer(customer);
            List<Customer> customers = customerOperations.GetAllCustomers();
            dataGridView1.DataSource = customers;
            txtID.Text = "";
            txtCustomerName.Text = "";
            txtCustomerSurname.Text = "";
            txtCustomerCity.Text = "";
            txtCustomerBalance.Text = "";
            txtShoppingTotal.Text = "";
            MessageBox.Show("Müşteri Ekleme İşlemi Başarılı...");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<Customer> customers = customerOperations.GetAllCustomers();
            dataGridView1.DataSource = customers;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string customerId = txtID.Text;
            customerOperations.DeleteCustomer(customerId);
            List<Customer> customers = customerOperations.GetAllCustomers();
            dataGridView1.DataSource = customers;
            txtID.Text = "";
            MessageBox.Show("Müşteri başarıyla silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            var updateCustomer = new Customer()
            {
                customerName = txtCustomerName.Text,
                customerBalance = decimal.Parse(txtCustomerBalance.Text),
                customerCity = txtCustomerCity.Text,
                customerShoppingTotal = int.Parse(txtShoppingTotal.Text),
                customerSurname = txtCustomerSurname.Text,
                customerID = id
            };
            customerOperations.UpdateCustomer(updateCustomer);
            List<Customer> customers = customerOperations.GetAllCustomers();
            dataGridView1.DataSource = customers;
            MessageBox.Show("Müşteri başarıyla güncellendi");
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            Customer customers = customerOperations.GetCustomerById(id);
            dataGridView1.DataSource = new List<Customer> { customers };
            txtID.Text = "";
        }
    }
}
