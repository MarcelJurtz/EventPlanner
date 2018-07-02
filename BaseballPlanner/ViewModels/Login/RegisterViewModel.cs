using System.ComponentModel.DataAnnotations;

namespace ClubGrid.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Bitte gib einen Benutzernamen an")]
        [Display(Name = "Benutzername")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bitte gib eine E-Mail Adresse an")]
        [Display(Name = "E-Mail Adresse")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Die angegeben E-Mail Adressen stimmen nicht überein")]
        [Display(Name = "E-Mail Adresse bestätigen")]
        [Compare(nameof(Mail))]
        public string MailConfirmation { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
