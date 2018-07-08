using ClubGrid.ResourceHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubGrid.Models
{
    [Table("notification_configuration")]
    public class NotificationConfiguration
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = ModelStrings.ADMINISTRATOR, ResourceType = typeof(Interface.Resources.NotificationConfiguration))]
        [Column("admin_id")]
        [ForeignKey(nameof(User))]
        public int AdminId { get; set; }

        [Display(Name = ModelStrings.NEW_USER_REGISTERED, ResourceType = typeof(Interface.Resources.NotificationConfiguration))]
        [Column("new_user_registered")]
        public bool NewUserRegistered { get; set; }

        [Display(Name = ModelStrings.EVENT_PARTICIPATION_UPDATED, ResourceType = typeof(Interface.Resources.NotificationConfiguration))]
        [Column("user_participation_updated")]
        public bool UserParticipationUpdated { get; set; }
    }
}
