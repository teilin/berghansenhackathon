using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BergHansenHackathon.Models
{
    public class Review
    {
        public string id { get; set; }
        public string lang { get; set; }
        public string location_id { get; set; }
        public string published_date { get; set; }
        public int rating { get; set; }
        public string helpful_votes { get; set; }
        public string rating_image_url { get; set; }
        public string url { get; set; }
        public string trip_type { get; set; }
        public string travel_date { get; set; }
        public string text { get; set; }
        public TAUser user { get; set; }
        public string title { get; set; }
        public bool is_machine_translated { get; set; }
    }
}
