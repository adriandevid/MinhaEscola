using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Administractive.KnowledgeArea.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class KnowledgeAreaMapping : IEntityTypeConfiguration<KnowledgeArea>
    {
        public void Configure(EntityTypeBuilder<KnowledgeArea> builder)
        {
            builder.ToTable("knowledge_area", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(100)");
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("varchar(100)");
        }
    }
}
