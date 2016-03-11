using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BergHansenHackathon.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public DateTime Available { get; set; }
    }
}