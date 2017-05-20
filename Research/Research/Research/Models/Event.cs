using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Research.Models
{
    public class Event
    {
        public Event()
        {
            this.Users = new HashSet<User>();
        }
        public int EventID { get; set; }
        [Required(ErrorMessage = "Please Insert Event.")]
        public string EventName { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}