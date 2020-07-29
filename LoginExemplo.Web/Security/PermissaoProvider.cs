using LoginExemplo.Business.Business;
using LoginExemplo.Factory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LoginExemplo.Web.Security
{
    public class PermissaoProvider : System.Web.Security.RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            UsuarioBusiness usuarioBusiness = new UsuarioBusiness();

            Usuario usuario = usuarioBusiness.GetUsuarioPermissoes(username);

            if (usuario == null)
            {
                return new string[] { };
            }
            else
            {
                List<String> listaPermissoes = new List<String>();

                foreach (var permissao in usuario.Permissoes)
                {
                    listaPermissoes.Add(permissao.Nome);
                }

                return listaPermissoes.ToArray();
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}