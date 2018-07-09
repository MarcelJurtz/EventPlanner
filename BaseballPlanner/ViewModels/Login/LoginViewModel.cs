using ClubGrid.Helper;
using System.ComponentModel.DataAnnotations;

namespace ClubGrid.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.DataAnnotations.ErrorMessages), ErrorMessageResourceName = ErrorMessageStrings.REQUIRE_USERNAME)]
        [Display(Name = DisplayNameStrings.USERNAME, ResourceType = typeof(Resources.DataAnnotations.DisplayNames))]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = DisplayNameStrings.PASSWORD, ResourceType = typeof(Resources.DataAnnotations.DisplayNames))]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
