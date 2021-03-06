﻿using ClubGrid.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClubGrid.ViewModels
{
    public class UserSettingsViewModel : BaseViewModel
    {
        [DisplayName("Altes Kennwort")]
        [DataType(DataType.Password)]
        [Required]
        public string OldPassword { get; set; }

        [DisplayName("Neues Kennwort")]
        [DataType(DataType.Password)]
        [Required]
        public string NewPassword { get; set; }

        [DisplayName("Neues Kennwort bestätigen")]
        [DataType(DataType.Password)]
        [Required]
        [Compare(nameof(NewPassword), ErrorMessage = "Die eingegebenen Kennwörter stimmen nicht überein")]
        public string NewPasswordConfirmation { get; set; }

        // Admins only
        public NotificationConfiguration NotificationConfiguration { get; set; }
    }
}
