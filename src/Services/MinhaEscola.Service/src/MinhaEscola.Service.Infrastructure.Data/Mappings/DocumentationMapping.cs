using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class DocumentationMapping : IEntityTypeConfiguration<Documentation>
    {
        public void Configure(EntityTypeBuilder<Documentation> builder)
        {
            builder.ToTable("documentation", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.PhysicalPersonId).HasColumnName("person_id").HasColumnType("int4");
            builder.Property(x => x.AttachmentId).HasColumnName("file_id").HasColumnType("varchar");
            builder.Property(x => x.DocumentationValid).HasColumnName("valid").HasColumnType("boolean");
            builder.Property(x => x.TypeDocumentationId).HasColumnName("type_documentation_id").HasColumnType("int4");

            builder.HasOne(x => x.PhysicalPerson).WithMany(x => x.Documentations).HasForeignKey(x => x.PhysicalPersonId);
        }
    }
}
