using LoginExemplo.Business.Repository;
using LoginExemplo.Factory.Entities;
using NHibernate;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace LoginExemplo.Business.Business
{
    public class UsuarioBusiness : BusinessBase<Usuario>
    {
        public Usuario GetUsuarioPermissoes(string email)
        {
            using (ISession _session = ConnectionFactory.AbrirSessao())
            {
                Permissao _permissao = null;

                return _session.QueryOver<Usuario>()
                    .Where(x => x.Email == email)
                    .JoinAlias(x => x.Permissoes, () => _permissao, JoinType.LeftOuterJoin)
                    .List<Usuario>().FirstOrDefault();
            }
        }

        public bool AutenticaUsuario(string email, string senha)
        {
            using (ISession _session = ConnectionFactory.AbrirSessao())
            {
                var resultado = _session.QueryOver<Usuario>()
                    .Where(x => x.Email == email)
                    .And(x => x.Senha == senha)
                    .List<Usuario>().FirstOrDefault();

                if (resultado == null)
                {
                    return false;
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(resultado.Email, false);

                    return true;
                }

            }
        }

        public Usuario VerificaUsuarioLogado()
        {
            var usuarioLogado = HttpContext.Current.User.Identity.Name;

            if (usuarioLogado == "")
            {
                return null;
            }
            else
            {
                using (ISession _session = ConnectionFactory.AbrirSessao())
                {
                    return _session.QueryOver<Usuario>()
                        .Where(x => x.Email == usuarioLogado)
                        .List<Usuario>().FirstOrDefault();
                }
            }
        }

        public void Deslogar()
        {
            FormsAuthentication.SignOut();
        }
    }
}
