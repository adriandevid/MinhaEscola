using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Board.PublicAgency.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class PublicAgencyMapping : IEntityTypeConfiguration<PublicAgency>
    {
        public void Configure(EntityTypeBuilder<PublicAgency> builder)
        {
            builder.ToTable("public_agency", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("varchar(100)");
            builder.HasMany(x => x.Schools).WithOne(x => x.PublicAgencyRelated).HasForeignKey(x => x.AgencyPublicId);
        }
    }
}
