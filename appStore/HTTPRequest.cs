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
    }
}
