using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Board.School.Limits;
using MinhaEscola.Service.Domain.Board.School.ValueObject;
using System.Text.Json;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class DisciplineComponentMapping : IEntityTypeConfiguration<DisciplineComponent>
    {
        public void Configure(EntityTypeBuilder<DisciplineComponent> builder)
        {
            builder.ToTable("discipline_component", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.ComponentId).HasColumnName("component_id").HasColumnType("int4");
            builder.Property(x => x.DisciplineId).HasColumnName("discipline_id").HasColumnType("int4");
            builder.Property(x => x.SchoolId).HasColumnName("school_id").HasColumnType("int4");

            builder.Property(x => x.WorkLoad).HasColumnName("workload").HasColumnType("varchar(100)").HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)new ()),
                    v => JsonSerializer.Deserialize<WorkLoad>(v, (JsonSerializerOptions)new())
                );

            builder.HasOne(x => x.Component).WithMany(x => x.DisciplineComponents).HasForeignKey(x => x.ComponentId);
            builder.HasOne(x => x.Discipline).WithMany(x => x.DisciplineComponents).HasForeignKey(x => x.DisciplineId);

            //builder.HasOne(x => x.School).WithMany(x => x.DisciplineComponents).HasForeignKey(x => x.ComponentId);
        }
    }
}
