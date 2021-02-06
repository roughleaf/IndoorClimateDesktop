using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Services.ApiIndoorClimateLocalData.Models
{
    public class ApiClimateData
    {
        public string MacAddress { get; set; }
        public IList<ApiNodeData> NodeData { get; set; }
        public IList<ApiLightningData> LightningData { get; set; }
    }
}
