using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LojaDaMarcela.Models;
using LojaDaMarcela.Data;
using Microsoft.EntityFrameworkCore;
using LojaDaMarcela.ViewModels;

namespace LojaDaMarcela.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _db;

    public HomeController(ILogger<HomeController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        ViewData["carrinho"] = 5;
        List<Produto> produtos = _db.Produtos
         .Where(p => p.Destaque)
         .Include(p => p.Fotos)
        .ToList();
        return View(produtos);
    }
    
    public IActionResult Produto(int id)
    { 
        //pesquisa do produto clicado
        ViewData["Carrinho"] = 0;
        Produto produto = _db.Produtos
                .Where(p => p.Id == id)
                .Include(p => p.Fotos)
                .Include(p => p.Categoria)
                .SingleOrDefault();

                //lista do produto da mesma categoria
            List<Produto> produtos = _db.Produtos
              .Where(p => p.Id != id && p.CategoriaId ==produto.CategoriaId)
               .Include(p => p.Fotos)
              .Take(4).ToList();

              // agrupar o produto e os semelhantes no ProdutoVM
              ProdutoVM produtoVM = new()
              {
                Produto = produto,
                Semelhantes = produtos
              };
        return View(produtoVM);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
