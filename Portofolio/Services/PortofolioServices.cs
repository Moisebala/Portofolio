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
            return bdd.Utilisateur.ToList();
        }

    }
}