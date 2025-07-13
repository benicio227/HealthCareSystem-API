namespace HealthCareSystem.Core.Entities
{
    public class Service
    {
        public Service(string name, string description, decimal price, int durationInMinutes)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            DurationInMinutes = durationInMinutes;
            Appointments = new List<Appointment>();
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price {  get; private set; }
        public int DurationInMinutes {  get; private set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public void UpdateService(string name, string description, decimal price, int durationInMinutes)
        {
            Name = name;
            Description = description;
            Price = price;
            DurationInMinutes = durationInMinutes;
        }
    }
}
