using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HolidayGroupie.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public Friend OrganizerId { get; set; }

        [Required]
        [Display(Name = "When")]
        public DateTime? Date { get; set; }

        [Required]
        [Display(Name ="Where")]
        public string Location { get; set; }

        public List<Item> Items { get; set; }
        public List<Friend> Attendees { get; set; }
    }
}