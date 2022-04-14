using fixcarv1.Enums;
using fixcarv1.Models;
using Microsoft.EntityFrameworkCore;

namespace fixcarv1.Data.Mappers
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
        {
          // builder.ToTable()
          builder.Property(o => o.TipoProduto)
                .IsRequired()
                .HasConversion(
                    t => (int)t,
                    t => (TipoProduto)t
                );

        }
    }
}