namespace HealthCareSystem.Core.Repositories
{
    public interface IEmailService
    {
        Task SendConfirmation(Guid aapointmentId);
    }
}
