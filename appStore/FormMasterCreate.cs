using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Response;
using System.Text.RegularExpressions;

namespace appStore
{
    public partial class FormMasterCreate : Form
    {
        public FormMasterCreate()
        {
            InitializeComponent();
        }


        private bool checkValidInput()
        {
            string name = txbName.Text;
            string amount = txbTotalAmount.Text;
            string rate = txbRate.Text;
            string type = txbType.Text;

            if (name == "" || amount == "" || rate == "" || type == "")
            {
                MessageBox.Show("Some field is missing");
                return false;
            }


            Regex textReg = new Regex(@"[a-zA-Z0-9_]+"),
                numReg = new Regex(@"\d+");

            if (!textReg.IsMatch(name))
            {
                MessageBox.Show("Invalid name");
                return false;
            }

            if (!numReg.IsMatch(amount))
            {
                MessageBox.Show("Invalid amount");
                return false;
            }

            if (!numReg.IsMatch(rate))
            {
                MessageBox.Show("Invalid rate");
                return false;
            }

            if (!textReg.IsMatch(type))
            {
                MessageBox.Show("Invalid type");
                return false;

            }

            return true;
        }
       
        private async void btnCheckCreate_Click(object sender, EventArgs e)
        {
            if (!checkValidInput())
            {
                return;
            }

            Counter count = new Counter();
            var data = new Product
            {
                deleted = "false",
                name = txbName.Text,
                rate = txbRate.Text,
                saleAmount = "0",
                totalAmount = txbTotalAmount.Text,
                type = txbType.Text
            };
            HTTPRequest.setDataProduct(data);
            
           
        }
    }
}
