using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Academic.Class.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings;
public class LessonMapping : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("lesson", "public");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.Property(x => x.Description).HasColumnName("description");
        builder.Property(x => x.ClassId).HasColumnName("class_id");
        builder.Property(x => x.Duration).HasColumnName("duration");
        builder.Property(x => x.Date).HasColumnName("date");

        builder.HasMany(x => x.Subjects).WithOne(x => x.Lesson).HasForeignKey(x => x.LessonId);
    }
}
