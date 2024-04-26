using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Academic.Class.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings;
public class SubjectMapping : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("subject", "public");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.Property(x => x.Title).HasColumnName("title");
        builder.Property(x => x.Description).HasColumnName("description");
        builder.Property(x => x.LessonId).HasColumnName("lesson_id");

        builder.HasOne(x => x.Lesson).WithMany(x => x.Subjects).HasForeignKey(x => x.LessonId);
    }
}
