using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HolidayGroupie.Models;

namespace HolidayGroupie.Models
{
    public class User
    {
        public int Id { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Display(Name ="Retype Password")]
        [ComparePassword]
        public string PasswordCheck { get; set; }

        public Friend FriendAccount { get; set; }
        public Boolean isAdmin { get; set; }
    }
}