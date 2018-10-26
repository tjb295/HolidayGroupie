using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HolidayGroupie.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public string Location { get; set; }
        
    }
}
