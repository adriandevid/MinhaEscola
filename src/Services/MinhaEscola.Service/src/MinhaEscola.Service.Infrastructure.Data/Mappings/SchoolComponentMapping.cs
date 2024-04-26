using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Board.School.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class SchoolComponentMapping : IEntityTypeConfiguration<SchoolComponent>
    {
        public void Configure(EntityTypeBuilder<SchoolComponent> builder)
        {
            builder.ToTable("school_component", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.ComponentId).HasColumnName("component_id");
            builder.Property(x => x.SchoolId).HasColumnName("school_id").HasColumnType("int4");

            builder.HasOne(x => x.Component).WithMany(x => x.SchoolComponent).HasForeignKey(x => x.ComponentId);
            builder.HasOne(x => x.School).WithMany(x => x.SchoolComponents).HasForeignKey(x => x.SchoolId);
        }
    }
}
