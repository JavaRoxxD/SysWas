using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Fornecedores;

namespace SysWas.Domain.Entidades.Utilitarios
{
    public class Contato : Entidade
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }


        public int ListaContatoId { get; set; }
        public virtual ListaContato Lista { get; set; }


        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
