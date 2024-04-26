using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Core.Address.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class ZoneMapping : IEntityTypeConfiguration<Zone>
    {
        public void Configure(EntityTypeBuilder<Zone> builder)
        {
            builder.ToTable("zone", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasColumnName("name").HasColumnType("varchar(100)");

            builder.HasMany(x => x.Addresses).WithOne(x => x.Zone).HasForeignKey(x => x.ZoneId);    
        }
    }
}
