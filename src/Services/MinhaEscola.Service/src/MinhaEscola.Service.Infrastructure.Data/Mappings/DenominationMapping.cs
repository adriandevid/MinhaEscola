using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Administractive.Component.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class DenominationMapping : IEntityTypeConfiguration<Denomination>
    {
        public void Configure(EntityTypeBuilder<Denomination> builder)
        {
            builder.ToTable("denomination", "public");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasColumnName("description");

            builder.HasMany(x => x.Components).WithOne(x => x.Denomination).HasForeignKey(x => x.DenominationId);
        }
    }
}
