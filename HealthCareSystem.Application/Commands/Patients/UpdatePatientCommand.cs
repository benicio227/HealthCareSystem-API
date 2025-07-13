using HealthCareSystem.Application.Models;
using HealthCareSystem.Core.Entities;
using MediatR;

namespace HealthCareSystem.Application.Commands.Patients
{
    public class UpdatePatientCommand : IRequest<ApplicationResponse<Unit>>
    {
        public Guid Id { get; private set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Address { get; set; } = string.Empty;

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
