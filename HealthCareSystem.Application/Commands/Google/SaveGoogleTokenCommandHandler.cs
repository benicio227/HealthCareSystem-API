using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Google
{
    public class SaveGoogleTokenCommandHandler : IRequestHandler<SaveGoogleTokenCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaveGoogleTokenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(SaveGoogleTokenCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.Doctors.GetByEmail(request.Email);
            if (doctor is null)
            {
                throw new Exception("Médico não encontrado.");
            }

            await _unitOfWork.Tokens.Save(doctor.Id, request.Email, request.AccessToken, request.RefreshToken, request.ExpiresAt);
            await _unitOfWork.CommitAsync();

            return Unit.Value;

        }
    }
}
