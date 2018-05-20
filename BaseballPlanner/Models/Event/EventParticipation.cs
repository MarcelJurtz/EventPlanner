using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Planner.Models
{
    public class EventParticipation : INotifyPropertyChanged
    {
        private int _userId;
        private int _eventId;
        private Event _event;
        private int _seats;
        private bool _isPlayer;
        private bool _isCoach;
        private bool _isUmpire;
        private bool _isScorer;
        private string _note;

        public event PropertyChangedEventHandler PropertyChanged;

        public EventParticipation()
        {
            Created = DateTime.Now;
            Modified = Created;
        }

        [Key]
        public int Id { get; set; }

        public int UserId
        {
            get { return _userId; }
            set
            {
                if(_userId != value)
                {
                    _userId = value;
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
                if(_event != value)
                {
                    _event = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int Seats
        {
            get { return _seats; }
            set
            {
                if(_seats != value)
                {
                    _seats = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsPlayer
        {
            get { return _isPlayer; }
            set
            {
                if(_isPlayer != value)
                {
                    _isPlayer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsCoach
        {
            get { return _isCoach; }
            set
            {
                if(_isCoach != value)
                {
                    _isCoach = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsUmpire
        {
            get { return _isUmpire; }
            set
            {
                if(_isUmpire != value)
                {
                    _isUmpire = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsScorer
        {
            get { return _isScorer; }
            set
            {
                if(_isScorer != value)
                {
                    _isScorer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [StringLength(100)]
        public string Note
        {
            get { return _note; }
            set
            {
                if(_note != value)
                {
                    _note = value;
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
