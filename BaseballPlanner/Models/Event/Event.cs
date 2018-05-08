using System;
using System.Collections.Generic;

namespace Planner.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string MeetingLocation { get; set; }
        public DateTime MeetingTime { get; set; }

        public IEnumerable<Team> Teams { get; set; }

        public Administrator CreatedBy { get; set; }
        public Administrator ModifiedBy { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
