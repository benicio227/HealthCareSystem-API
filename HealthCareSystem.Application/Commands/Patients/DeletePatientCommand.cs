using HealthCareSystem.Application.Models;
using MediatR;

namespace HealthCareSystem.Application.Commands.Patients
{
    public class DeletePatientCommand : IRequest<ApplicationResponse<Unit>>
    {
        public Guid Id { get; set; }
    }
}
