﻿using IndoorClimateDesktop.Services.ApiIndoorClimateLocalData.Models;
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
        public static IEnumerable<ApiClimateData> GetLocalClimateData(string apiKey)
        {
            string JsonString = IndoorClimateTcpServer.Listen(13000);

            ApiClimateData apiClimateData = JsonSerializer.Deserialize<ApiClimateData>(JsonString);

            return (IList<ApiClimateData>)apiClimateData;
        }
    }
}