namespace HealthCareSystem.Application.Models.ServiceResponse
{
    public class UpdateServiceResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
