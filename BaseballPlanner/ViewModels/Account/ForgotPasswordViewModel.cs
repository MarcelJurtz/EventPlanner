using System;
using System.ComponentModel;

namespace ClubGrid.ViewModels
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        [DisplayName("E-Mail Adresse")]
        public String Email { get; set; }
    }
}
