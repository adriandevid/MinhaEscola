using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Board.School.Limits;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class SchoolMapping : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("school", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(100)");
            builder.Property(x => x.NameAbbreviated).HasColumnName("name_abbreviated").HasColumnType("varchar(70)");
            builder.Property(x => x.CNPJ).HasColumnName("cnpj").HasColumnType("varchar(100)");
            builder.Property(x => x.TypeOrganization).HasColumnName("type_organization").HasColumnType("int2");

            //Backing Field
            builder.Property(x => x.Status).HasField("_status").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("status");

            //Filds
            builder.Property(x => x.AddressId).HasColumnName("address_id").HasColumnType("int4");
            builder.Property(x => x.SituationOfOperationId).HasColumnName("situation_operation_id").HasColumnType("int4");
            builder.Property(x => x.DependencyAdministrativeId).HasColumnName("dependency_administractive_id").HasColumnType("int4");
            builder.Property(x => x.CategorySchoolPrivatedId).HasColumnName("category_school_privated_id").HasColumnType("int4");
            builder.Property(x => x.AgencyPublicId).HasColumnName("public_agency_id").HasColumnType("int4");

            //Backing Field - Lists
            builder.Navigation(x => x.SchoolComponents).HasField("_schoolComponents").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Navigation(x => x.DisciplineComponents).HasField("_disciplineComponents").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Navigation(x => x.Classes).HasField("_classes").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Navigation(x => x.UsersSchool).HasField("_userSchool").UsePropertyAccessMode(PropertyAccessMode.Field);

            // No Backing Fileds
            builder.HasOne(x => x.Address).WithMany(x => x.Schools).HasForeignKey(x => x.AddressId);
            builder.HasOne(x => x.PublicAgencyRelated);
        }
    }
}
