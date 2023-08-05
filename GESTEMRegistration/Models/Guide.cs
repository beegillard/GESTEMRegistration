using System;
using System.ComponentModel.DataAnnotations;

namespace GESTEMRegistration.Models
{
	public class Guide
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool PrevVolunteer { get; set; }

    }
}

