using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Models;
using LojaVirtual.Libraries.Email;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarContato()
        {
            try
            {
                Contato dados = new Contato();
                dados.Nome = HttpContext.Request.Form["nome"];
                dados.Email = HttpContext.Request.Form["email"];
                dados.Texto = HttpContext.Request.Form["texto"];
               

                var ListaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(dados);
                bool isValid = Validator.TryValidateObject(dados, contexto, ListaMensagens,true);

                if (isValid)
                {
                    ContatoEmail.EnviarContatoPorEmail(dados);
                    ViewData["mgs"] = "Mensagem de contato enviado com sucesso";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach(var texto in ListaMensagens)
                    {
                        sb.Append(texto.ErrorMessage + "<br/>");
                    }
                    ViewData["mgs_erro"] = sb.ToString();
                    ViewData["CONTATO"] = dados;
                }


                
            }
            catch (Exception e)
            {
                ViewData["mgs_erro"] = "Opps! tivemos um erro, tente novamente mais tarde";
                //TODO - Implementar log
            }

            return View("Contato");
        }

  
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
