using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LojaDaMarcela.Models;
using LojaDaMarcela.Data;
using Microsoft.EntityFrameworkCore;

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
