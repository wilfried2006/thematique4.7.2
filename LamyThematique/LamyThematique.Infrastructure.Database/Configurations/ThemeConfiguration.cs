using LamyThematique.Infrastructure.Database.Entities.Document;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LamyThematique.Infrastructure.Database.Configurations
{
    public class ThemeConfiguration : IEntityTypeConfiguration<Theme>
    {
        public void Configure(EntityTypeBuilder<Theme> builder)
        {
            builder.ToTable("Themes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Label).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Created).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.CreatedBy).IsRequired(false);
            builder.Property(x => x.LastModifiedBy).IsRequired(false);
            builder.Property(x => x.LastModified).IsRequired(false);
        }
    }
}