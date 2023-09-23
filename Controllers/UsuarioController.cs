using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Crocheta.Models;

namespace Crocheta.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            Usuario UsuarioLogado = _usuarioRepository.validarLogin(u);

            if (UsuarioLogado != null)
            {
                HttpContext.Session.SetInt32(key: "idUsuario", value: UsuarioLogado.idUsuario);
                HttpContext.Session.SetString(key: "nomeUsuario", value: UsuarioLogado.nome);
                return RedirectToAction("Listar");
            }
            else
            {
                ViewBag.Mensagem = "Falha no login";
                return View();
            }
        }

        public IActionResult Listar()
        {
            if (HttpContext.Session.GetInt32(key: "idUsuario") == null)
                return RedirectToAction(actionName: "Login");

            ContatoRepository contato = new ContatoRepository();
            return View(model: contato.listar());
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(actionName: "Login");
        }
    }
}