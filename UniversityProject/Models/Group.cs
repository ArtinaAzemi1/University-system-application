using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int Capacity { get; set; }

        public int ScheduleId { get; set; }
        [ForeignKey(nameof(ScheduleId))]
        public virtual Schedule Schedule { get; set; }
    }
}
