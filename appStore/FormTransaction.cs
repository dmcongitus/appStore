using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appStore
{
    public partial class FormTransaction : Form
    {
        public FormTransaction()
        {
            InitializeComponent();
        }

        private async void FormTransaction_Load(object sender, EventArgs e)
        {
            var client = HTTPRequest.getInstance();

            try
            {
                FirebaseResponse countRes = await client.GetTaskAsync("counter");
                int billCount = Convert.ToInt32(countRes.ResultAs<Counter>().countBill);

                for (int i = 1; i <= billCount; i++)
                {
                    FirebaseResponse billRes = await client.GetTaskAsync("bill/" + i);
                    Bill data = billRes.ResultAs<Bill>();
                    transactionTable.Rows.Add(new string[] { i.ToString(), data.amount, data.code, data.price, data.productId, data.status, data.total });
                }

            } catch (Exception ex)
            {
                Console.WriteLine("==> " + ex.Message);
            }

        }

        private void transactionTable_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(e.RowIndex);
        }
    }
}
