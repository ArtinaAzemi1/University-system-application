using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Capacity { get; set; }

        public virtual List<Schedule> Schedule { get; set; }
    }
}
