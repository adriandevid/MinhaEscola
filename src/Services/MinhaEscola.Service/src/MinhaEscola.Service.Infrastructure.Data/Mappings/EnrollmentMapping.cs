

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Academic.Student.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class EnrollmentMapping : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("enrollment", "public");

            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(x => x.Year).HasColumnName("year");

            builder.Property(x => x.DateEnrollee).HasColumnName("date_enrollment");

            builder.Property(x => x.Active).HasColumnName("active");
            builder.Property(x => x.ClassId).HasColumnName("class_id");
            builder.Property(x => x.StudentId).HasColumnName("student_id");

            builder.HasOne(x => x.Student);
            builder.HasOne(x => x.Class);
        }
    }
}
