using LoginExemplo.Business.Repository;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginExemplo.Business.Business
{
    public class BusinessBase<T> : ICrudDao<T> where T : class
    {
        public void Salvar(T entidade)
        {
            //abrindo sessao
            using (ISession _session = ConnectionFactory.AbrirSessao())
            {
                //abrindo transacao
                using (ITransaction _transacao = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Save(entidade);

                        _transacao.Commit();
                    }
                    catch (Exception e)
                    {

                        if (!_transacao.WasCommitted)
                        {
                            _transacao.Rollback();

                            throw new Exception("Nao foi possivel Salvar" + e.Message);
                        }
                    }
                }
            }
        }

        public void Atualizar(T entidade)
        {
            using (ISession _sessao = ConnectionFactory.AbrirSessao())
            {
                using (ITransaction _transacao = _sessao.BeginTransaction())
                {
                    try
                    {
                        _sessao.Update(entidade);

                        _transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!_transacao.WasCommitted)
                        {
                            throw new Exception("Nao foi possivel concluir a Atualizacao" + e.Message);
                        }
                    }
                }
            }
        }

        public void Excluir(T entidade)
        {
            using (ISession _sessao = ConnectionFactory.AbrirSessao())
            {
                using (ITransaction _transacao = _sessao.BeginTransaction())
                {
                    try
                    {
                        _sessao.Delete(entidade);

                        _transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!_transacao.WasCommitted)
                        {
                            throw new Exception("Nao foi possivel fazer a Exclusao" + e.Message);
                        }
                    }
                }
            }
        }

        public T BuscarPorId(int id)
        {
            using (ISession _sessao = ConnectionFactory.AbrirSessao())
            {
                return _sessao.Get<T>(id);
            }
        }

        public IList<T> Buscar()
        {
            using (ISession _sessao = ConnectionFactory.AbrirSessao())
            {
                return (from resp in _sessao.Query<T>() select resp).ToList();
            }
        }
    }
}
