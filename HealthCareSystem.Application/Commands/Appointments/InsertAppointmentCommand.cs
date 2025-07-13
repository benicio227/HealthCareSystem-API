using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.AppointmentResponse;
using HealthCareSystem.Core.Entities;
using HealthCareSystem.Core.Enums;
using MediatR;

namespace HealthCareSystem.Application.Commands.Appointments
{
    public class InsertAppointmentCommand : IRequest<ApplicationResponse<InsertAppointmentResponse>>
    {
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ServiceId { get; set; }
        public string Insurance { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentType Type { get; set; }

        public Appointment ToEntity()
        {
            return new Appointment(PatientId, DoctorId, ServiceId, Insurance, StartTime, EndTime, Type);
        }
    }
}
