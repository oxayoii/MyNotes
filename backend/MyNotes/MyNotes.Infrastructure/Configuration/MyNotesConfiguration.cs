using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNotes.Core.Models;

namespace MyNotes.Infrastructure.Configuration
{
    public class MyNotesConfiguration : IEntityTypeConfiguration<Notes>
    {
        public void Configure(EntityTypeBuilder<Notes> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(300);
            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
