using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalDataModel.Models.Mapping
{
    public class DocumentLibraryMap : EntityTypeConfiguration<DocumentLibrary>
    {
        public DocumentLibraryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("DocumentLibrary");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.WebId).HasColumnName("WebId");

            // Relationships
            this.HasRequired(t => t.Web)
                .WithMany(t => t.DocumentLibraries)
                .HasForeignKey(d => d.WebId);

        }
    }
}
