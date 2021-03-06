﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Services.ApiIndoorClimateLocalData.Models
{
    public class ApiNodeData
    {
        public int NodeID { get; set; }
        public string DateStamp { get; set; }
        public string TimeStamp { get; set; }
        public float BME280Temperature { get; set; }
        public float BME280Pressure { get; set; }
        public int BME280Humididty { get; set; }
        public float DS18B20Temperature { get; set; }
        public int RainCount { get; set; }
    }
}
