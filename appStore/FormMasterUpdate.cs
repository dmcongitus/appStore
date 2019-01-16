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
            string idInput = txbID.Text;
            if(await HTTPRequest.CheckSizeData("product",idInput)==false){
                MessageBox.Show("ID khong hop le");
            }
            else
            {
                var client = HTTPRequest.getInstance();
                var newData = new Product
                {
                    //deleted = "false",
                    name = txbName.Text,
                    type = txbType.Text,
                    saleAmount = txbSaleAmount.Text,
                    totalAmount = txbTotalAmount.Text,
                    rate = txbRate.Text
                };
                HTTPRequest.updateDataProduct(idInput, newData);
            }
                
            
        }

        private async void txbID_TextChangedAsync(object sender, EventArgs e)
        {
            if (txbID.Text != "")
            if (await HTTPRequest.CheckSizeData("product", txbID.Text)==false)
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
                txbName.ReadOnly = false;
                txbRate.ReadOnly = false;
                txbSaleAmount.ReadOnly = false;
                txbTotalAmount.ReadOnly = false;
                txbType.ReadOnly = false;
                txbName.Text = data.name;
                txbRate.Text = data.rate;
                txbSaleAmount.Text = data.saleAmount;
                txbTotalAmount.Text = data.totalAmount;
                txbType.Text = data.type;
            }
        }
    }
}
