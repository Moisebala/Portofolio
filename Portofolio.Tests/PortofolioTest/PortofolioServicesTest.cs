using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portofolio.DAL;
using Portofolio.Models;

namespace Portofolio.Tests
{

	[TestClass]
    public class PortofolioServicesTest
    {
		private IDataAccess dal;

		[TestInitialize]
		public void Init_AvantChaqueTest()
		{
			IDatabaseInitializer<PortofolioContext> init = new DropCreateDatabaseAlways<PortofolioContext>();
			Database.SetInitializer(init);
			init.InitializeDatabase(new PortofolioContext());

			dal = new PortofolioServices();
		}

		[TestMethod]
        public void ObtenirLaListdesUtilisateur_Et_Verifier_Que_CestPas_Vide()
        {
			//IDatabaseInitializer<PortofolioContext> init = new DropCreateDatabaseAlways<PortofolioContext>();
			//Database.SetInitializer(init);
			//init.InitializeDatabase(new PortofolioContext());
			
		        User user1 = dal.CreerUtilisateur("Jena", "balla", "jballa","252556", TypeEnum.Admin, "jena@gmail.com" , "514255823");
				User user2 = dal.CreerUtilisateur("Moise", "Alex", "MAlex", "256736", TypeEnum.Admin, "jena@gmail.com", "514255823");

				List<User> utilisateurs = dal.ObtientTousLesUtilisateurs();

				Assert.AreEqual("Jena", utilisateurs[0].Nom);
				Assert.IsNotNull(utilisateurs);
				Assert.AreEqual(2, utilisateurs.Count);
			}
		[TestMethod]
		public void ModifierUser_CreationDUnNouveauUserEtChangementNom_LaModificationEstCorrecteApresRechargement()
		{

			User user1 = dal.CreerUtilisateur("Mo", "balla", "mballa", "252556", TypeEnum.Admin, "jena@gmail.com", "514255823");
			List<User> utilisateurs = dal.ObtientTousLesUtilisateurs();
			int id = utilisateurs.FirstOrDefault(r => r.Identifiant == "mballa").Id;

			dal.ModifierUtilisateur(id, "Mo", "balla", "zayland", "123546", TypeEnum.Stantard, "jena@gmail.com", "514255823");

			utilisateurs = dal.ObtientTousLesUtilisateurs();
			Assert.IsNotNull(utilisateurs);
			Assert.AreEqual(1, utilisateurs.Count);
			Assert.AreEqual("zayland", utilisateurs[0].Identifiant);


		}

		[TestMethod]
		public void ValiderUtilisateurExisteetCapabledetrIdentifier()
		{

			User user1 = dal.CreerUtilisateur("Mo", "balla", "mmmballa", "252556", TypeEnum.Admin, "jena@gmail.com", "514255823");
			List<User> utilisateurs = dal.ObtientTousLesUtilisateurs();
		
			bool existe = dal.UtilisateurExiste("mmmballa");
			User userauth = dal.Authentifier("mmmballa", "252556");

			Assert.IsTrue(existe);
			Assert.IsNotNull(userauth);
			Assert.AreEqual(userauth.Nom, user1.Nom);
		
		}
	}

}

