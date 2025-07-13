using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.DoctorResponse;
using HealthCareSystem.Core.Entities;
using HealthCareSystem.Core.Enums;
using MediatR;

namespace HealthCareSystem.Application.Commands.Doctors
{
    public class InsertDoctorCommand : IRequest<ApplicationResponse<InsertDoctorResponse>> 
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public BloodType BloodType { get; set; }
        public string Address { get; set; } = string.Empty;
        public SpecialtyType Specialty { get; set; }
        public string Crm { get; set; } = string.Empty;

        public Doctor ToEntity()
        {
            return new Doctor(FirstName, LastName, DateOfBirth, Phone, Email, Cpf, BloodType, Address, Specialty, Crm);
        }
    }
}
