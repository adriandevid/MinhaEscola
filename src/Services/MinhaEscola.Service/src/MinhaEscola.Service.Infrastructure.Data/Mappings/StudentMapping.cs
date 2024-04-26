using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Academic.Student.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("student", "public");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.UseTransport).HasColumnName("use_transport");
            builder.Property(x => x.INEP).HasColumnName("inep");
            builder.Property(x => x.PhysicalPersonId).HasColumnName("person_id");
            builder.Property(x => x.SchoolId).HasColumnName("school_id");
            builder.Property(x => x.Status).HasColumnName("status");
            builder.Property(x => x.UserReference).HasColumnName("user_id");

            builder.HasOne(x => x.PhysicalPerson).WithMany(x => x.Students).HasForeignKey(x => x.PhysicalPersonId);

            builder.Navigation(x => x.Enrollment).HasField("_enrollment").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
