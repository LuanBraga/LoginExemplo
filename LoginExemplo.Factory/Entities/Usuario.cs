using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginExemplo.Factory.Entities
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual IList<Permissao> Permissoes { get; set; }

        public Usuario()
        {
            Permissoes = new List<Permissao>();
        }
    }
}
