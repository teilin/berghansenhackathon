using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BergHansenHackathon.Models
{
    public class Trip
    {
        [KeyAttribute]
        public int Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime? DepartureDateTime { get; set; }
        public DateTime? DestinationDateTime { get; set; }

        [Required]        
        public int UserId { get; set; }
    }
}
