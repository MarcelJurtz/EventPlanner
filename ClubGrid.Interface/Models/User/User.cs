using ClubGrid.ResourceHelpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubGrid.Models
{
    [Table("user")]
    public class User : IdentityUser
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int UserId { get; set; }

        [Display(Name = ModelStrings.USER_REGISTERED, ResourceType = typeof(Interface.Resources.User))]
        [Column("registered")]
        public DateTime Registered { get; set; }

        [Column("verified")]
        public bool Verified { get; set; }
    }
}
