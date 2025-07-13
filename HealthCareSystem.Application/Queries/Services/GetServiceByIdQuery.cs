using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.ServiceResponse;
using MediatR;

namespace HealthCareSystem.Application.Queries.Services
{
    public class GetServiceByIdQuery : IRequest<ApplicationResponse<GetServiceByIdResponse>>
    {
        public Guid Id { get; set; }
    }
}
