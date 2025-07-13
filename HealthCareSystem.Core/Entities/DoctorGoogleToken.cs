namespace HealthCareSystem.Core.Entities
{
    public class DoctorGoogleToken
    {
        public Guid DoctorId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresIn { get; set; }

        public Doctor Doctor { get; set; }
    }
}
