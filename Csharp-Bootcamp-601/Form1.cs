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
            MessageBox.Show("Müşteri Ekleme İşlemi Başarılı...");
        }
    }
}
