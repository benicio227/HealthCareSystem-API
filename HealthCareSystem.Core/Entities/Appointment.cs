using HealthCareSystem.Core.Enums;

namespace HealthCareSystem.Core.Entities
{
    public class Appointment
    {
        public Appointment(Guid patientId, Guid doctorId, Guid serviceId, string insurance,
            DateTime startTime, DateTime endTime, AppointmentType type)
        {
            Id = Guid.NewGuid();
            PatientId = patientId;
            DoctorId = doctorId;
            ServiceId = serviceId;
            Insurance = insurance;
            StartTime = startTime;
            EndTime = endTime;
            Type = type;
        }
        public Guid Id { get; private set; }

        public Guid PatientId { get; private set; }
        public Patient Patient { get; private set; }

        public Guid DoctorId { get; private set; }
        public Doctor Doctor { get; private set; }

        public Guid ServiceId { get; private set; }
        public Service Service { get; private set; }

        public string Insurance {  get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public AppointmentType Type {  get; private set; }

        public void UpdateAppointment(string insurance, DateTime startTime, DateTime endTime, AppointmentType type)
        {
            Insurance = insurance;
            StartTime = startTime;
            EndTime = endTime;
            Type = type;
        }
    }
}
