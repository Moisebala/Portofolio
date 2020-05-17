using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Portofolio.Models
{
    public class Contact
    {   public int Id { get; set; }

		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
		[StringLength(50)]
		public string Telephone { get; set; }
        public string Adresse { get; set; }

    }
}