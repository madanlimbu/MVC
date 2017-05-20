using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Research.Models
{
    public class User
    {
        public User()
        {
            this.Events = new HashSet<Event>();
        }
        public int UserID { get; set; }
        [Required(ErrorMessage ="Please Insert Name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Insert Email.")]
        public string Email { get; set; }
      
        public string DateOfBirth { get; set; }
      
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Insert Name.")]
        public string Address { get; set; }
       
        public string Home_Number { get; set; }
       
        public string Mobile_Number { get; set; }
      
        public string Work_Number { get; set; }
        [Required(ErrorMessage = "Please Insert Name.")]
        public string Work_Location { get; set; }
        [Required(ErrorMessage = "Please Insert Email.")]
        public string Biography { get; set; }
        public ICollection<String> Key_Skills { get; set; }

        public virtual ICollection<Event> Events { get; set; }

    }
    
}