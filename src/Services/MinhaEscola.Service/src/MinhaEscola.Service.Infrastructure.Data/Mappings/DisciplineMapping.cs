using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Administractive.Discipline.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class DisciplineMapping : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable("discipline", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(100)");
            builder.Property(x => x.KnowledgeAreaId).HasColumnName("knowledgearea_id").IsRequired();

            builder.HasOne(x => x.KnowledgeArea).WithMany(x => x.Discipline).HasForeignKey(x => x.KnowledgeAreaId);
        }
    }
}
