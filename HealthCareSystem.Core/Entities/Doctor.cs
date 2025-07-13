using HealthCareSystem.Core.Enums;

namespace HealthCareSystem.Core.Entities
{
    public class Doctor
    {
        public Doctor(string firstName, string lastName, DateTime dateOfBirth, string phone, string email,
            string cpf, BloodType bloodType, string address, SpecialtyType specialty, string crm)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            Cpf = cpf;
            BloodType = bloodType;
            Address = address;
            Specialty = specialty;
            Crm = crm;
            Appointments = new List<Appointment>();
        }
        public Guid Id { get; private set; }
        public string FirstName {  get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth {  get; private set; }
        public string Phone {  get; private set; }
        public string Email {  get; private set; }
        public string Cpf {  get; private set; }
        public BloodType BloodType {  get; private set; }
        public string Address {  get; private set; }
        public SpecialtyType Specialty {  get; private set; }
        public string Crm {  get; private set; }

        public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();

        public void UpdateDoctor(string firstName, string lastName, string phone, string email,
            string address, SpecialtyType specialty)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Address = address;
            Specialty = specialty;
        }
    }
}
