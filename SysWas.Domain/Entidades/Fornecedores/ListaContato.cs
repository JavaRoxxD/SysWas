using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Fornecedores
{
    public class ListaContato
    {

        public int Id { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }


    }
}
