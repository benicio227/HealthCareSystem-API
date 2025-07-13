using HealthCareSystem.Application.Models;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Appointments
{
    public class UpdateAppointmentHandler : IRequestHandler<UpdateAppointmentCommand, ApplicationResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAppointmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse<Unit>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _unitOfWork.Appointmens.GetById(request.Id);

            if (appointment is null)
            {
                return ApplicationResponse<Unit>.Fail("Agendamento não encontrado.");
            }

            appointment.UpdateAppointment(request.Insurance, request.StartTime, request.EndTime, request.Type);

            await _unitOfWork.Appointmens.Update(appointment);
            await _unitOfWork.CommitAsync();

            return ApplicationResponse<Unit>.Ok(Unit.Value);
        }
    }
}
