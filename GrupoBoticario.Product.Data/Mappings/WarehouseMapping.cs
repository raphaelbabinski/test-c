using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoBoticario.Product.Data.Mappings
{
    public class WarehouseMapping : IEntityTypeConfiguration<Business.Models.Warehouse>
    {
        public void Configure(EntityTypeBuilder<Business.Models.Warehouse> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(p => p.Sku)
                .IsRequired();

            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.Property(p => p.Locality)
                .IsRequired()
                .HasColumnType("varchar(80)");

            builder.Property(p => p.Type)
                .IsRequired()
                .HasColumnType("varchar(80)");

            builder.ToTable("Warehouses");
        }
    }
}