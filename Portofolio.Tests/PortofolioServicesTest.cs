using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portofolio.Models;

namespace Portofolio.Tests
{
    [TestClass]
    public class PortofolioServicesTest
    {
        [TestMethod]
        public void ObtenirLaListdesUtilisateur_Et_Verifier_Que_CestPas_Vide()
        {
            //IDatabaseInitializer<PortofolioContext> init = new DropCreateDatabaseAlways<PortofolioContext>();
            //Database.SetInitializer(init);
            //init.InitializeDatabase(new PortofolioContext());
            using (IDataAccess service = new PortofolioServices())
            {
                List<User> utilisateurs = service.ObtientTousLesUtilisateurs();

                Assert.AreEqual("Alexander", utilisateurs[0].Prenom);
                Assert.IsNotNull(utilisateurs);
                Assert.AreEqual(2, utilisateurs.Count);   
            }
        }
    }
}
