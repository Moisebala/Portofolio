using Portofolio.Models;
using Portofolio.ModelsView;
using System;
using System.Linq;
using System.Net;
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
								 user.Type,
								 user.Contact.Email,
								 user.Contact.Telephone);

			return RedirectToAction("ListUser", "Account");
		}

		[HttpGet]
		public ActionResult ListUser()
		{
	
			var users = dal.ObtientTousLesUtilisateurs();
			var userViewModel = users.Select(user => new UserModelView(user)).ToList();

			return View("~/Views/Account/ListUser.cshtml", userViewModel);
		}

		[HttpGet]
		public ActionResult UserDetail(int? id )
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var user = dal.ObtenirUtilisateur(id);
			return PartialView("Userdetail",user);
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpGet]
		public ActionResult ModifierUser(int? id)
		{

			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var user = dal.ObtenirUtilisateur(id);
			return View("ModifierUser", user);
		}

		[HttpPost]
		public ActionResult ModifierUser(User user)
		{
			dal.ModifierUtilisateur(user.Id,
				                    user.Nom, 
				                    user.Prenom, 
									user.Identifiant, 
									user.Motdepasse,
									user.Type,user.Contact.Email, 
									user.Contact.Telephone);
			// string id = Request.Url.AbsolutePath.Split('/').Last();
			//ViewBag.Id = id;
			return RedirectToAction("ListUser", "Account");
		}

		[HttpPost]
		public ActionResult SupprimerUser()
		{
			var id = int.Parse(Request.Params["id"]);
			var user = dal.ObtenirUtilisateur(id);
			try
			{
				if (user != null)
			    {
				dal.SupprimerUtilisateur(user);
			    }
			}
			catch (Exception e)
			{
				Response.StatusCode = 403;
			}

			return Content("");
		}
	}
}