using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Windows.Forms;
namespace appStore
{
    public class Counter
    {
        public string countBill { get; set; }
        public string countCode{ get; set; }
        public string countProduct { get; set; }

        //Lay size cua database
        public Counter()
        {
            
        }
        public static async Task<Counter> getSizeData()
        {
            var client = HTTPRequest.getInstance();
            
            FirebaseResponse response = await client.GetTaskAsync("counter");
            return response.ResultAs<Counter>();
        }

        //Update gia tri counter them 1 don vi
        public static async void updateCounter(string name)
        {
            Counter newData = new Counter();
            newData = await getSizeData();
            switch (name)
            {
                case "bill":
                    newData.countBill = upValueString(newData.countBill);
                    break;
                case "code":
                    newData.countCode = upValueString(newData.countCode);
                    break;
                case "product":         
                    newData.countProduct = upValueString(newData.countProduct);
                    break;
            }
            var client = HTTPRequest.getInstance();
            await client.UpdateTaskAsync("counter", newData);
  
        }
        //Tang gia tri cua str len 1 don vi
        public static string upValueString(string str)
        {   
            return (Convert.ToInt32(str) + 1).ToString();
        }
    }
}
