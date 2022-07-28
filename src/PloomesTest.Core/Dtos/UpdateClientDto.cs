using System.ComponentModel.DataAnnotations;

namespace PloomesTest.Core.Dtos
{
    /// <summary>
    /// Payload used to update a client.
    /// </summary>
    public class UpdateClientDto
    {
        /// <summary>
        /// Client's CPF or CNPJ. Must be unique. Should contain only digits (11 or 14). The length will define the client type. 
        /// </summary>
        [StringLength(14, MinimumLength = 11)]
        [RegularExpression(@"^\d+$")]
        public string FederalDocument { get; set; }

        /// <summary>
        /// Client's name.
        /// </summary>
        [StringLength(250, MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Client's email address.
        /// </summary>
        [StringLength(250, MinimumLength = 1)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Client's phone number. Should contain only digits and the region code, up to a maximum of 11 digits.
        /// </summary>
        [StringLength(11, MinimumLength = 10)]
        [RegularExpression(@"^\d+$")]
        public string Phone { get; set; }

        /// <summary>
        /// Client's address.
        /// </summary>
        [StringLength(200, MinimumLength = 1)]
        public string Address { get; set; }

        /// <summary>
        /// Client's city.
        /// </summary>
        [StringLength(100, MinimumLength = 1)]
        public string City { get; set; }

        /// <summary>
        /// Client's state.
        /// </summary>
        [StringLength(40, MinimumLength = 1)]
        public string State { get; set; }

        /// <summary>
        /// Client's zip code.
        /// </summary>
        [StringLength(8)]
        [RegularExpression(@"^\d+$")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Client's zip country.
        /// </summary>
        [StringLength(60, MinimumLength = 1)]
        public string Country { get; set; }
    }
}