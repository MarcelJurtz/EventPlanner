using ClubGrid.Models.Helper;
using ClubGrid.ResourceHelpers;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ClubGrid.Models
{
    [Table("event")]
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

        [Display(Name = ModelStrings.DESIGNATION, ResourceType = typeof(Interface.Resources.ClubGrid))]
        [Required(ErrorMessageResourceType = typeof(Interface.Resources.DataAnnotations.ErrorMessages), ErrorMessageResourceName = ModelStrings.REQUIRE_DESIGNATION)]
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

        [Display(Name = ModelStrings.DESCRIPTION, ResourceType = typeof(Interface.Resources.ClubGrid))]
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

        [Display(Name = ModelStrings.LOCATION, ResourceType = typeof(Interface.Resources.Event))]
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

        [Display(Name = ModelStrings.START, ResourceType = typeof(Interface.Resources.Event))]
        [Required(ErrorMessageResourceType = typeof(Interface.Resources.DataAnnotations.ErrorMessages), ErrorMessageResourceName = ModelStrings.REQUIRE_START)]
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

        [Display(Name = ModelStrings.END, ResourceType = typeof(Interface.Resources.Event))]
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

        [Display(Name = ModelStrings.MEETING_LOCATION, ResourceType = typeof(Interface.Resources.Event))]
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

        [Display(Name = ModelStrings.MEETING_TIME, ResourceType = typeof(Interface.Resources.Event))]
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

        [Display(Name = ModelStrings.SEATS_REQUIRED, ResourceType = typeof(Interface.Resources.Event))]
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

        [Display(Name = ModelStrings.PLAYERS_REQUIRED, ResourceType = typeof(Interface.Resources.Event))]
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

        [Display(Name = ModelStrings.COACHES_REQUIRED, ResourceType = typeof(Interface.Resources.Event))]
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

        [Display(Name = ModelStrings.SCORERS_REQUIRED, ResourceType = typeof(Interface.Resources.Event))]
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

        [Display(Name = ModelStrings.UMPIRES_REQUIRED, ResourceType = typeof(Interface.Resources.Event))]
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

        [Display(Name = ModelStrings.CREATED, ResourceType = typeof(Interface.Resources.ClubGrid))]
        [Column("created")]
        public DateTime Created { get; set; }

        [Display(Name = ModelStrings.UPDATED, ResourceType = typeof(Interface.Resources.ClubGrid))]
        [Column("modified")]
        public DateTime Modified { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Modified = DateTime.Now;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
