using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoPitLive
{
    public class MusicGigsEntity
    {
        public long GigDate { get; set; }
        public DateTime GigDateDisplay { get; set; }
        public string GigDateShortDisplay { get; set; }
        public string GigMonth { get { return GigDateDisplay.Month.ToString();} }
        public string GigMonth2 { get { return GigDateDisplay.ToString("MMMM"); } }
        public string GigMonth3 { get { return GigDateDisplay.ToString("yyyy-MM-dd") + "_" + Guid.NewGuid(); } }
        public string Artist { get; set; } = default!;
        public long Venue { get; set; }
        public string VenueDisplay { get; set;  }
        public string Url { get; set; }
    }

    public class VenueList
    {
        public string VenueDisplay { get; set; }
        public int CountOfGigs { get; set; }
        public string NormalisedName { get; set; }
    }
}
