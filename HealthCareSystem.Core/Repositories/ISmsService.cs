namespace HealthCareSystem.Core.Repositories
{
    public interface ISmsService
    {
        Task SendSms(string phoneNumber, string message);
    }
}
