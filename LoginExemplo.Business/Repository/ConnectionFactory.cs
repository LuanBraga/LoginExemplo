using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginExemplo.Factory.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using MySql.Data;

namespace LoginExemplo.Business.Repository
{
    public class ConnectionFactory
    {
        private static ISessionFactory session;

        private static ISessionFactory CriarSessao()
        {
            if (session != null)
                return session;

            FluentConfiguration _configuration = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(
                            x => x.Server("localhost")
                                    .Username("root")
                                    .Password("")
                                    .Database("dbusuario")
                    )
                )
                .Mappings(
                    x => x.FluentMappings.AddFromAssemblyOf<UsuarioMap>());
                        //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true));
            //comentar a linha acima  apos a primeira execucao sob o risco de sobrescrever os dados ja populados no DB

            session = _configuration.BuildSessionFactory();

            return session;
        }

        public static ISession AbrirSessao()
        {
            return CriarSessao().OpenSession();
        }
    }
}