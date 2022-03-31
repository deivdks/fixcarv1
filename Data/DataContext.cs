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
        public DbSet<PaisOrigem> PaisOrigem{get;set;}
    
    }

}