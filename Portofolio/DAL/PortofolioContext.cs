
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Portofolio.Models;

namespace Portofolio.DAL
{
    public class PortofolioContext:DbContext
    {
        public PortofolioContext() : base("PortofolioContext")
        {
        }
        public DbSet<User> Utilisateur { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}