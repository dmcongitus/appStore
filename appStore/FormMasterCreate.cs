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
namespace appStore
{
    public partial class FormMasterCreate : Form
    {
        public FormMasterCreate()
        {
            InitializeComponent();
        }

       
        private async void btnCheckCreate_Click(object sender, EventArgs e)
        {
            Counter count = new Counter();
            var data = new productData
            {
                deleted = "false",
                name = txbName.Text,
                rate = txbRate.Text,
                saleAmount = "0",
                totalAmount = txbTotalAmount.Text,
                type = txbType.Text
            };
            count = await Counter.getSizeData();
            var client = HTTPRequest.getInstance();
            Counter.updateCounter("product");
            SetResponse response = await client.SetTaskAsync("product/" + count.countProduct, data);
            // productData dataResult = response.ResultAs<productData>();
            
            MessageBox.Show("Add Data Oke", count.countProduct);

        }
    }
}
