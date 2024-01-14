using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastucture.Persistences.Context.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Categori__19093A0B151B4431");

            builder.Property(e => e.Id).HasColumnName("CategoryId");

            builder.Property(e => e.Name).HasMaxLength(100);
        }
    }
}
