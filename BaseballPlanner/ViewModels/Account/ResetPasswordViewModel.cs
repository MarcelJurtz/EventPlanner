using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClubGrid.ViewModels
{
    public class ResetPasswordViewModel : BaseViewModel
    {
        public string Code { get; set; }

        [DisplayName("E-Mail Adresse")]
        public String Email { get; set; }

        [DisplayName("Neues Kennwort")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DisplayName("Neues Kennwort bestätigen")]
        [DataType(DataType.Password)]
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Die eingegebenen Kennwörter stimmen nicht überein")]
        public string PasswordConfirmation { get; set; }
    }
}
