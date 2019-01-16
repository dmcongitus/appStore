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
    public partial class FormMasterUpdate : Form
    {
        public FormMasterUpdate()
        {
            InitializeComponent();
        }

        private async void btnCheckUpdate_Click(object sender, EventArgs e)
        {
            Counter count = new Counter();
            var data = new productData();

            count = await Counter.getSizeData();
            string idInput = txbID.Text;
            if(Convert.ToInt32(idInput)<1  || Convert.ToInt32(idInput) > Convert.ToInt32(count.countProduct)){
                MessageBox.Show("ID khong hop le");
            }
            else
            {
                var client = HTTPRequest.getInstance();
                var newData = new productData
                {
                    name = txbName.Text,
                    type = txbType.Text,
                    saleAmount = txbSaleAmount.Text,
                    totalAmount = txbTotalAmount.Text,
                    rate = txbRate.Text
                };
                FirebaseResponse response = await client.UpdateTaskAsync("product/" + idInput.ToString(), newData);
                MessageBox.Show("Update Thanh Cong");
            }
                
            
        }
    }
}
