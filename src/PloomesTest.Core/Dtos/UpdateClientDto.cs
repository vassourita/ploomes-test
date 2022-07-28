using System.ComponentModel.DataAnnotations;

namespace PloomesTest.Core.Dtos
{
    public class UpdateClientDto
    {
        [StringLength(14, MinimumLength = 11)]
        [RegularExpression(@"^\d+$")]
        public string FederalDocument { get; set; }

        [StringLength(250, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength(250, MinimumLength = 1)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(11, MinimumLength = 10)]
        [RegularExpression(@"^\d+$")]
        public string Phone { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string Address { get; set; }

        [StringLength(100, MinimumLength = 1)]
        public string City { get; set; }

        [StringLength(40, MinimumLength = 1)]
        public string State { get; set; }

        [StringLength(8)]
        [RegularExpression(@"^\d+$")]
        public string ZipCode { get; set; }

        [StringLength(60, MinimumLength = 1)]
        public string Country { get; set; }
    }
}