using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BergHansenHackathon.Models
{
    public class TALocation
    {
        public int location_id { get; set; }
        public string name { get; set; }
        public int rating { get; set; }
        public string rating_image_url { get; set; }
        public int num_reviews { get ; set; }
        public int? percent_recommended { get; set; }
        public string write_review { get; set; }
        public string location_string { get; set; }
        public dynamic ranking_data { get; set; }
        public IList<Review> reviews { get; set; }
        public dynamic category { get; set; }
        public dynamic subcategory { get; set; }
        public dynamic review_rating_count { get; set; }
        public dynamic subratings { get; set; }
        public dynamic trip_types { get; set; }
        public dynamic awards { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string price_level { get; set; }
        public dynamic cuisine { get; set; }
        public dynamic attraction_types { get; set; }
        public dynamic category_counts { get; set; }
        public string web_url { get; set; }
        public dynamic ancestors { get; set; }
        public dynamic address_obj { get; set; }
        public int photo_count { get; set; }
        public string abbrv { get; set; }
        public string see_all_photos { get; set; }
        public string see_all_hotels { get; set; }
        public string see_all_attractions { get; set; }
        public string see_all_restaurants { get; set; }
    }
}