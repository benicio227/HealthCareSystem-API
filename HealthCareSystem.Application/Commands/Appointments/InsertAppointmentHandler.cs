using HealthCareSystem.Application.DomainEvent;
using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.AppointmentResponse;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Appointments
{
    public class InsertAppointmentHandler : IRequestHandler<InsertAppointmentCommand, ApplicationResponse<InsertAppointmentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public InsertAppointmentHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        public async Task<ApplicationResponse<InsertAppointmentResponse>> Handle(InsertAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = request.ToEntity();

            var patient = await _unitOfWork.Patients.GetByIdAsync(request.PatientId);

            if (patient is null)
            {
                return ApplicationResponse<InsertAppointmentResponse>.Fail("Paciente não encontrado.");
            }

            var doctor = await _unitOfWork.Doctors.GetById(request.DoctorId);

            if (doctor is null)
            {
                return ApplicationResponse<InsertAppointmentResponse>.Fail("Médico não encontrado.");
            }

            var service = await _unitOfWork.Services.GetById(request.ServiceId);

            if (service is null)
            {
                return ApplicationResponse<InsertAppointmentResponse>.Fail("Serviço não encontrado.");
            }

            if (await _unitOfWork.Appointmens.ThereIsAScheduleConflict(request.DoctorId, request.StartTime, request.EndTime))
            {
                return ApplicationResponse<InsertAppointmentResponse>.Fail("Já existe um agendamento nesse intervalo de horário.");
            }

            await _unitOfWork.Appointmens.Add(appointment);
            await _unitOfWork.CommitAsync();
            await _mediator.Publish(new AppointmentScheduledEvent(appointment.Id));

            

            var response = new InsertAppointmentResponse
            {
                Id = appointment.Id,
            };

            return ApplicationResponse<InsertAppointmentResponse>.Ok(response);
        }
    }
}
