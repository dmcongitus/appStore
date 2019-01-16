using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace appStore
{
    class HTTPRequest
    {
  
        private IFirebaseConfig config;
        public IFirebaseClient client;
       
        public static HTTPRequest instance;

        private HTTPRequest()
        {
            config = new FirebaseConfig
            {
                BasePath = "https://appstoredmcongitus.firebaseio.com/",
                AuthSecret = "PyTSdTC43NxSQfak0PEOGokVqz2y5smSmBdWBRhz"
            };
            client = new FireSharp.FirebaseClient(config);


        }

        public static IFirebaseClient getInstance()
        {
            if (instance == null)
            {
                instance = new HTTPRequest();
            }
  
            return instance.client;
        }
        //PRODUCT/////////////////////////////////////////////
        public static async Task<Product> getDataProduct(string id)
        {
            var client = getInstance();
            FirebaseResponse response = await client.GetTaskAsync("product/" + id.ToString());
            return response.ResultAs<Product>();
        }
        public static async void setDataProduct(Product data)
        {
            var client = getInstance();
            var count = await Counter.getSizeData();           
            await client.SetTaskAsync("product/" + Counter.upValueString(count.countProduct), data);
            Counter.updateCounter("product");
            MessageBox.Show("Successfully", count.countProduct);
        }
        public static async void deleteDataProduct(string id)
        {
            Product data = await getDataProduct(id);
            data.deleted = "true";
            updateDataProduct(id, data);
            //
            MessageBox.Show("Successfully");
        }

        public static async void updateDataProduct(string id, Product data)
        {
            var client = getInstance();
            await client.UpdateTaskAsync("product/" + id.ToString(), data);
            MessageBox.Show("Successfully");
        }
        ////////////////////////////////////////////////////////
        public static async Task<bool> CheckSizeData(string nameData, string value)
        {
            Counter count = await Counter.getSizeData();
            switch (nameData)
            {
                case "bill":
                    return Convert.ToInt32(value) >0 && Convert.ToInt32(value) <= Convert.ToInt32(count.countBill);                  
                case "code":
                    return Convert.ToInt32(value) > 0 && Convert.ToInt32(value) <= Convert.ToInt32(count.countCode);     
                case "product":
                    return Convert.ToInt32(value) > 0 && Convert.ToInt32(value) <= Convert.ToInt32(count.countProduct);
                 
            }
            return false;
        }



    }
}
