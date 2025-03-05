using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace UniversityProject.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }

        public string Day { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public string Shift { get; set; }

        public int GroupId { get; set; }
        [ForeignKey(nameof(GroupId))]
        public virtual Group Group { get; set; }

        public int HallID { get; set; }
        [ForeignKey(nameof(HallID))]
        public virtual Hall Hall { get; set; }


        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }

    }
}
