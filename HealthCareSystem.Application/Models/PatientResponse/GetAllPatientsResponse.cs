namespace HealthCareSystem.Application.Models.PatientResponse
{
    public class GetAllPatientsResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone {  get; set; } = string.Empty;
        public string Cpf {  get; set; } = string.Empty;
    }
}
