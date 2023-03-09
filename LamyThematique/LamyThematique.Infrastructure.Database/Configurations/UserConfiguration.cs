using System;
using LamyThematique.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LamyThematique.Infrastructure.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.AccessCode).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired(false);
            builder.Property(x => x.LastModifiedBy).IsRequired(false);
            builder.Property(x => x.LastModified).IsRequired(false);
        }
    }
}