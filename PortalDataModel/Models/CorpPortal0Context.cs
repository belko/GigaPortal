using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PortalDataModel.Models.Mapping;

namespace PortalDataModel.Models
{
    public class CorpPortal0Context : DbContext
    {
        static CorpPortal0Context()
        {
            Database.SetInitializer<CorpPortal0Context>(null);
        }

		public CorpPortal0Context()
			: base("Name=CorpPortal0Context")
		{
		}

        public DbSet<CPFile> CPFiles { get; set; }
        public DbSet<DocumentLibrary> DocumentLibraries { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Web> Webs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CPFileMap());
            modelBuilder.Configurations.Add(new DocumentLibraryMap());
            modelBuilder.Configurations.Add(new NewsMap());
            modelBuilder.Configurations.Add(new PageMap());
            modelBuilder.Configurations.Add(new WebMap());
        }
    }
}
