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
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Event> Events { get; set; }
        public List<Friend> Friends { get; set; }
    }
}