﻿
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Portofolio.Models;


namespace Portofolio.ModelsView
{
	public class RegisterViewModel
	{
		[Required]
		[Display(Name = "UserName")]
		public string UserName { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[Required]
		[StringLength(50)]
		public string Phone { get; set; }


		public RegisterViewModel(string username, string email, string password, string confirmpassord, string phone)
		{
			var user = new User();
			username = user.Identifiant;
			email = user.contact.Email;
			password = user.Motdepasse;
			confirmpassord = password;
			phone = user.contact.Telephone;
		}
	}
	
}