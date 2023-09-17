using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Crocheta.Models;

namespace Crocheta.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
        public IActionResult Bolsas()
    {
        return View();
    }
    public IActionResult HD()
        {
            return View();
        }
        public IActionResult Cursos()
        {
            return View();
        }
    public IActionResult SobreMim()
        {
            return View();
        }
    public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contato(Contato contato)
        {
            if(string.IsNullOrEmpty(value: contato.nomeContato) 
            || string.IsNullOrEmpty(value: contato.email)
            || string.IsNullOrEmpty(value: contato.mensagem)
            || string.IsNullOrEmpty(value: contato.telefone)) 
            {
                
                ViewBag.Mensagem = "Preencha todos os campos.";
                return View(); 
            }
            
            ContatoRepository repository = new ContatoRepository();
            repository.inserir(contato);

            return RedirectToAction(actionName: "Sucesso");
        }
        public IActionResult Sucesso()
        {
            return View();          
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(model: new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
