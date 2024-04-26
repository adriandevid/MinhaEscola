using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Administractive.Sex.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    public class SexMapping : IEntityTypeConfiguration<Sex>
    {
        public void Configure(EntityTypeBuilder<Sex> builder)
        {
            builder.ToTable("sex", "public");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("varchar(100)");


            builder.HasMany(x => x.PhysicalPersons).WithOne(x => x.Sex).HasForeignKey(x => x.SexId);
        }
    }
}
