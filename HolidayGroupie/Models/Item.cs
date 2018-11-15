using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayGroupie.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Friend Bringer { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}