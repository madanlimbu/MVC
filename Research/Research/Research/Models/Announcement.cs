using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Research.Models
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string AnnounceDetail { get; set; }
    }
}