﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Models
{
    public class Hazard
    {
        public long? Id { get; set; }

        public string? Title { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public int? Radius { get; set; }

        public DateTime? Timestamp { get; set; }

        public HazardType? HazardType { get; set; }
    }
}
