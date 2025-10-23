using JovemProgramadorWebApplication.Data.Repositorio.Interfaces;
using JovemProgramadorWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWebApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
           _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ValidaUsuario(Usuario usuario)
        {
            try
            {        
                var retorno = _usuarioRepositorio.ValidarUsuario(usuario);

               

                if (retorno != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MsgErro"] = "Usuário ou senha incorretos!!! Tente novamente...";
                }
            }
            catch (Exception)
            {

                TempData["MsgErro"] = "Erro ao buscar dados do usuário";
            }

            return View("Index");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            
            try
            {
                _usuarioRepositorio.CadastrarUsuario(usuario);

                TempData["MsgOk"] = "Usuário Cadastrado com sucesso!!!";

                return RedirectToAction("Index", "Login");
            }
            catch (Exception e)
            {

                TempData["MsgErro"] = "Erro ao cadastrar usuário";
            }

            return View("Index");
           
        }

    }
}
