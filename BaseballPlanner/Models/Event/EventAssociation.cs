using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Planner.Models
{
    public class EventAssociation : INotifyPropertyChanged
    {
        private int _teamId;
        private Team _team;
        private int _eventId;
        private Event _event;

        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId
        {
            get { return _teamId; }
            set
            {
                if(_teamId != value)
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

        [ForeignKey(nameof(Event))]
        public int EventId
        {
            get { return _eventId; }
            set
            {
                if(_eventId != value)
                {
                    _eventId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Event Event
        {
            get { return _event; }
            set
            {
                if (_event != value)
                {
                    _event = value;
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
