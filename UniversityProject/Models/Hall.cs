using System.Text.Json.Serialization;

namespace UniversityProject.Models
{
    public class Hall
    {
        public int HallID { get; set; }

        public string? HallCode { get; set; }

        public string? Type { get; set; }

        public int? HallCapacity { get; set; }

        public int? LocationID { get; set; }

        
        public Location Location { get; set; }
    }
}
