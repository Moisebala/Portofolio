using Portofolio.DAL;
using Portofolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public User CreerUtilisateur(string nom, string identifiant, string motdepasse, TypeEnum type)
        {
            User user = new User();
            user.Nom = nom;
            user.Identifiant = identifiant;
            user.Motdepasse = motdepasse;
            user.Type = type;
      
            bdd.Utilisateurs.Add(user);
            bdd.SaveChanges();
            return user; 
        }

    }
}