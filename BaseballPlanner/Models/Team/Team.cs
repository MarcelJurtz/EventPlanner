using Microsoft.AspNetCore.Mvc.ModelBinding;
using Planner.Models.Helper;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Planner.Models
{
    public class Team : INotifyPropertyChanged
    {
        private string _designation;

        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        //[BindNever]
        public int Id { get; set; }

        [DisplayName(DisplayNames.DESIGNATION)]
        [Required(ErrorMessage = "Bitte geben Sie eine Bezeichnung an")]
        [StringLength(100)]
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

        [NotMapped]
        public bool Selected { get; set; }

        [DisplayName(DisplayNames.CREATED)]
        public DateTime Created { get; set; }

        [DisplayName(DisplayNames.MODIFIED)]
        public DateTime Modified { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Modified = DateTime.Now;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
