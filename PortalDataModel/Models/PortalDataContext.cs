using GigaPortalData.Models.Collections;
using GigaPortalData.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaPortalData.Models
{
    public class PortalDataContext : DbContext
    {
        public PortalDataContext() : base("PortalDataContext") { }

        public DbSet<GPWeb> Webs { get; set; }
        public DbSet<GPPagesCollection> PagesCollections { get; set; }
        public DbSet<GPPage> Pages { get; set; }
        public DbSet<GPNewsCollection> NewsesCollections { get; set; }
        public DbSet<GPNews> Newses { get; set; }
        

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
