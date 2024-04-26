using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Administractive.Color.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class ColorMapping : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("color", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("varchar(100)");

            builder.HasMany(x => x.PhysicalPersons).WithOne(x => x.Color).HasForeignKey(x => x.ColorId);

        }
    }
}
