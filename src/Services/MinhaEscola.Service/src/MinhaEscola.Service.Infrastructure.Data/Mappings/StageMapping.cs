using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Administractive.Stage.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class StageMapping : IEntityTypeConfiguration<Stage>
    {
        public void Configure(EntityTypeBuilder<Stage> builder)
        {
            builder.ToTable("stage", "public");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(x => x.Description).HasColumnName("description").IsRequired();
            builder.Property(x => x.LevelEducationId).HasColumnName("level_education_id").IsRequired();


            builder.HasOne(x => x.LevelEducation).WithMany(x => x.Stages).HasForeignKey(x => x.LevelEducationId);
        }
    }
}
