using Planner.Models.Helper;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Planner.Models
{
    public class Event : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _designation;
        private string _description;
        private string _location;
        private DateTime _start = DateTime.Today;
        private DateTime? _end;
        private string _meetingLocation;
        private DateTime _meetingTime = DateTime.Today;
        private int _seatsRequired { get; set; }
        private int _playersRequired { get; set; }
        private int _coachesRequired { get; set; }
        private int _scorersRequired { get; set; }
        private int _umpiresRequired { get; set; }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [DisplayName(DisplayNames.DESIGNATION)]
        [Required(ErrorMessage = "Bitte geben Sie eine Bezeichnung an")]
        [StringLength(100)]
        [Column("designation")]
        public string Designation
        {
            get { return _designation; }
            set
            {
                if (_designation != value)
                {
                    _designation = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName(DisplayNames.DESCRIPTION)]
        [StringLength(500)]
        [Column("description")]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName(DisplayNames.LOCATION)]
        [StringLength(50)]
        [Column("location")]
        public string Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName(DisplayNames.START)]
        [Required(ErrorMessage = "Bitte geben Sie einen Startzeitpunkt an")]
        [Column("start")]
        public DateTime Start
        {
            get { return _start; }
            set
            {
                if (_start != value)
                {
                    _start = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName(DisplayNames.END)]
        [Column("end")]
        public DateTime? End
        {
            get { return _end; }
            set
            {
                if (_end != value)
                {
                    _end = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName("Treffpunkt")]
        [StringLength(100)]
        [Column("meeting_location")]
        public string MeetingLocation
        {
            get { return _meetingLocation; }
            set
            {
                if (_meetingLocation != value)
                {
                    _meetingLocation = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName("Treffpunkt Uhrzeit")]
        [Column("meeting_time")]
        public DateTime MeetingTime
        {
            get { return _meetingTime; }
            set
            {
                if (_meetingTime != value)
                {
                    _meetingTime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName("Sitzplätze benötigt")]
        [Column("seats_required")]
        public int SeatsRequired
        {
            get { return _seatsRequired; }
            set
            {
                if (_seatsRequired != value)
                {
                    _seatsRequired = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName(DisplayNames.REQUIRED_PLAYERS)]
        [Column("players_required")]
        public int PlayersRequired
        {
            get { return _playersRequired; }
            set
            {
                if (_playersRequired != value)
                {
                    _playersRequired = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName(DisplayNames.REQUIRED_COACHES)]
        [Column("coaches_required")]
        public int CoachesRequired
        {
            get { return _coachesRequired; }
            set
            {
                if (_coachesRequired != value)
                {
                    _coachesRequired = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName(DisplayNames.REQUIRED_SCORERS)]
        [Column("scorers_required")]
        public int ScorersRequired
        {
            get { return _scorersRequired; }
            set
            {
                if(_scorersRequired != value)
                {
                    _scorersRequired = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName(DisplayNames.REQUIRED_UMPIRES)]
        [Column("umpires_required")]
        public int UmpiresRequired
        {
            get { return _umpiresRequired; }
            set
            {
                if(_umpiresRequired != value)
                {
                    _umpiresRequired = value;
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
