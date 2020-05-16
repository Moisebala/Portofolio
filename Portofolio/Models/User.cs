using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portofolio.Models
{
	[Table("User")]
	public class User
    {
        public int Id { get; set; }
		[Required]
		public string Nom { get; set; }
        public string Prenom { get; set; }
		[Required]
		public string Identifiant { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Motdepasse { get; set; }
		[Required]
		public TypeEnum Type { get; set; }
        public virtual Contact contact { get; set; }
    }
}
