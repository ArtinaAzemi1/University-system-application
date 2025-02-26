using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string? Email { get; set; }

        public string? Username { get; set; }

        public string? AspNetUserId { get; set; }
        [ForeignKey("AspNetUserId")]
        public IdentityUser AspNetUser { get; set; }
    }

}
