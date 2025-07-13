using HealthCareSystem.Core.Enums;

namespace HealthCareSystem.Core.Entities
{
    public class Patient
    {
        public Patient(string firstName, string lastName, DateTime dateOfBirth, string phone,
            string email, string cpf, BloodType bloodType, double height, double weight, string address)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            Cpf = cpf;
            BloodType = bloodType;
            Height = height;
            Weight = weight;
            Address = address;
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
        public double Height {  get; private set; }
        public double Weight {  get; private set; }
        public string Address {  get; private set; }

        public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();

        public void UpdatePatient(string firstName, string lastName, string phone, string email, double height, double weight, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Height = height;
            Weight = weight;
            Address = address;
        }
    }
}
