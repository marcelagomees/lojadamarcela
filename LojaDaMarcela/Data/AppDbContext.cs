
using LojaDaMarcela.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaDaMarcela.Data;

    public class AppDbContext : DbContext
    {
     public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
      {

      }

      public DbSet<Categoria> Categorias{ get; set; }
      public DbSet<Produto> Produtos { get; set; }
      public DbSet<ProdutoFoto> ProdutoFotos { get; set; }
    }
        
    
