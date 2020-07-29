using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginExemplo.Factory.Entities;
using FluentNHibernate.Mapping;

namespace LoginExemplo.Factory.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("TblUsuario");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome);
            Map(x => x.Email).Unique().Not.Nullable();
            Map(x => x.Senha).Not.Nullable();
            HasManyToMany(x => x.Permissoes)
                .Table("TblUsuarioToPermissao")
                .ParentKeyColumn("permissaoId")
                .ChildKeyColumn("usuarioId")
                .Cascade.SaveUpdate()
                .LazyLoad();
        }
    }
}
