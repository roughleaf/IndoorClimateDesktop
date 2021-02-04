using System;
using System.Collections.Generic;
using System.Text;

namespace IndoorClimateDesktop.Domain.Models
{
    public class ClimateData
    {
        public string macAddress { get; set; }
        public IList<NodeData> NodeData { get; set; }
        public IList<LightningData> LightningData { get; set; }
    }
}
