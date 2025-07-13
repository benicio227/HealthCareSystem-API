using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.ServiceResponse;
using HealthCareSystem.Core.Repositories;
using MediatR;

namespace HealthCareSystem.Application.Queries.Services
{
    public class GetServiceByIdHandler : IRequestHandler<GetServiceByIdQuery, ApplicationResponse<GetServiceByIdResponse>>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServiceByIdHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<ApplicationResponse<GetServiceByIdResponse>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetById(request.Id);

            if (service is null)
            {
                return ApplicationResponse<GetServiceByIdResponse>.Fail("Servico não encontrado");
            }

            var response = new GetServiceByIdResponse
            {
                Name = service.Name,
                Description = service.Description,
                DurationInMinutes = service.DurationInMinutes,
                Price = service.Price
            };

            return ApplicationResponse<GetServiceByIdResponse>.Ok(response);
        }
    }
}
