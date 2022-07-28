using System.ComponentModel.DataAnnotations;

namespace PloomesTest.WebApi.Models
{
    /// <summary>
    /// A validation errors list.
    /// </summary>
    public class ErrorList
    {
        [Required]
        public List<string> Errors { get; set; } = new();
    }
}