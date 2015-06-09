using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalDataModel.Models.Mapping
{
    public class CPFileMap : EntityTypeConfiguration<CPFile>
    {
        public CPFileMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FileContent)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("CPFile");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.FileContentB).HasColumnName("FileContentB");
            this.Property(t => t.DocLibId).HasColumnName("DocLibId");
            this.Property(t => t.FileContent).HasColumnName("FileContent");
            this.Property(t => t.FileGUID).HasColumnName("FileGUID");

            // Relationships
            this.HasRequired(t => t.DocumentLibrary)
                .WithMany(t => t.CPFiles)
                .HasForeignKey(d => d.DocLibId);

        }
    }
}
