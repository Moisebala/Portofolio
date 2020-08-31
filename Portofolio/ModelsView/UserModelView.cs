using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portofolio.Models;

namespace Portofolio.ModelsView
{
    public class UserModelView
    {
		public  User User { get; set; }
		

		public  UserModelView(User user)
		{
			User = user;
		}

	}
}