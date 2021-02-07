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
        public static ClimateData GetLocalClimateData()
        {
            string JsonString = IndoorClimateTcpServer.Listen(13000);

            ClimateData apiClimateData = JsonSerializer.Deserialize<ClimateData>(JsonString);

            for (int i = 0; i < 10; i++)
            {
                if (apiClimateData.NodeData[i].DateStamp == "")
                {
                    apiClimateData.NodeData[i].IsPresent = false;
                }
                else
                {
                    apiClimateData.NodeData[i].IsPresent = true;
                }
            }

            return apiClimateData;
        }
    }
}
