using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using LojaDaMarcela.Data;
using LojaDaMarcela.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LojaDaMarcela.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ILogger<CategoriasController> _logger;
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _host;

        public CategoriasController(
            ILogger<CategoriasController> logger,
             AppDbContext db, IWebHostEnvironment host
            )
        {
            _logger = logger;
            _db = db;
            _host = host;
        }

        public IActionResult Index()
        { 
            List<Categoria> categorias = _db.Categorias.ToList();
            return View(categorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria categoria, IFormFile Arquivo) {
            if(ModelState.IsValid)
            {
                _db.Categorias.Add(categoria);
                await _db.SaveChangesAsync();

                //Salvar a foto no servidor
                if (Arquivo !=null)
                {
                    string nomeArquivo = categoria.Id + Path.GetExtension(Arquivo.FileName);
                    string caminho = Path.Combine(_host.WebRootPath,"img\\categorias");
                    string novoArquivo = Path.Combine(caminho, nomeArquivo);
                    using (FileStream stream = new(novoArquivo, FileMode.Create))
                    {
                        Arquivo.CopyTo(stream);
                    }
                    categoria.Foto = "\\img\\categorias\\" + nomeArquivo;
                    await _db.SaveChangesAsync();
                }
                TempData["Success"] = "Categoria cadastrada com sucesso!";
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}