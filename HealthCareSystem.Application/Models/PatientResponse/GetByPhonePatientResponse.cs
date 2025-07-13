using HealthCareSystem.Core.Enums;

namespace HealthCareSystem.Application.Models.PatientResponse
{
    public class GetByPhonePatientResponse
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public BloodType BloodType { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
