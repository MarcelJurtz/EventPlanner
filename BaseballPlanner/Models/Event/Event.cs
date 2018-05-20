using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Planner.Models
{
    public class Event : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _designation;
        private string _description;
        private string _location;
        private DateTime _start;
        private DateTime? _end;
        private string _meetingLocation;
        private DateTime _meetingTime;

        public Event()
        {
            Created = DateTime.Now;
            Modified = Created;
        }

        [BindNever]
        public int Id { get; set; }

        [DisplayName("Bezeichnung")]
        [Required(ErrorMessage = "Bitte geben Sie eine Bezeichnung an")]
        [StringLength(100)]
        public string Designation
        {
            get { return _designation; }
            set
            {
                if(_designation != value)
                {
                    _designation = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName("Beschreibung")]
        [StringLength(500)]
        public string Description
        {
            get { return _description; }
            set
            {
                if(_description != value)
                {
                    _description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName("Ort")]
        [StringLength(50)]
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

        [DisplayName("Start")]
        [Required(ErrorMessage = "Bitte geben Sie einen Startzeitpunkt an")]
        public DateTime Start
        {
            get { return _start; }
            set
            {
                if(_start != value)
                {
                    _start = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName("Ende")]
        public DateTime? End
        {
            get { return _end; }
            set
            {
                if(_end != value)
                {
                    _end = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName("Treffpunkt")]
        [StringLength(100)]
        public string MeetingLocation
        {
            get { return _meetingLocation; }
            set
            {
                if(_meetingLocation != value)
                {
                    _meetingLocation = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DisplayName("Treffpunkt Uhrzeit")]
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

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Modified = DateTime.Now;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
