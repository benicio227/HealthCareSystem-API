using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.DoctorResponse;
using HealthCareSystem.Core.Enums;
using MediatR;

namespace HealthCareSystem.Application.Commands.Doctors
{
    public class UpdateDoctorCommand : IRequest<ApplicationResponse<Unit>>
    {
        public Guid Id { get; private set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public SpecialtyType Specialty { get; set; }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
