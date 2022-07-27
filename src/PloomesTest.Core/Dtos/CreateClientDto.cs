using System.ComponentModel.DataAnnotations;

namespace PloomesTest.Core.Dtos
{
    public class CreateClientDto
    {
        [Required]
        [StringLength(14, MinimumLength = 11)]
        public string FederalDocument { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string Email { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Address { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string State { get; set; }

        [Required]
        [StringLength(8)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string Country { get; set; }
    }
}