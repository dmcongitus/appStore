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
    public partial class FormMasterRead : Form
    {
        DataTable dttb = new DataTable();
        List<Product> listProduct = new List<Product>();
        int page = 1;
        int totalPage = 1;
        int chil = 5;
        public FormMasterRead()
        {
            InitializeComponent();
        }

        

        private async void FormMasterRead_Load(object sender, EventArgs e)
        {
            comboBoxSort.Items.Add("Rate");
            comboBoxSort.Items.Add("SaleAmount");
            comboBoxSort.Items.Add("TotalAmount");

            //crate Colume DataTable
            dttb.Columns.Add("STT");
            dttb.Columns.Add("NAME");
            dataGridView1.DataSource = dttb;
            //get counter on FireBase
            Counter counter = await Counter.getSizeData();
            //
            for(int i=1; i<= Convert.ToInt32(counter.countProduct);i++)
            {
                //get Product Data from FireBase
                if(await HTTPRequest.CheckSizeData("product",i.ToString()) == true)
                {
                    Product dataResult = await HTTPRequest.getDataProduct(i.ToString());
                    listProduct.Add(dataResult);
                }
                
            }
            totalPage = listProduct.Count/chil;
            if (listProduct.Count % chil != 0) totalPage++;
            readData(listProduct);
        }

        private void rowDataEnter(object sender, DataGridViewCellEventArgs e)
        {    
   
            int index = chil * (page - 1) + e.RowIndex;
            txbName.Text = listProduct[index].name;
            txbRate.Text = listProduct[index].rate;
            txbSaleAmount.Text = listProduct[index].saleAmount;
            txbTotalAmount.Text = listProduct[index].totalAmount;
            txbType.Text = listProduct[index].type;
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
                readData(listProduct);
            }
        }

        private void btnAfter_Click(object sender, EventArgs e)
        {
            if (page < totalPage)
            {
                page++;
                readData(listProduct);
            }
        }

        private void readData(List<Product> listProduct)
        {
            dttb.Rows.Clear();
            for (int i=0; i<chil; i++)
            {
                if(i + chil * (page - 1) < listProduct.Count)
                {
                    DataRow row = dttb.NewRow();
                    row["STT"] = i + chil * (page - 1)+1;
                    row["NAME"] = listProduct[i + chil * (page - 1)].name;
                    dttb.Rows.Add(row);
                    txtPage.Text = page.ToString() + "/" + (totalPage).ToString();
                }

            }
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemBox = comboBoxSort.GetItemText(comboBoxSort.SelectedItem);
            switch(itemBox)
            {
                case "Rate":
                    listProduct = sortWithRate(listProduct, "Rate");
                    break;
                case "TotalAmount":
                    listProduct = sortWithRate(listProduct, "TotalAmount");
                    break;
                case "SaleAmount":
                    listProduct=sortWithRate(listProduct, "SaleAmount");
                    break;
            }
            page = 1;
            readData(listProduct);
        }

        private void searchWithName(List<Product> list, string name)
        {
            if (name == "")  readData(list);

            else
            {

                List<Product> result = new List<Product>();

                foreach (var product in list)
                {
                    if (product.name.ToLower().Contains(name.ToLower()))
                    {
                        result.Add(product);
                    }
                }

                readData(result);
            }

        }

        private List<Product> sortWithRate(List<Product> listProduct , string type)
        {

            for(int i=0; i< listProduct.Count-1; i++)
            {
                for (int j = i+1; j < listProduct.Count; j++)
                {
                    switch (type)
                    {
                        case "Rate":
                            Console.WriteLine("=>" +listProduct[j].rate + "," + Convert.ToInt32(listProduct[i].rate));
                            if (Convert.ToInt32(listProduct[j].rate) < Convert.ToInt32(listProduct[i].rate))
                            {
                                Product tmp = listProduct[j];
                                listProduct[j] = listProduct[i];
                                listProduct[i] = tmp;
                            }
                            break;
                        case "TotalAmount":
                            if (Convert.ToInt32(listProduct[j].totalAmount) < Convert.ToInt32(listProduct[i].totalAmount))
                            {
                                Product tmp = listProduct[j];
                                listProduct[j] = listProduct[i];
                                listProduct[i] = tmp;
                            }
                            break;
                        case "SaleAmount":
                            if (Convert.ToInt32(listProduct[j].saleAmount) < Convert.ToInt32(listProduct[i].saleAmount))
                            {
                                Product tmp = listProduct[j];
                                listProduct[j] = listProduct[i];
                                listProduct[i] = tmp;
                            }
                            break;

                        case "Name":
                            if (listProduct[j].name.CompareTo( listProduct[i].name) == -1)
                            {
                                Product tmp = listProduct[j];
                                listProduct[j] = listProduct[i];
                                listProduct[i] = tmp;
                            }
                            break;
                    }
                       
                }

            }
            readData(listProduct);

            return listProduct;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Product> tmp = listProduct.ToList();
            searchWithName(tmp, txbSeacrhName.Text);
        }

        private void dataGridView1_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Console.WriteLine(e.Column.HeaderText);
            MessageBox.Show(e.Column.HeaderText);
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
               listProduct = sortWithRate(listProduct, "Name");
        }
    }
}
