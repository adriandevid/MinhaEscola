using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Core.Affiliation.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class AffiliationMapping : IEntityTypeConfiguration<Affiliation>
    {
        public void Configure(EntityTypeBuilder<Affiliation> builder)
        {
            builder.ToTable("affiliation", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.RelatedId).HasColumnName("releated_id").HasColumnType("int4");
            builder.Property(x => x.PhysicalPersonId).HasColumnName("person_id").HasColumnType("int4");
            builder.Property(x => x.TypeAffiliationId).HasColumnName("type_affiliation_id").HasColumnType("int4");

            //builder.HasOne(x => x.PhysicalPerson).WithMany(x => x.Affiliations).HasForeignKey(x => x.PhysicalPersonId);
            //builder.HasOne(x => x.Related).WithMany(x => x.Affiliations).HasForeignKey(x => x.RelatedId);
            //builder.HasOne(x => x.TypeAffiliation).WithMany(x => x.Affiliations).HasForeignKey(x => x.TypeAffiliationId);
        }
    }
}
