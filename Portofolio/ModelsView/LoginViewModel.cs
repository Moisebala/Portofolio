using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portofolio.ModelsView
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Username")]
		public string Identifiant { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Motdepasse { get; set; }

		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
	}
}