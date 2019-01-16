using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace appStore
{
    public class Counter
    {
        public string countBill { get; set; }
        public string countCode{ get; set; }
        public string countProduct { get; set; }


        public static async void getSizeData(Counter data)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://appstoredmcongitus.firebaseio.com/",
                AuthSecret = "PyTSdTC43NxSQfak0PEOGokVqz2y5smSmBdWBRhz"

            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = await client.GetTaskAsync("counter");

            data = response.ResultAs<Counter>();

        }
    }
}
