
using LojaDaMarcela.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaDaMarcela.Data;

    public class AppDbContex : DbContext
    {
     public AppDbContext(DbContextOptions<AppDbContext>options)
      : base(options)

      public DbSet<Categoria> categorias{ get; set; }
      public int MyProperty { get; set; }
      public int MyProperty { get; set; }
    }
        
    
