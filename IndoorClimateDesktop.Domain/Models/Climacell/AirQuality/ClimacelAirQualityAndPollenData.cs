using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Domain.Models.Climacell.AirQuality
{ 
    public class ClimacelAirQualityAndPollenData
    {
        public DateTime TimeStamp { get; set; }
        public ClimacelAirQuality ClimacelAirQuality { get; set; }
        public ClimacelPollenIndex ClimacelPollenIndex { get; set; }
    }
}
