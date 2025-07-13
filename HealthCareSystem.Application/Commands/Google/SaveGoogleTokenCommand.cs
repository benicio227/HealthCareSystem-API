using MediatR;

namespace HealthCareSystem.Application.Commands.Google
{
    public class SaveGoogleTokenCommand : IRequest<Unit>
    {
        public SaveGoogleTokenCommand(string email, string accessToken, string refreshToken, DateTime expiresAt)
        {
            Email = email;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpiresAt = expiresAt;
        }

        public string Email { get; }
        public string AccessToken { get; }
        public string RefreshToken { get; }
        public DateTime ExpiresAt { get; }
    }
}
