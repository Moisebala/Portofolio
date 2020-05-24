using System;
using System.Collections.Generic;


namespace Portofolio.Models
{
    public interface IDataAccess:IDisposable
    {
        List<User> ObtientTousLesUtilisateurs();
		User CreerUtilisateur(string nom, string prenom, string identifiant, string motdepasse, TypeEnum type);
		User ModifierUtilisateur(int id, string nom, string prenom, string identifiant, string motdepasse, TypeEnum type);
		User Authentifier(string nom, string motDePasse);
		bool UtilisateurExiste(string identifiant);
		User ObtenirUtilisateur(int? id);
		User ObtenirUtilisateur(string idStr);
		void SupprimerUtilisateur(User user);


	}
}
