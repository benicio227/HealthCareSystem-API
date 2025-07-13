using HealthCareSystem.Application.Models;
using MediatR;

namespace HealthCareSystem.Application.Commands.Services
{
    public class DeleteServiceCommand : IRequest<ApplicationResponse<Unit>>
    {
        public Guid Id { get; set; }
    }
}
