using System.ComponentModel.DataAnnotations;

namespace SyntaxErrorist.Shared.Models
{
    public class BasicInfo : BaseEntity
    {
        [Required]
        [StringLength(25, ErrorMessage = " Maximum Length is 25")]
        [MinLength(2, ErrorMessage = " minimum Length is 2")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Only Alphabets are allowed")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(25, ErrorMessage = " Maximum Length is 25")]
        [MinLength(2, ErrorMessage = "minimum Length is 2")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Only Alphabets are allowed")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(11)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only Numbers are allowed")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Bio { get; set; } = string.Empty;

        [Required]
        [StringLength(256)]
        public string ProfilePictureUrl { get; set; } = string.Empty;
    }
}
