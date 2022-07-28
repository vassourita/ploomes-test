namespace PloomesTest.Core.Entities
{
    public enum ClientType
    {
        PhysicalPerson,
        LegalPerson
    }

    public class Client
    {
        public Client(ClientType type, string federalDocument, string name, string email, string phone, string address, string city, string state, string zipCode, string country)
        {
            Id = Guid.NewGuid();
            Type = type;
            FederalDocument = federalDocument;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public ClientType Type { get; set; }
        public string TypeName => Type.ToString();

        public string FederalDocument { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}