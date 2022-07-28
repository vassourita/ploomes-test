namespace PloomesTest.Core.Entities
{
    /// <summary>
    /// Client type definition. The length of the federal document will define the client type.
    /// </summary>
    public enum ClientType
    {
        /// <summary>
        /// Client is a person.
        /// </summary>
        PhysicalPerson,
        /// <summary>
        /// Client is a company.
        /// </summary>
        Company
    }

    /// <summary>
    /// Client entity definition.
    /// </summary>
    public class Client
    {
        /// For EF
        protected Client() { }

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

        /// <summary>
        /// Client's unique identifier.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Client's type id.
        /// </summary>
        public ClientType Type { get; set; }

        /// <summary>
        /// Client's type.
        /// </summary>
        public string TypeName => Type.ToString();

        /// <summary>
        /// Client's CPF or CNPJ.
        /// </summary>
        public string FederalDocument { get; set; }

        /// <summary>
        /// Client's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Client's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Client's phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Client's address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Client's city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Client's state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Client's zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Client's country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Client's creation date.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Client's last update date.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}