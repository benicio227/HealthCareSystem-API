using HealthCareSystem.Application.Models;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Appointments
{
    public class DeleteAppointmentHandler : IRequestHandler<DeleteAppointmentCommand, ApplicationResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork; 
        public DeleteAppointmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse<Unit>> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _unitOfWork.Appointmens.GetById(request.Id);

            if (appointment is null)
            {
                return ApplicationResponse<Unit>.Fail("Agendamento não encontrado.");
            }

            await _unitOfWork.Appointmens.Delete(appointment.Id);
            await _unitOfWork.CommitAsync();

            return ApplicationResponse<Unit>.Ok(Unit.Value);
        }
    }
}
