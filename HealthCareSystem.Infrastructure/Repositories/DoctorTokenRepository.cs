using HealthCareSystem.Core.Entities;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Infrastructure.Repositories
{
    public class DoctorTokenRepository : IDoctorTokenRepository
    {
        private readonly HealthCareSystemDbContext _context;

        public DoctorTokenRepository(HealthCareSystemDbContext context)
        {
            _context = context;
        }
        public async Task Save(Guid doctorId, string email, string accessToken, string refreshToken, DateTime expiresIn)
        {
            var existingToken = await _context.DoctorGoogleTokens.FirstOrDefaultAsync(t => t.DoctorId == doctorId);

            if (existingToken is null)
            {
                var newToken = new DoctorGoogleToken
                {
                    DoctorId = doctorId,
                    Email = email,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiresIn = expiresIn
                };

                await _context.DoctorGoogleTokens.AddAsync(newToken);
            }
            else
            {
                existingToken.AccessToken = accessToken;
                existingToken.RefreshToken = refreshToken;
                existingToken.ExpiresIn = expiresIn;
                _context.DoctorGoogleTokens.Update(existingToken);
            }
        }
        public async Task<DoctorGoogleToken?> GetByDoctorId(Guid doctorId)
        {
            return await _context.DoctorGoogleTokens
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.DoctorId == doctorId);
        }

    }
}
