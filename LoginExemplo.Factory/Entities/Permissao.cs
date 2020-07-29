using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginExemplo.Factory.Entities
{
    public class Permissao
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual IList<Usuario> Usuarios { get; set; }

        public Permissao()
        {
            Usuarios = new List<Usuario>();
        }
    }
}
