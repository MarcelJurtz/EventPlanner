using Planner.Models.Helper;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Planner.Models
{
    [Table("team_association")]
    public class TeamAssociation : INotifyPropertyChanged
    {
        private int _userId;
        private Team _team;
        private int _teamId;
        private TeamRole _role;

        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [ForeignKey(nameof(Team))]
        [Column("team_id")]
        public int TeamId
        {
            get { return _teamId; }
            set
            {
                if (_teamId != value)
                {
                    _teamId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [NotMapped]
        public Team Team
        {
            get { return _team; }
            set
            {
                if(_team != value)
                {
                    _team = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Column("role")]
        public TeamRole Role
        {
            get { return _role; }
            set
            {
                if(_role != value)
                {
                    _role = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName(DisplayNames.CREATED)]
        [Column("created")]
        public DateTime Created { get; set; }

        [DisplayName(DisplayNames.MODIFIED)]
        [Column("modified")]
        public DateTime Modified { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Modified = DateTime.Now;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
