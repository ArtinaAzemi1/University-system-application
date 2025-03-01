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

        public virtual List<Group>? Group { get; set; }

    }
}
