using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscola.Service.Domain.Board.School.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEscola.Service.Infrastructure.Data.Mappings
{
    //public class WorkloadMapping : IEntityTypeConfiguration<WorkLoad>
    //{
    //    public void Configure(EntityTypeBuilder<WorkLoad> builder)
    //    {
    //        builder.ToTable("work_load", "public");

    //        builder.HasKey(x => x.Id);
    //        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
    //        builder.Property(x => x.WeeklyClass).HasColumnName("weekly_class").HasColumnType("int4");
    //        builder.Property(x => x.AnnualClass).HasColumnName("annual_class").HasColumnType("int4");
    //        builder.Property(x => x.WeekHours).HasColumnName("week_hours").HasColumnType("int4");
    //    }
    //}
}
