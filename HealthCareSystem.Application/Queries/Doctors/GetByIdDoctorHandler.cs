using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.DoctorResponse;
using HealthCareSystem.Core.Repositories;
using MediatR;

namespace HealthCareSystem.Application.Queries.Doctors
{
    public class GetByIdDoctorHandler : IRequestHandler<GetByIdDoctorQuery, ApplicationResponse<GetByIdDoctorResponse>>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetByIdDoctorHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<ApplicationResponse<GetByIdDoctorResponse>> Handle(GetByIdDoctorQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetById(request.Id);

            if (doctor is null)
            {
                return ApplicationResponse<GetByIdDoctorResponse>.Fail("Médico não encontrado.");
            }

            var response = new GetByIdDoctorResponse
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                DateOfBirth = doctor.DateOfBirth,
                BloodType = doctor.BloodType,
                Cpf = doctor.Cpf,
                Crm = doctor.Crm,
                Email = doctor.Email,
                Phone = doctor.Phone,
                Address = doctor.Address,
                Specialty = doctor.Specialty
            };

            return ApplicationResponse<GetByIdDoctorResponse>.Ok(response);
        }
    }
}
