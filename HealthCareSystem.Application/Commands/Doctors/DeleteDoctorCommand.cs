using HealthCareSystem.Application.Models;
using MediatR;

namespace HealthCareSystem.Application.Commands.Doctors
{
    public class DeleteDoctorCommand : IRequest<ApplicationResponse<Unit>>
    {
        public Guid Id { get; set; }
    }
}
