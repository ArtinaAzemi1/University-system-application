﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityProject.Models
{
    public class Hall
    {
        public int HallID { get; set; }

        public string HallCode { get; set; }

        public string Type { get; set; }

        public string HallCapacity { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}
