using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.ServiceResponse;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Services
{
    public class InsertServiceHandler : IRequestHandler<InsertServiceCommand, ApplicationResponse<InsertServiceResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsertServiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse<InsertServiceResponse>> Handle(InsertServiceCommand request, CancellationToken cancellationToken)
        {
            var service = request.ToEntity();

            await _unitOfWork.Services.Add(service);
            await _unitOfWork.CommitAsync();

            var response = new InsertServiceResponse
            {
                Id = service.Id
            };

            return ApplicationResponse<InsertServiceResponse>.Ok(response);
        }
    }
}
