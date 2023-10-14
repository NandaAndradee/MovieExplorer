using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieExplorer.Domain.Models;

namespace MovieExplorer.Data.Mappings
{
    public class MovieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("movies");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .IsRequired();

            builder.Property(e => e.OriginalTitle)
                .HasColumnName("original_title")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired();
        }
    }
}
