using IndoorClimateDesktop.Domain.Models;
using IndoorClimateDesktop.Services.ApiIndoorClimateLocalData.Models;
using IndoorClimateDesktop.Services.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Services.ApiIndoorClimateLocalData
{
    public class ApiIndoorClimateLocalDataService
    {
        public async static Task<ClimateData> GetLocalClimateData()
        {
            string JsonString = await IndoorClimateTcpServer.Listen(13000);

            ClimateData apiClimateData = JsonSerializer.Deserialize<ClimateData>(JsonString);         

            return apiClimateData;
        }
    }
}
