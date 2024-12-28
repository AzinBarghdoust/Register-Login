using System.ComponentModel.DataAnnotations;

namespace SignUpSignIn.DTOs.User
{
    public class RegistrationUserDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string PasswordConf { get; set; }
    }
}
