using System.ComponentModel.DataAnnotations;

namespace LoginForm.API.Models.ViewModels
{
    public class PostUserViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreationDate => DateTime.Now;

        public bool IsActive => true;
    }
}
