using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalDataModel.Models.Mapping
{
    public class NewsMap : EntityTypeConfiguration<News>
    {
        public NewsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("News");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Context).HasColumnName("Context");
            this.Property(t => t.PostDate).HasColumnName("PostDate");
            this.Property(t => t.WebId).HasColumnName("WebId");

            // Relationships
            this.HasRequired(t => t.Web)
                .WithMany(t => t.News)
                .HasForeignKey(d => d.WebId);

        }
    }
}
