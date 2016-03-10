using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BergHansenHackathon.Models
{
    public class Geo
    {
        public string name { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string countryName { get; set; }
        public string stateName { get; set; }
        public string state { get; set; }
        public string category { get; set; }
        public string id { get; set; }
        public string dataset { get; set; }
        public string datasource { get; set; }
        public string confidenceFactor { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string iataCityCode { get; set; }
        public string ranking { get; set; }
    }
}
