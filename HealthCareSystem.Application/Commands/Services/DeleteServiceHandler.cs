using HealthCareSystem.Application.Models;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Services
{
    public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, ApplicationResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteServiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse<Unit>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _unitOfWork.Services.GetById(request.Id);

            if (service is null)
            {
                return ApplicationResponse<Unit>.Fail("Serviço não encontrado.");
            }

            await _unitOfWork.Services.Delete(request.Id);
            await _unitOfWork.CommitAsync();

            return ApplicationResponse<Unit>.Ok(Unit.Value);
        }
    }
}
