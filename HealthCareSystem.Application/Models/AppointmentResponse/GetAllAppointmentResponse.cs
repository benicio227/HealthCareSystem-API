using HealthCareSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.Application.Models.AppointmentResponse
{
    public class GetAllAppointmentResponse
    {
        public string Insurance { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentType Type { get; set; }
    }
}
