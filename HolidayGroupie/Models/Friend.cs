using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HolidayGroupie.Models
{
    public class Friend
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Event UpcomingEvent { get; set; }

        public MembershipType MembershipType { get; set; }

        //[Display(Name = "Membership Type")]
        //public byte MembershipTypeId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<Event> Events { get; set; }

        public List<Friend> Friends { get; set; }
    }
}