using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Domain.Models.TestModels
{
    public class ClimateDataTest
    {
        public string MacAddress { get; set; }
        public NodeDataTest nodeDataTest { get; set; }
        public LightningDataTest lightningDataTest { get; set; }
        public string[] DisplayStuff { get; set; }
    }
}
