using System.ComponentModel.DataAnnotations;

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
        [Required]
        public Guid Id { get; private set; }

        /// <summary>
        /// Client's type id.
        /// </summary>
        [Required]
        public ClientType Type { get; set; }

        /// <summary>
        /// Client's type.
        /// </summary>
        [Required]
        public string TypeName => Type.ToString();

        /// <summary>
        /// Client's CPF or CNPJ.
        /// </summary>
        /// <remarks>
        /// CPF generator: https://www.4devs.com.br/gerador_de_cpf
        /// CNPJ generator: https://www.4devs.com.br/gerador_de_cnpj
        /// </remarks>
        [Required]
        public string FederalDocument { get; set; }

        /// <summary>
        /// Client's name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Client's email address.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Client's phone number.
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Client's address.
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Client's city.
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Client's state.
        /// </summary>
        [Required]
        public string State { get; set; }

        /// <summary>
        /// Client's zip code.
        /// </summary>
        [Required]
        public string ZipCode { get; set; }

        /// <summary>
        /// Client's country.
        /// </summary>
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// Client's creation date.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Client's last update date.
        /// </summary>
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}