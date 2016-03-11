using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BergHansenHackathon.Models
{
    public class MeetingRoom
    {
        public int Id { get; set; }
        public string Addresse { get; set; }
        public string City { get; set; }
        public List<Availability> Availability { get; set; }
        public int NumberOfPeople { get; set; }
        public bool HasProjector { get; set; }
        public bool HasInternet { get; set; }
        public string Facilities { get; set; }
        public string Description { get; set; }
    }
}