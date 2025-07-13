namespace HealthCareSystem.Application.Models.ServiceResponse
{
    public class GetServiceByIdResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
