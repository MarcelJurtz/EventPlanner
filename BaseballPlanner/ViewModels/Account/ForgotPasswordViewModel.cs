using System;
using System.ComponentModel;

namespace Planner.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [DisplayName("E-Mail Adresse")]
        public String Email { get; set; }
    }
}
