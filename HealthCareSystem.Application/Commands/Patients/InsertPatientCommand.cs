using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.PatientResponse;
using HealthCareSystem.Core.Entities;
using HealthCareSystem.Core.Enums;
using MediatR;

namespace HealthCareSystem.Application.Commands.Patients
{
    public class InsertPatientCommand : IRequest<ApplicationResponse<InsertPatientResponse>>
    {
        public string FirstName {  get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Cpf {  get; set; } = string.Empty;
        public BloodType BloodType { get; set; }
        public double Height {  get; set; }
        public double Weight {  get; set; }
        public string Address {  get; set; } = string.Empty;

        public Patient ToEntity()
        {
            return new Patient(FirstName, LastName, DateOfBirth, Phone, Email, Cpf, BloodType, Height, Weight, Address);
        }
    }
}
