using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Domain.Models.Climacell.AirQuality
{
    public class ClimacelAirQuality
    {
        public float PollutantO3 { get; set; }
        public float PollutantNO2 { get; set; }
        public float PollutantCO { get; set; }
        public float PollutantSO2 { get; set; }
        public float ParticulateMatter10 { get; set; }
        public float ParticulateMatter25 { get; set; }
    }
}
