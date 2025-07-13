using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.ServiceResponse;
using MediatR;

namespace HealthCareSystem.Application.Queries.Services
{
    public class GetAllServicesQuery : IRequest<ApplicationResponse<List<GetAllServiceResponse>>>
    {

    }
}
