using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portofolio.DAL;
using Portofolio.Models;

namespace Portofolio.Tests
{

	[TestClass]
    public class PortofolioServicesTest
    {

		[TestInitialize]
		public void Init_AvantChaqueTest()
		{
			IDatabaseInitializer<PortofolioContext> init = new DropCreateDatabaseAlways<PortofolioContext>();
			Database.SetInitializer(init);
			init.InitializeDatabase(new PortofolioContext());
		}
		[TestMethod]
        public void ObtenirLaListdesUtilisateur_Et_Verifier_Que_CestPas_Vide()
        {
			//IDatabaseInitializer<PortofolioContext> init = new DropCreateDatabaseAlways<PortofolioContext>();
			//Database.SetInitializer(init);
			//init.InitializeDatabase(new PortofolioContext());
			using (IDataAccess service = new PortofolioServices())
			{
			
		        User user1 = service.CreerUtilisateur("Mo", "balla", "252556", TypeEnum.Admin);
				User user2 = service.CreerUtilisateur("Moise", "Alex", "256736", TypeEnum.Admin);

				List<User> utilisateurs = service.ObtientTousLesUtilisateurs();

				Assert.AreEqual("Mo", utilisateurs[0].Nom);
				Assert.IsNotNull(utilisateurs);
				Assert.AreEqual(2, utilisateurs.Count);
			}
        }
    }
}
