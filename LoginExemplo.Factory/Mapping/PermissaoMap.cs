using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginExemplo.Factory.Entities;
using FluentNHibernate.Mapping;


namespace LoginExemplo.Factory.Mapping
{
    public class PermissaoMap : ClassMap<Permissao>
    {
        public PermissaoMap()
        {
            Table("TblPermissao");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome).Not.Nullable();
            HasManyToMany(x => x.Usuarios)
                .Table("TblUsuarioToPermissao")
                .ParentKeyColumn("usuarioId")
                .ChildKeyColumn("permissaoId")
                .LazyLoad();
        }
    }
}
