using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Domain.Services.ApiClimacel.Models
{
    public class ApiClimacelAirQualityAndPollen
    {
        public AirQualityData data { get; set; }
    }

    public class AirQualityData
    {
        public IEnumerable<AirQualityTimeline> timelines { get; set; }
    }

    public class AirQualityTimeline
    {
        public string timestep { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public IEnumerable<AirQualityInterval> intervals { get; set; }
    }

    public class AirQualityInterval
    {
        public DateTime startTime { get; set; }
        public AirQualityValues values { get; set; }
    }

    public class AirQualityValues
    {
        public float particulateMatter25 { get; set; }
        public float particulateMatter10 { get; set; }
        public float pollutantO3 { get; set; }
        public float pollutantNO2 { get; set; }
        public float pollutantCO { get; set; }
        public float pollutantSO2 { get; set; }
        public int treeIndex { get; set; }
        public int grassIndex { get; set; }
        public int grassGrassIndex { get; set; }
        public float weedIndex { get; set; }
        public float weedRagweedIndex { get; set; }
    }


}
