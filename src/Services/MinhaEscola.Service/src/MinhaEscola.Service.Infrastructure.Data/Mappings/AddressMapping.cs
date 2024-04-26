using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Core.Address.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Street).HasColumnName("street").HasColumnType("varchar(100)");
            builder.Property(x => x.CEP).HasColumnName("cep").HasColumnType("varchar(20)");
            builder.Property(x => x.Neighborhood).HasColumnName("neighborhood").HasColumnType("varchar(100)");
            builder.Property(x => x.ZoneId).HasColumnName("zone_id").HasColumnType("int4");

            builder.HasOne(x => x.Zone).WithMany(x => x.Addresses).HasForeignKey(x => x.ZoneId);
            builder.HasMany(x => x.PhysicalPersons).WithOne(x => x.Address).HasForeignKey(x => x.AddressId);
        }
    }
}
