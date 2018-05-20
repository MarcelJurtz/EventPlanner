using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Planner.Models
{
    public class Team : INotifyPropertyChanged
    {
        private string _designation;

        public event PropertyChangedEventHandler PropertyChanged;

        public Team()
        {
            Created = DateTime.Now;
            Modified = Created;
        }

        [Key]
        public int Id { get; set; }

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

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Modified = DateTime.Now;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
