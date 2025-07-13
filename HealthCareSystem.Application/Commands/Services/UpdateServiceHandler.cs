using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.ServiceResponse;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Services
{
    public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand, ApplicationResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateServiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse<Unit>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _unitOfWork.Services.GetById(request.Id);

            if (service is null)
            {
                return ApplicationResponse<Unit>.Fail("Serviço não encontrado.");
            }

            service.UpdateService(request.Name, request.Description, request.Price, request.DurationInMinutes);

            await _unitOfWork.Services.Update(service);
            await _unitOfWork.CommitAsync();

            return ApplicationResponse<Unit>.Ok(Unit.Value);
        }
    }
}
