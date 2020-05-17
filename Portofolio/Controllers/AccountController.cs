using Portofolio.Models;
using Portofolio.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portofolio.Controllers
{
    public class AccountController : Controller
    {
		private IDataAccess dal = new PortofolioServices();

		[HttpGet]
		public ActionResult Register()
		{
		
			return View();
		}
		// GET: Account
		[HttpPost]
		public ActionResult Register(User user)
        {  
			dal.CreerUtilisateur(user.Nom, 
				                 user.Prenom,
				                 user.Identifiant, 
								 user.Motdepasse, 
								 user.Type);
	
			return View(user);
		}

		[HttpGet]
		public ActionResult ListUser()
		{

			return View();
		}

		public ActionResult Login()
        {
            return View();
        }
    }
}