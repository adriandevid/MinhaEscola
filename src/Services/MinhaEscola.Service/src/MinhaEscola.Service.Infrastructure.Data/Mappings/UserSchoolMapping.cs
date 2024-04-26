using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Board.School.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class UserSchoolMapping : IEntityTypeConfiguration<UserSchool>
    {
        public void Configure(EntityTypeBuilder<UserSchool> builder)
        {
            builder.ToTable("user_school");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Property(x => x.SchoolId).HasColumnName("school_id");

            builder.HasOne(x => x.School).WithMany(x => x.UsersSchool).HasForeignKey(x => x.SchoolId);  
        }
    }
}
