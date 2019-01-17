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
    public partial class FormAddTransaction : Form
    {
        private List<Product> products;
        private List<Code> codes;
        int amount = 1;
        double discount = 0;
        double price = 0;
        int productIdx = -1;
        int discountIdx = -1;
        double total = 0;
        int billCount, codeCount, productCount;

        public FormAddTransaction()
        {
            products = new List<Product>();
            codes = new List<Code>();

            InitializeComponent();
        }

        private async void FormAddTransaction_Load(object sender, EventArgs e)
        {
            try
            {
                var client = HTTPRequest.getInstance();
                FirebaseResponse countRes = await client.GetTaskAsync("counter");
                productCount = Convert.ToInt32(countRes.ResultAs<Counter>().countProduct);
                codeCount = Convert.ToInt32(countRes.ResultAs<Counter>().countCode);
                billCount = Convert.ToInt32(countRes.ResultAs<Counter>().countBill);

                for (int i = 1; i <= productCount; i++)
                {
                    FirebaseResponse productRes = await client.GetTaskAsync("product/" + i.ToString());
                    Product product = productRes.ResultAs<Product>();
                    products.Add(product);
                    availableProduct.Items.Add(product.name);
                }


                for (int i = 1; i <= codeCount; i++)
                {
                    FirebaseResponse productRes = await client.GetTaskAsync("code/" + i.ToString());
                    Code codeData = productRes.ResultAs<Code>();

                    DateTime begin = DateTime.Parse(codeData.begin);
                    DateTime end = DateTime.Parse(codeData.end);
                    DateTime now = DateTime.Today;

                    if (begin <= now && now <= end)
                    {
                        codes.Add(codeData);
                        availableCode.Items.Add(codeData.key);
                    }
                }

            }
            catch
            {
                Console.WriteLine("Invalid productID");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = availableProduct.SelectedIndex;
            priceBox.Text = products[idx].rate;
            price = Convert.ToDouble(products[idx].rate);
            productIdx = idx;

            if (!checkEnoughAmount())
            {
                MessageBox.Show("Not enough");
                return;
            }

            try
            {
                image.ImageLocation = products[idx].imageUrl;
                image.SizeMode = PictureBoxSizeMode.Zoom;
                image.Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot load image due to: " + ex.Message);
            }


            setTotal();
        }

        private void codeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = availableCode.SelectedIndex;
            discountLabel.Text = "-" + codes[idx].value + "%";
            discount = Convert.ToInt32(codes[idx].value);
            Console.WriteLine(discount);
            discountIdx = idx;
            setTotal();
        }

        private void setTotal()
        {
            total = (1 - discount / 100) * price * amount;
            totalLabel.Text = total.ToString();
        }

        private bool checkEnoughAmount()
        {
            int maxAmount = Convert.ToInt32(products[productIdx].totalAmount) - Convert.ToInt32(products[productIdx].saleAmount);
            amount = Convert.ToInt32(amountBox.Text);
            return amount <= maxAmount;
        }

        private void amountBox_ValueChanged(object sender, EventArgs e)
        {
            if (!checkEnoughAmount())
            {
                MessageBox.Show("Not enough");
                return;
            }

            setTotal();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (productIdx < 0)
            {
                MessageBox.Show("You haven't chosen a product to make a bill!");
                return;
            }

            var bill = new Bill()
            {
                amount = amount.ToString(),
                code = discountIdx < 0 ? null : codes[discountIdx].key,
                price = (amount * price).ToString(),
                productId = (productIdx + 1).ToString(),
                status = "delivered",
                total = total.ToString()
            };

            var counter = new Counter()
            {
                countProduct = productCount.ToString(),
                countCode = codeCount.ToString(),
                countBill = (billCount + 1).ToString()
            };

            var client = HTTPRequest.getInstance();

            try
            {
                await client.SetTaskAsync("bill/" + (billCount + 1).ToString(), bill);
                await client.UpdateTaskAsync("counter", counter);

                products[productIdx].saleAmount += amount;
                amount = 1;
                discount = 0;
                price = 0;
                productIdx = -1;
                discountIdx = -1;
                total = 0;

                availableProduct.SelectedValue = null;
                priceBox.Text = "";
                amountBox.Value = 1;
                availableCode.SelectedValue = null;
                discountLabel.Text = "";
                totalLabel.Text = "";

                MessageBox.Show("Add bill successfully :D");
            }
            catch
            {
                MessageBox.Show("Add bill failed :(");
            }
        }
    }
}
