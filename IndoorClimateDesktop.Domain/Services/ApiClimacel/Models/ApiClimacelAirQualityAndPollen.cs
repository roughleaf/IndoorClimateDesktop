using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Domain.Services.ApiClimacel.Models
{


    public class ApiClimacelAirQualityAndPollen
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Timeline[] timelines { get; set; }
    }

    public class Timeline
    {
        public string timestep { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Interval[] intervals { get; set; }
    }

    public class Interval
    {
        public DateTime startTime { get; set; }
        public Values values { get; set; }
    }

    public class Values
    {
        public float particulateMatter25 { get; set; }
        public float particulateMatter10 { get; set; }
        public float pollutantO3 { get; set; }
        public float pollutantNO2 { get; set; }
        public float pollutantCO { get; set; }
        public float pollutantSO2 { get; set; }
        public int treeIndex { get; set; }
        public float grassIndex { get; set; }
        public float grassGrassIndex { get; set; }
        public float weedIndex { get; set; }
        public float weedRagweedIndex { get; set; }
    }
}
