using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.ServiceResponse;
using HealthCareSystem.Core.Repositories;
using MediatR;

namespace HealthCareSystem.Application.Queries.Services
{
    public class GetAllServicesHandler : IRequestHandler<GetAllServicesQuery, ApplicationResponse<List<GetAllServiceResponse>>>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetAllServicesHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<ApplicationResponse<List<GetAllServiceResponse>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceRepository.GetAll();

            var response = services.Select(service => new GetAllServiceResponse
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                DurationInMinutes = service.DurationInMinutes,
            }).ToList();

            return ApplicationResponse<List<GetAllServiceResponse>>.Ok(response);
        }
    }
}
