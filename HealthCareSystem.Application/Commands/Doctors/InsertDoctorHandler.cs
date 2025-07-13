using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.DoctorResponse;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Doctors
{
    public class InsertDoctorHandler : IRequestHandler<InsertDoctorCommand, ApplicationResponse<InsertDoctorResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsertDoctorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse<InsertDoctorResponse>> Handle(InsertDoctorCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Doctors.ExistsByEmail(request.Email))
            {
                return ApplicationResponse<InsertDoctorResponse>.Fail("Já existe um médico com esse e-mail.");
            }

            var doctor = request.ToEntity();

            await _unitOfWork.Doctors.Add(doctor);
            await _unitOfWork.CommitAsync();

            var response = new InsertDoctorResponse
            {
                Id = doctor.Id
            };

            return ApplicationResponse<InsertDoctorResponse>.Ok(response);
        }
    }
}
