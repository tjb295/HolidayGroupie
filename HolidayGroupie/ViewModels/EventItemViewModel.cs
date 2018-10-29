using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HolidayGroupie.Models;

namespace HolidayGroupie.ViewModels
{
    public class EventItemViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public Item Item { get; set; }
        public Event Event { get; set; }
        public IEnumerable<Friend> Friends { get; set; }
        public IEnumerable<Friend> SearchableFriends { get; set; }
    }
}