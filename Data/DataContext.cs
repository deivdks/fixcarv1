using fixcarv1.Models;
using Microsoft.EntityFrameworkCore;

namespace fixcarv1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars{get;set;}
        public DbSet<Fabricante> Fabricantes{get;set;}
        public DbSet<PaisOrigem> PaisesOrigem{get;set;}
        public DbSet<Mecanica> Mecanicas{get;set;}
        public DbSet<Servico> Servicos{get;set;}
        public DbSet<Produto> Produtos{get;set;}
        
    
    }

}