using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.DoctorResponse;
using HealthCareSystem.Core.Repositories;
using MediatR;

namespace HealthCareSystem.Application.Queries.Doctors
{
    public class GetAllDoctorHandler : IRequestHandler<GetAllDoctorQuery, ApplicationResponse<List<GetAllDoctorResponse>>>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetAllDoctorHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<ApplicationResponse<List<GetAllDoctorResponse>>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAll();

            var response = doctors.Select(doctor => new GetAllDoctorResponse
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email,
                Cpf = doctor.Cpf,
                Phone = doctor.Phone
            }).ToList();

            return ApplicationResponse<List<GetAllDoctorResponse>>.Ok(response);
        }
    }
}
