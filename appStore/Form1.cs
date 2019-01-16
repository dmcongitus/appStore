using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace appStore
{
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://appstoredmcongitus.firebaseio.com/",
            AuthSecret = "PyTSdTC43NxSQfak0PEOGokVqz2y5smSmBdWBRhz"
   
        };
        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            txbAccount.Text = "";
            txbPassword.Text = "";
            if (client == null)
            {
                MessageBox.Show("Can not connect to DataBase!!");
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var dataInput = new userData
            {
                account = txbAccount.Text,
                password = txbPassword.Text
            };
            FirebaseResponse response = await client.GetTaskAsync("user");
            userData data = response.ResultAs<userData>();
            if(dataInput.account == data.account && dataInput.password == data.password)
            {
                var frm = new Form2();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("login faild");
            }
            txbAccount.Text = "";
            txbPassword.Text = "";

        }
    }
}
