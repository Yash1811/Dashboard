using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalAccountsApp.Models
{
    public class ElasticCloudViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string AvailableZone { get; set; }

        public string PublicIp { get; set; }

        public string PrivateIp { get; set; }

        public bool IsActive { get; set; }

    }
}