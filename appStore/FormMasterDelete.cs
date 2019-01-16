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
        Product data = new Product();
        public FormMasterDelete()
        {
            InitializeComponent();
        }



        private async void btnCheckDelete_Click(object sender, EventArgs e)
        {
            string idInput = txbID.Text;
            if (await HTTPRequest.CheckSizeData("product", idInput) == false)
            {
                MessageBox.Show("ID khong hop le");
            }
            else
            {
                HTTPRequest.deleteDataProduct(idInput.ToString());
                //
                txbID.Text = "";
                txbName.Text = "";
                txbRate.Text = "";
                txbSaleAmount.Text ="";
                txbTotalAmount.Text ="";
                txbType.Text = "";
            }
        }

        private async void txbID_TextChanged(object sender, EventArgs e)
        {
            if (txbID.Text != "")
            if (await HTTPRequest.CheckSizeData("product", txbID.Text) == false)
            {
                txbName.Text = "";
                txbRate.Text = "";
                txbSaleAmount.Text = "";
                txbTotalAmount.Text = "";
                txbType.Text = "";
            }
            else
            {
                Product data = await HTTPRequest.getDataProduct(txbID.Text);
                txbName.Text = data.name;
                txbRate.Text = data.rate;
                txbSaleAmount.Text = data.saleAmount;
                txbTotalAmount.Text = data.totalAmount;
                txbType.Text = data.type;
            }
        }
    }
}
