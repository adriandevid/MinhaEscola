using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Administractive.LevelEducation.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class LevelEducationMapping : IEntityTypeConfiguration<LevelEducation>
    {
        public void Configure(EntityTypeBuilder<LevelEducation> builder)
        {
            builder.ToTable("level_education", "public");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasColumnName("description").IsRequired();

            builder.HasMany(x => x.Stages)
                   .WithOne(x => x.LevelEducation)
                   .HasForeignKey(x => x.LevelEducationId);
        }
    }
}
