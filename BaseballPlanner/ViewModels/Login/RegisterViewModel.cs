using ClubGrid.Helper;
using System.ComponentModel.DataAnnotations;

namespace ClubGrid.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.DataAnnotations.ErrorMessages), ErrorMessageResourceName = ErrorMessageStrings.REQUIRE_USERNAME)]
        [Display(Name = DisplayNameStrings.USERNAME, ResourceType = typeof(Resources.DataAnnotations.DisplayNames))]
        public string Username { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.DataAnnotations.ErrorMessages), ErrorMessageResourceName = ErrorMessageStrings.REQUIRE_EMAIL)]
        [Display(Name = DisplayNameStrings.EMAIL, ResourceType = typeof(Resources.DataAnnotations.DisplayNames))]
        public string Mail { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.DataAnnotations.ErrorMessages), ErrorMessageResourceName = ErrorMessageStrings.NOT_MATCHING_EMAILS)]
        [Display(Name = DisplayNameStrings.EMAIL_CONFIRM, ResourceType = typeof(Resources.DataAnnotations.DisplayNames))]
        [Compare(nameof(Mail))]
        public string MailConfirmation { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = DisplayNameStrings.PASSWORD, ResourceType = typeof(Resources.DataAnnotations.DisplayNames))]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
