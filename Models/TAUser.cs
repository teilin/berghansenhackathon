using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BergHansenHackathon.Models
{
    public class TAUser
    {
        public string username { get; set; }
        public TAUserLocation user_location { get; set; }
    }
    
    public class TAUserLocation
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}