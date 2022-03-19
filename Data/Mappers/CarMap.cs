using fixcarv1.Enums;
using fixcarv1.Models;
using Microsoft.EntityFrameworkCore;

namespace fixcarv1.Data.Mappers
{
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Car> builder)
        {
          // builder.ToTable()
          builder.Property(o => o.Transmissao)
                .IsRequired()
                .HasConversion(
                    t => (int)t,
                    t => (Transmissao)t
                );
        }
    }
}