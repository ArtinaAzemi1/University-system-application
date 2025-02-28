using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string? StudentName { get; set; }

        public string? StudentSurname {get; set;}

        public string? Gender { get; set; }

        public string? AspNetUserId { get; set; }
        [ForeignKey("AspNetUserId")]
        public IdentityUser AspNetUser { get; set; }
    }
}
