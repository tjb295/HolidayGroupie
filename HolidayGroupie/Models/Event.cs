using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayGroupie.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Friend OrganizerId { get; set; }


        public DateTime? Date { get; set; }
        public string Location { get; set; }
        public List<Item> Items { get; set; }
        public List<Friend> Attendees { get; set; }
    }
}