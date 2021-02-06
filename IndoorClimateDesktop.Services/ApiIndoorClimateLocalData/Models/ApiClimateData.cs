using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Services.ApiIndoorClimateLocalData.Models
{
    class ApiClimateData
    {
        public string macAddress { get; set; }
        public IEnumerable<ApiNodeData> NodeData { get; set; }
        public IEnumerable<ApiLightningData> LightningData { get; set; }
    }
}
