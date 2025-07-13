using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.ServiceResponse;
using HealthCareSystem.Core.Entities;
using MediatR;

namespace HealthCareSystem.Application.Commands.Services
{
    public class InsertServiceCommand : IRequest<ApplicationResponse<InsertServiceResponse>>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationInMinutes { get; set; }

        public Service ToEntity()
        {
            return new Service(Name, Description, Price, DurationInMinutes);
        }

    }
}
