using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class PhysicalPersonMapping : IEntityTypeConfiguration<PhysicalPerson>
    {
        public void Configure(EntityTypeBuilder<PhysicalPerson> builder)
        {
            builder.ToTable("physical_person", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Year).HasColumnName("years").HasColumnType("int4");
            builder.Property(x => x.RegisterOfPhysicalPerson).HasColumnName("cpf").HasColumnType("char(11)");
            builder.Property(x => x.RegisterGeneral).HasColumnName("rg").HasColumnType("char(10)");
            builder.Property(x => x.AddressId).HasColumnName("address_id").HasColumnType("int4");
            builder.Property(x => x.SexId).HasColumnName("sex_id").HasColumnType("int4");
            builder.Property(x => x.ColorId).HasColumnName("color_id").HasColumnType("int4");
            builder.Property(x => x.NationalityId).HasColumnName("nationality_id").HasColumnType("int4");

            builder.Metadata.FindNavigation(nameof(PhysicalPerson.Documentations))?.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(PhysicalPerson.Affiliations))?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne(x => x.Address).WithMany(x => x.PhysicalPersons).HasForeignKey(x => x.AddressId);
            builder.HasOne(x => x.Sex).WithMany(x => x.PhysicalPersons).HasForeignKey(x => x.SexId);
            builder.HasOne(x => x.Color).WithMany(x => x.PhysicalPersons).HasForeignKey(x => x.ColorId);
            builder.HasOne(x => x.Nationality).WithMany(x => x.PhysicalPersons).HasForeignKey(x => x.NationalityId);
        }
    }
}
