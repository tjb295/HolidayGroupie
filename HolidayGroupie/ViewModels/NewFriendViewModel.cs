using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HolidayGroupie.Models;

namespace HolidayGroupie.ViewModels
{
    public class NewFriendViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set;  }
        public Friend Friend { get; set; }
    }
}