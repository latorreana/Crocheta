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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            UsuarioRepository uR = new UsuarioRepository();

            Usuario UsuarioLogado = uR.validarLogin(u);

            if(UsuarioLogado == null)
            {
               ViewBag.Mensagem = "Falha no login";
               return View(); 

            } else {
                HttpContext.Session.SetInt32(key: "idUsuario", value: UsuarioLogado.idUsuario);
                HttpContext.Session.SetString(key: "nomeUsuario", value: UsuarioLogado.nome);

                return View(); 
            }
        }
        public IActionResult Listar()
        {
            if(HttpContext.Session.GetInt32(key: "idUsuario") == null)
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