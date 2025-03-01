using System.Collections;
using System.Text.Json.Serialization;

namespace UniversityProject.Models
{
    public class Location
    { 
        public int? LocationId { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public ICollection<Hall>? Hall { get; set; }
    }
}
