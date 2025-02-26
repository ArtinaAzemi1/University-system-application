using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }

        public string? ProfessorName { get; set; }

        public string? ProfessorSurname { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
