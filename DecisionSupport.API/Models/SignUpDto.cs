using System.ComponentModel.DataAnnotations;

namespace DecisionSupport.API.Models
{
    public class SignUpDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\\_]+$")]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
