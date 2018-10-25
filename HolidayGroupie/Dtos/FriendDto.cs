using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HolidayGroupie.Models;


namespace HolidayGroupie.Dtos
{
    public class FriendDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
       
        //if we want to add domain objects
        //we have to make them a dto as well

        public byte MembershipTypeId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
    }
}