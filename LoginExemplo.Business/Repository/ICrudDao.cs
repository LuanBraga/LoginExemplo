using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginExemplo.Business.Repository
{
    interface ICrudDao<T>
    {
        void Salvar(T entidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);
        T BuscarPorId(int id);
        IList<T> Buscar();
    }
}
