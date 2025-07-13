using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.AppointmentResponse;
using HealthCareSystem.Core.Repositories;
using MediatR;

namespace HealthCareSystem.Application.Queries.Appointments
{
    public class GetByIdAppointmentHandler : IRequestHandler<GetByIdAppointmentQuery, ApplicationResponse<GetByIdAppointmentResponse>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetByIdAppointmentHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<ApplicationResponse<GetByIdAppointmentResponse>> Handle(GetByIdAppointmentQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetById(request.Id);

            if (appointment is null)
            {
                return ApplicationResponse<GetByIdAppointmentResponse>.Fail("Agendamento não encontrado.");
            }

            var response = new GetByIdAppointmentResponse
            {
                Insurance = appointment.Insurance,
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime
            };

            return ApplicationResponse<GetByIdAppointmentResponse>.Ok(response);
        }
    }
}
