using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.ServiceResponse;
using MediatR;

namespace HealthCareSystem.Application.Commands.Services
{
    public class UpdateServiceCommand : IRequest<ApplicationResponse<Unit>>
    {
        public Guid Id { get; private set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationInMinutes { get; set; }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
