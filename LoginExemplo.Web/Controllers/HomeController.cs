using LoginExemplo.Factory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginExemplo.Business.Business;
using MySql.Data;
using LoginExemplo.Web.Security;

namespace LoginExemplo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            #region
            //UsuarioBusiness _usuarioNegocios = new UsuarioBusiness();
            //Usuario _usuario = new Usuario();
            //Permissao permissao = new Permissao();
            //IList<Permissao> _permissoes = new List<Permissao>();

            //_usuario.Nome = "Luan";
            //_usuario.Senha = "1234";
            //_usuario.Email = "luan@email.com";

            //permissao.Nome = "Admin";

            //_permissoes.Add(permissao);

            //_usuario.Permissoes = _permissoes;

            //_usuarioNegocios.Salvar(_usuario);
            #endregion

            return View();
        }


        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            UsuarioBusiness _usuarioNegocios = new UsuarioBusiness();
            
            string email = form["email"].ToString();

            string senha = form["senha"].ToString();

            //PermissaoProvider permissao = new PermissaoProvider();
            
            //permissao.GetRolesForUser(email);

            bool result = _usuarioNegocios.AutenticaUsuario(email, senha);

            if (result == true)
            {
                return RedirectToAction("Permitido", "Home");
            }
            else
            {
                return RedirectToAction("Negado", "Home");
            }
           
        }

        [PermissaoFiltro(Roles = "Admin")]
        public ActionResult Permitido()
        {
            return View();
        }

        public ActionResult Negado()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}