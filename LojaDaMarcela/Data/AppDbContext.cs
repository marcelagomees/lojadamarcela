
using LojaDaMarcela.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaDaMarcela.Data;

    public class AppDbContext : DbContext
    {
     public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
      {

      }

      public DbSet<Categoria> categorias{ get; set; }
      public DbSet<Produtos> produtos { get; set; }
      public DbSet<ProdutosFoto> ProdutoFotos { get; set; }
    }
        
    
