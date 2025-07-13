namespace HealthCareSystem.Application.Models.AppointmentResponse
{
    public class GetByIdAppointmentResponse
    {
        public string Insurance { get; set; } = String.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
