﻿using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models.Auth
{
    public class Register
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
