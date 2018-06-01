using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Planner.Models
{
    public class TeamAssociation : INotifyPropertyChanged
    {
        private int _userId;
        private Team _team;
        private int _teamId;
        private TeamRole _role;

        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        public int Id { get; set; }

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

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Modified = DateTime.Now;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
