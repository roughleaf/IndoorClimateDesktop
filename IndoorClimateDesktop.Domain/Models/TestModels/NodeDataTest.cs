using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Domain.Models.TestModels
{
    public class NodeDataTest
    {
        public string NodeID { get; set; }
        public string DateStamp { get; set; }
        public string TimeStamp { get; set; }
        public string BME280Temperature { get; set; }
        public string BME280Pressure { get; set; }
        public string BME280Humididty { get; set; }
        public string DS18B20Temperature { get; set; }
        public string RainCount { get; set; }
    }
}
