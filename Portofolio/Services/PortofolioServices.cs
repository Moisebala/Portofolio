using Portofolio.DAL;
using Portofolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Portofolio
{
    public class PortofolioServices:IDataAccess
    {
        private PortofolioContext bdd;

        public PortofolioServices()
        {
            bdd = new PortofolioContext();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public List<User> ObtientTousLesUtilisateurs()
        {
            return bdd.Utilisateurs.ToList();
        }

        public User CreerUtilisateur(string nom,string prenom, string identifiant, string motdepasse, TypeEnum type, string email , string telephone)
        {
			Contact cont = new Contact{ Email = email,
				                       Telephone = telephone };
			string motDePasseEncode = EncodeMD5(motdepasse);
			User user = new User();
            user.Nom = nom;
			user.Prenom = prenom;
            user.Identifiant = identifiant;
            user.Motdepasse = motDePasseEncode;
            user.Type = type;
			user.Contact = cont;

			bdd.Utilisateurs.Add(user);
            bdd.SaveChanges();
            return user; 
        }
		public User ModifierUtilisateur(int id , string nom,string prenom , string identifiant, string motdepasse, TypeEnum type ,string email , string telephone)
		{
			string motDePasseEncode = EncodeMD5(motdepasse);
			User userTrouver = bdd.Utilisateurs.FirstOrDefault(u => u.Id == id); 
			if (userTrouver!=null)
			{
				Contact cont = new Contact
				{
					Email = email,
					Telephone = telephone
				};
				userTrouver.Nom = nom;
				userTrouver.Prenom = prenom;
				userTrouver.Identifiant = identifiant;
				userTrouver.Motdepasse = motDePasseEncode;
				userTrouver.Type = type;
				userTrouver.Contact = cont;
				userTrouver.Contact.Telephone = cont.Telephone; 
		        bdd.SaveChanges();
			}
			return userTrouver;
		}

		public bool UtilisateurExiste(string identifiant)
		{
			return bdd.Utilisateurs.Any(u => string.Compare(u.Identifiant, identifiant, StringComparison.CurrentCultureIgnoreCase) == 0);
		}

		public User Authentifier(string identifiant, string motDePasse)
		{
			string motDePasseEncode = EncodeMD5(motDePasse);
			return bdd.Utilisateurs.FirstOrDefault(u => u.Identifiant == identifiant && u.Motdepasse == motDePasseEncode);
		}

		private string EncodeMD5(string motDePasse)
		{
			string motDePasseSel = "zay" + motDePasse + "land";
			return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
		}

		public User ObtenirUtilisateur(int? id)
		{
			return bdd.Utilisateurs.FirstOrDefault(u => u.Id == id);
		}

		public User ObtenirUtilisateur(string idStr)
		{
			int id;
			if (int.TryParse(idStr, out id))
				return ObtenirUtilisateur(id);
			return null;
		}

		public void SupprimerUtilisateur(User user)
		{
			bdd.Utilisateurs.Remove(user);
			bdd.SaveChanges();
		}
	}
}