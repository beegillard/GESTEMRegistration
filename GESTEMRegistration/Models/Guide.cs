using System;
using System.ComponentModel.DataAnnotations;

namespace GESTEMRegistration.Models
{
	public class Guide
	{
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { email = value.ToLower(); }
        }

        [Display(Name = "Have you volunteered for GESTEM before?")]
        public bool PrevVolunteer { get; set; } = false;

    }
}

