using LojaDaMarcela.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LojaDaMarcela.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        List<Categoria> categorias = new() {
            new() { Id = 1, Nome = "Fragrancia", },
        };
        builder.Entity<Categoria>().HasData(categorias);

        List<Produto> produtos = new() {
            new() {
                Id = 1,
                CategoriaId = 1,
                Nome = "La Vie Est Belle",
                Descricao = "Na primeira borrifada sinta as notas de cassis, groselha negra e Pêra. Suspire com os aromas de Íris Gourmand, Jasmim e Flor de Laranjeira durante as próximas horas e no fim, se encante com as notas de Baunilha, Pralinê, Fava Tonka e a profundidade de Patchuouli.",
                ValorCusto = 430.00m,
                ValorVenda = 581.90m,
                QtdeEstoque = 10,
                Destaque = true
            },
            new() {
                Id = 2,
                CategoriaId = 1,
                Nome = "Floratta my blue",
                Descricao = "Sinta a fragrância marcante de Floratta My Blue exalar no ar. Pirâmide Olfativa Topo: Tangerina, Notas Aquosas (Melão, Melancia), Frutas Vermelhas. Corpo: Gerânio, Verbena, Lírio do Vale, Íris. Fundo: Sândalo, Blend de Musk, Patchouli, Notas de Pelica, Âmbar, Cashmeran.",
                ValorCusto = 80.00m,
                ValorVenda = 111.90m,
                QtdeEstoque = 8,
                Destaque = true
            },
            new() {
                Id = 3,
                CategoriaId = 1,
                Nome = "Angel",
                Descricao = "As notas de cabeça são melão, coco, tangerina, cássia, jasmim, bergamota e algodão doce; as notas de coração são mel, damasco, amora, ameixa, orquídea, pêssego, jasmim, lírio-do-vale, frutas vermelhas e rosa; e as notas de fundo são fava tonka, âmbar, patchouli, musk, baunilha, chocolate e caramelo.",
                ValorCusto = 500.00m,
                ValorVenda = 675.90m,
                QtdeEstoque = 6,
                Destaque = true
            },
            new() {
                Id = 4,
                CategoriaId = 1,
                Nome = "Amor Amor",
                Descricao = "O vermelho vibrante do frasco reúne notas mágicas de tangerina, cereja preta, jasmim de quatro pétalas da Indonésia, lírio-do-vale, almíscar branco e âmbar cinza.",
                ValorCusto = 180.00m,
                ValorVenda = 230.90m,
                QtdeEstoque = 9,
                Destaque = true
            },
            new() {
                Id = 5,
                CategoriaId = 1,
                Nome = "Floratta Rose",
                Descricao = "Tem no corpo um cativante buquê floral com Rosa, Muguet, o atemporal Ylang-Ylang e a sempre feminina Gardênia. E ao fundo, possui um toque amadeirado com acordes de Musk, Sândalo e Cedro.",
                ValorCusto = 70.50m,
                ValorVenda = 97.46m,
                QtdeEstoque = 3,
                Destaque = true
            },
            new() {
                Id = 6,
                CategoriaId = 1,
                Nome = "Idole",
                Descricao = " Pimenta rosa, bergamota e pêra são suas principais notas. ",
                ValorCusto = 290.00m,
                ValorVenda = 480.00m,
                QtdeEstoque = 8,
                Destaque = true
            },
            new() {
                Id = 7,
                CategoriaId = 1,
                Nome = "My euphoria",
                Descricao = "Suas notas de saída são frescas e frutadas, com romã suculenta e uma exuberante presença de caqui. ",
                ValorCusto = 390.00m,
                ValorVenda = 455.76m,
                QtdeEstoque = 3,
                Destaque = true
            },
             new() {
                Id = 8,
                CategoriaId = 1,
                Nome = "Roma",
                Descricao = "O aroma Romã caracteriza-se por notas frutais e amadeiradas, combinadas harmoniosamente para proporcionar uma atmosfera encantadora, sedutora e exótica. Limão siciliano, Maçã vermelha, Grapefruit, Folha de violeta, Morango, Amora.",
                ValorCusto = 73.00m,
                ValorVenda = 100.00m,
                QtdeEstoque = 10,
                Destaque = true
            },
        };
        builder.Entity<Produto>().HasData(produtos);

        List<ProdutoFoto> fotos = new() {
            new() { Id = 1, ProdutoId = 1, Foto = "/img/produtos/1/lavie.png"},
            new() { Id = 2, ProdutoId = 2, Foto = "/img/produtos/2/floratta my blue.webp"},
            new() { Id = 3, ProdutoId = 3, Foto = "/img/produtos/3/angel.webp"},
            new() { Id = 4, ProdutoId = 4, Foto = "/img/produtos/4/amor amor.webp"},
            new() { Id = 5, ProdutoId = 5, Foto = "/img/produtos/5/floratta rose.webp"},
            new() { Id = 6, ProdutoId = 6, Foto = "/img/produtos/6/idole.webp"},
            new() { Id = 7, ProdutoId = 7, Foto = "/img/produtos/7/my euphoria.webp"},
            new() { Id = 8, ProdutoId = 8, Foto = "/img/produtos/8/roma.webp"},
        };
        builder.Entity<ProdutoFoto>().HasData(fotos);
        #region Populate Roles - Perfil de Usuário
        List<IdentityRole> roles = new()
            {
                new IdentityRole(){
                    Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
                    Name ="Administrador",
                    NormalizedName = "ADMINISTRADOR"
                },
                new IdentityRole(){
                    Id ="bec71b05-8f3d-4849-88bb-0e8d518d2de8",
                    Name="Funcionário",
                    NormalizedName="FUNCIONÁRIO"
                },
                new IdentityRole(){
                    Id="ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                    Name="Cliente",
                    NormalizedName="CLIENTE"
                },
            };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion
        #region  Populate Usuário
        List<Usuario> usuarios = new(){
              new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email ="marcellagomes609@gmail.com",
                NormalizedEmail = "MARCELLAGOMES609@GMAIL.COM",
                UserName = "MARCELLAGOMES",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Marcela Da Silva Gomes",
                DataNascimento = DateTime.Parse("25/03/2009"),
                Foto = "/img/usuarios/fotomarcela.jpg"

              }


            };
        foreach (var user in usuarios)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "marcela098");

        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[1].Id
            },
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[2].Id
            }

        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}


