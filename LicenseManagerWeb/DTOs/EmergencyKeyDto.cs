using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManagerWeb.DTOs
{
    public class EmergencyKeyDto
    {
        public int Id { get; set; }

        public string Key { get; set; }
        public int ExecutionIntervalMinutes { get; set; }
        public bool Active { get; set; }
    }
}
