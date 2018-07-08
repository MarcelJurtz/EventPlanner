using ClubGrid.Models.Helper;
using ClubGrid.ResourceHelpers;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ClubGrid.Models
{
    [Table("news")]
    public class News : INotifyPropertyChanged
    {
        private string _content;

        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("content")]
        [Display(Name = ModelStrings.CONTENT, ResourceType = typeof(Interface.Resources.News))]
        [StringLength(250)]
        public string Content
        {
            get { return _content; }
            set
            {
                if(_content != value)
                {
                    _content = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [NotMapped]
        [DisplayFormat(DataFormatString = DisplayFormats.DATE_ONLY)]
        public DateTime GroupableDate
        {
            get
            {
                var date = new DateTime();
                date = date.AddYears(Created.Year -1);
                date = date.AddMonths(Created.Month -1);
                date = date.AddDays(Created.Day -1);
                return date;
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
