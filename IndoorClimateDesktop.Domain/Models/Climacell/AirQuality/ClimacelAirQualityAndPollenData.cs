using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Domain.Models.Climacell.AirQuality
{
    // uri = https://data.climacell.co/v4/timelines?location=ClimacelHomeLocationId&fields=treeIndex&fields=grassIndex&fields=grassGrassIndex&fields=weedIndex&fields=weedRagweedIndex&fields=pollutantO3&fields=pollutantNO2&fields=pollutantCO&fields=pollutantSO2&fields=particulateMatter10&fields=particulateMatter25&timesteps=current&units=metric&apikey=ClimacelApiKey
    public class ClimacelAirQualityAndPollenData
    {
        public DateTime TimeStamp { get; set; }
        public ClimacelAirQuality ClimacelAirQuality { get; set; }
        public ClimacelPollenIndex ClimacelPollenIndex { get; set; }
    }
}
