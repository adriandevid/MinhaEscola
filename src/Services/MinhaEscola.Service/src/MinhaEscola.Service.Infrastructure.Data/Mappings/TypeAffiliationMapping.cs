using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Core.Affiliation.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class TypeAffiliationMapping : IEntityTypeConfiguration<TypeAffiliation>
    {
        public void Configure(EntityTypeBuilder<TypeAffiliation> builder)
        {
            builder.ToTable("type_affiliation", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("varchar(100)");

            builder.HasMany(x => x.Affiliations).WithOne(x => x.TypeAffiliation).HasForeignKey(x => x.TypeAffiliationId);
        }
    }
}
