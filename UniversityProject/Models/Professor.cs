using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }

        public string? ProfessorName { get; set; }

        public string? ProfessorSurname { get; set; }

        public string? AspNetUserId { get; set; }
        [ForeignKey("AspNetUserId")]
        public IdentityUser AspNetUser { get; set; }
    }
}
