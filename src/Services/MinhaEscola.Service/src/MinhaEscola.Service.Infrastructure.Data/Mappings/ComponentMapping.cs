using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Administractive.Component.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class ComponentMapping : IEntityTypeConfiguration<Component>
    {
        public void Configure(EntityTypeBuilder<Component> builder)
        {
            builder.ToTable("component", "public");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar");
            builder.Property(x => x.TypeOrganization).HasColumnName("type_organization").HasColumnType("int2");
            builder.Property(x => x.DenominationId).HasColumnName("denomination_id").HasColumnType("in4");

            builder.Property(x => x.StageId).HasColumnName("stage_id").IsRequired();
            builder.Property(x => x.ModalityId).HasColumnName("modality_id").IsRequired();

            builder.HasOne(x => x.Denomination).WithMany(x => x.Components).HasForeignKey(x => x.DenominationId);

            builder.HasMany(x => x.DisciplineComponents).WithOne(x => x.Component).HasForeignKey(x => x.ComponentId);
            builder.HasMany(x => x.SchoolComponent).WithOne(x => x.Component).HasForeignKey(x => x.ComponentId);
            builder.HasMany(x => x.Classes).WithOne(x => x.Component).HasForeignKey(x => x.ComponentId);
        }
    }
}
