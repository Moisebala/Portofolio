namespace Portofolio.Migrations
{
    using Portofolio.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Portofolio.DAL.PortofolioContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Portofolio.DAL.PortofolioContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
           // context.Utilisateurs.AddOrUpdate(
             //   new User { Nom = "Carson", Prenom = "Alexander", Identifiant = "CarsonA", Motdepasse = "1233456", Type = TypeEnum.Admin },
               // new User { Nom = "son", Prenom = "xander", Identifiant = "sonA", Motdepasse = "1233456", Type = TypeEnum.Stantard });
        }
    }
}
