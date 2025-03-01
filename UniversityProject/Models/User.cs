using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? AspNetUserId { get; set; }
        [ForeignKey("AspNetUserId")]
        public IdentityUser AspNetUser { get; set; }
    }
}
