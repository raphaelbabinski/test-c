using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoBoticario.Product.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Business.Models.Product>
    {
        public void Configure(EntityTypeBuilder<Business.Models.Product> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(p => p.Sku)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(120)");

            builder.Ignore(p => p.IsMarketable);

            builder.ToTable("Products");
        }
    }
}