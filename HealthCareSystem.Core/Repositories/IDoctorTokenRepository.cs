using HealthCareSystem.Core.Entities;

namespace HealthCareSystem.Core.Repositories
{
    public interface IDoctorTokenRepository
    {
        Task Save(Guid doctorId, string email, string accessToken, string refreshToken, DateTime expiresIn);
        Task<DoctorGoogleToken?> GetByDoctorId(Guid doctorId);
    }
}
