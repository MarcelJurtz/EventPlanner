using System.ComponentModel.DataAnnotations;

namespace Planner.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Benutzername")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
