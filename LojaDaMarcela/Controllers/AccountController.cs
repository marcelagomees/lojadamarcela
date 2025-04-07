using System.Net.Mail;
using System.Security.Claims;
using LojaDaMarcela.Models;
using LojaDaMarcela.Helpers;
using LojaDaMarcela.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LojaDaMarcela.Data;



namespace LojaDaMarcela.Controllers;



public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly UserManager<Usuario> _userManager;
    private readonly IWebHostEnvironment _host;
    private readonly AppDbContext _db;
    public AccountController(
        ILogger<AccountController> logger,
        SignInManager<Usuario> signInManager,
        UserManager<Usuario> userManager,
        IWebHostEnvironment host,
        AppDbContext db
    )

    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
        _host = host;
        _db = db;

    }
    [HttpGet]

    public IActionResult Login(string returnUrl)
    {
        LoginVM login = new()
        {
            UrlRetorno = returnUrl ?? Url.Content("~/")
        };
        return View(login);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (ModelState.IsValid)
        {
            string userName = login.Email;
            if (IsValidEmail(login.Email))
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user != null)
                    userName = user.UserName;
            }

            var result = await _signInManager.PasswordSignInAsync(
                userName, login.Senha, login.Lembrar, lockoutOnFailure: true
            );

            if (result.Succeeded)
            {
                _logger.LogInformation($"Usuário {login.Email} acessou o sistema");
                return LocalRedirect(login.UrlRetorno);
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning($"Usuário {login.Email} está bloqueado");
                ModelState.AddModelError("", "Sua conta está bloqueada, aguarde alguns minutos e tente novamente!!");
            }
            else if (result.IsNotAllowed)
            {
                _logger.LogWarning($"Usuário {login.Email} não confirmou sua conta");
                ModelState.AddModelError(string.Empty, "Sua conta não está confirmada, verifique seu email!!");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!!!");
            }
        }
        return View(login);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        _logger.LogInformation($"Usuário {ClaimTypes.Email} fez logoff");
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Registro()
    {
        RegistroVM registrar = new();
        return View(registrar);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Registro(RegistroVM registro)
    {
        if (!ModelState.IsValid)
            return View(registro);

        var usuario = Activator.CreateInstance<Usuario>();
        usuario.Nome = registro.Nome;
        usuario.DataNascimento = registro.DataNascimento;
        usuario.UserName = registro.Email;
        usuario.NormalizedUserName = registro.Email.ToUpper();
        usuario.Email = registro.Email;
        usuario.NormalizedEmail = registro.Email.ToUpper();
        usuario.EmailConfirmed = true;

        var result = await _userManager.CreateAsync(usuario, registro.Senha);

        if (result.Succeeded)
        {
            _logger.LogInformation($"Novo usuário registrado com o email {registro.Email}.");

            await _userManager.AddToRoleAsync(usuario, "Cliente");

            if (registro.Foto != null)
            {
                var extensao = Path.GetExtension(registro.Foto.FileName);
                var nomeArquivo = $"{usuario.Id}{extensao}";
                var caminho = Path.Combine(_host.WebRootPath, "img", "usuarios");
                var caminhoCompleto = Path.Combine(caminho, nomeArquivo);

                Directory.CreateDirectory(caminho); 

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    registro.Foto.CopyTo(stream);
                }

                usuario.Foto = Path.Combine("img", "usuarios", nomeArquivo);
                await _db.SaveChangesAsync();
            }

            TempData["Success"] = "Conta criada com sucesso!";
            return RedirectToAction(nameof(Login));
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty,
                TranslateIdentityErrors.TranslateErrorMessage(error.Code));
        }

        return View(registro);

    }
     public IActionResult AccessDenied()
     {
        return View();
     }

        public bool IsValidEmail(string email)
        {
            try
            {
            MailAddress m = new(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

}

