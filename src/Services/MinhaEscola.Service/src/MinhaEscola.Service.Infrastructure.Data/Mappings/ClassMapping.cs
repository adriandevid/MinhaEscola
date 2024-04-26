using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Academic.Class.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class ClassMapping : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("class", "public");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.AmountStudent).HasColumnName("quantity_student").HasColumnType("int4");
            builder.Property(x => x.Active).HasColumnName("active").HasColumnType("boolean");
            builder.Property(x => x.Denomination).HasColumnName("denomination").HasColumnType("varchar(50)");
            builder.Property(x => x.Year).HasColumnName("year").HasColumnType("int2");
            builder.Property(x => x.SchoolId).HasColumnName("school_id").HasColumnType("int4");
            builder.Property(x => x.ComponentId).HasColumnName("component_id").HasColumnType("int4");

            builder.HasOne(x => x.School).WithMany(x => x.Classes).HasForeignKey(x => x.SchoolId);
            builder.HasOne(x => x.Component).WithMany(x => x.Classes).HasForeignKey(x => x.ComponentId);
            builder.HasMany(x => x.Enrollees).WithOne(x => x.Class).HasForeignKey(x => x.ClassId);
        }
    }
}
