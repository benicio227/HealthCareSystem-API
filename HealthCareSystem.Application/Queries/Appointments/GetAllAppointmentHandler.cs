using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.AppointmentResponse;
using HealthCareSystem.Core.Repositories;
using MediatR;

namespace HealthCareSystem.Application.Queries.Appointments
{
    public class GetAllAppointmentHandler : IRequestHandler<GetAllAppointmentQuery, ApplicationResponse<List<GetAllAppointmentResponse>>>
    {
        private readonly IAppointmentRepository _appointmentsRepository;

        public GetAllAppointmentHandler(IAppointmentRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }
        public async Task<ApplicationResponse<List<GetAllAppointmentResponse>>> Handle(GetAllAppointmentQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentsRepository.GetAll();

            var response = appointments.Select(appointment => new GetAllAppointmentResponse
            {
                Insurance = appointment.Insurance,
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime,
                Type = appointment.Type
            }).ToList();

            return ApplicationResponse<List<GetAllAppointmentResponse>>.Ok(response);
        }
    }
}
