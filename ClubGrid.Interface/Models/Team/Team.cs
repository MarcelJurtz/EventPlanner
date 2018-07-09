using ClubGrid.Models.Helper;
using ClubGrid.ResourceHelpers;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ClubGrid.Models
{
    [Table("team")]
    public class Team : INotifyPropertyChanged
    {
        private string _designation;

        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Display( Name = ModelStrings.DESIGNATION, ResourceType = typeof(Interface.Resources.ClubGrid))]
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

        [NotMapped]
        public bool Selected { get; set; }

        [Display(Name = ModelStrings.CREATED, ResourceType = typeof(Interface.Resources.ClubGrid))]
        [Column("created")]
        public DateTime Created { get; set; }

        [Display(Name = ModelStrings.UPDATED, ResourceType = typeof(Interface.Resources.ClubGrid))]
        [Column("updated")]
        public DateTime Modified { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Modified = DateTime.Now;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
