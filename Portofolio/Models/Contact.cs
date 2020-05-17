using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portofolio.Models
{
	[Table("Contact")]
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