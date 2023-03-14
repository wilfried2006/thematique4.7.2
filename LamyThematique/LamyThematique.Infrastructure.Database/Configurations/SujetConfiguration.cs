using System;
using LamyThematique.Infrastructure.Database.Entities.Document;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LamyThematique.Infrastructure.Database.Configurations
{
    public class SujetConfiguration : IEntityTypeConfiguration<Sujet>
    {
        public void Configure(EntityTypeBuilder<Sujet> builder)
        {
            builder.ToTable("Sujets");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Label).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Created).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.CreatedBy).HasDefaultValue("1");
            builder.Property(x => x.LastModifiedBy).IsRequired(false);
            builder.Property(x => x.LastModified).IsRequired(false);
            
            builder.HasOne(x => x.SousTheme)
                .WithMany(x => x.Sujets)
                .HasForeignKey(x => x.SousThemeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}