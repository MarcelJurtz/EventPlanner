using System.ComponentModel;
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

        [DisplayName("Administrator")]
        [Column("admin_id")]
        [ForeignKey(nameof(User))]
        public int AdminId { get; set; }

        [DisplayName("Neuer Benutzer registriert")]
        [Column("new_user_registered")]
        public bool NewUserRegistered { get; set; }

        [DisplayName("Eventteilnahme eines Benutzers aktualisiert")]
        [Column("user_participation_updated")]
        public bool UserParticipationUpdated { get; set; }
    }
}
