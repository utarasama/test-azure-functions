using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_DatahubImplementation.Clients
{
    public class DatahubLoginOptions
    {
        public string BaseUrl { get; set; }
        public string LoginUrl { get; set; }
        public string InfoVehicleIdUrl { get; set; }
        public string ClientSubscription { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientResource { get; set; }
    }
}
