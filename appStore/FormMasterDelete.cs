using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using FireSharp.Response;

namespace appStore
{
    public partial class FormMasterDelete : Form
    {
        productData data = new productData();
        public FormMasterDelete()
        {
            InitializeComponent();
        }

        private async void btnGetInfo_Click(object sender, EventArgs e)
        {
            Counter count = new Counter();
            

            count = await Counter.getSizeData();
            string idInput = txbID.Text;
            if (Convert.ToInt32(idInput) < 1 || Convert.ToInt32(idInput) > Convert.ToInt32(count.countProduct))
            {
                MessageBox.Show("ID khong hop le");
            }
            else
            {
                var client = HTTPRequest.getInstance();
         
                FirebaseResponse response = await client.GetTaskAsync("product/" + idInput.ToString());
                data = response.ResultAs<productData>();
                txbName.Text = data.name;
                txbRate.Text = data.rate;
                txbSaleAmount.Text = data.saleAmount;
                txbTotalAmount.Text = data.saleAmount;
                txbType.Text = data.type;
            }
        }

        private async void btnCheckDelete_Click(object sender, EventArgs e)
        {
            Counter count = new Counter();
            var data = new productData();

            count = await Counter.getSizeData();
            string idInput = txbID.Text;
            if (Convert.ToInt32(idInput) < 1 || Convert.ToInt32(idInput) > Convert.ToInt32(count.countProduct))
            {
                MessageBox.Show("ID khong hop le");
            }
            else
            {
                var client = HTTPRequest.getInstance();
                FirebaseResponse response = await client.GetTaskAsync("product/" + idInput.ToString());
                data = response.ResultAs<productData>();
                data.deleted = "true";
                FirebaseResponse responseUpdate = await client.UpdateTaskAsync("product/" + idInput.ToString(), data);
                MessageBox.Show("Xoa Thanh Cong");
            }
        }
    }
}
