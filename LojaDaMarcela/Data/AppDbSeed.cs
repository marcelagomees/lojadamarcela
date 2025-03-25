using LojaDaMarcela.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaDaMarcela.Data;

    public class AppDbSeed
    {
        public AppDbSeed(ModelBuilder builder)
        {
            List<Categoria> categorias = new(){
                new() {Id = 1, Nome = "Perfumes", Foto="\\img"},
            };
            builder.Entity<Categoria>().HasData(categorias);

            List<Produto> produtos = new(){
                new() {
                    Id = 1,
                    CategoriaId = 1,
                    Nome = "La Vie Est Belle",
                    Descricao
                }
                
            };
            builder.Entity<Produto>().HasData(produtos);

            List<ProdutoFoto> fotos
        }
    }
