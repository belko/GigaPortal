using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalDataModel.Models.Mapping
{
    public class WebMap : EntityTypeConfiguration<Web>
    {
        public WebMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Web");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IsRoot).HasColumnName("IsRoot");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.BreadCrumbs).HasColumnName("BreadCrumbs");
            this.Property(t => t.ParentWebId).HasColumnName("ParentWebId");

            // Relationships
            this.HasOptional(t => t.Web2)
                .WithMany(t => t.Web1)
                .HasForeignKey(d => d.ParentWebId);

        }
    }
}
