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

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public ActionResult ListUser()
		{
			UserModelView list = new UserModelView();
			list.Users = dal.ObtientTousLesUtilisateurs();

			return View(list);
		}


		[HttpGet]
		public ActionResult UserDetail(int id)
		{
			var user = dal.ObtenirUtilisateur(id);
			return View(user);
		}

		public ActionResult Login()
		{
			return View();
		}

		public ActionResult ModifierUser()
		{
			string id = Request.Url.AbsolutePath.Split('/').Last();
			ViewBag.Id = id;
			return View();
		}

		public ActionResult SupprimerUser(int id)
		{
			var user = dal.ObtenirUtilisateur(id);
			if (user != null)
			{
				dal.SupprimerUtilisateur(user);
			}
			return View();
		}
	}
}