using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Administractive.Nationality.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class NationalityMapping : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.ToTable("nationality", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("varchar(100)");


            builder.HasMany(x => x.PhysicalPersons).WithOne(x => x.Nationality).HasForeignKey(x => x.NationalityId);
        }
    }
}
