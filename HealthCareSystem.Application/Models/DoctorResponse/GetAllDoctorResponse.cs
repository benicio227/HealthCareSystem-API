namespace HealthCareSystem.Application.Models.DoctorResponse
{
    public class GetAllDoctorResponse
    {
        public Guid Id { get;  set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
    }
}
