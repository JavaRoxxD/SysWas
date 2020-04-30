using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Fornecedores
{
    public class ListaBancaria : Entidade
    {

        public int Id { get; set; }
        public int Agencia { get; set; }
        public int DigitoAgencia { get; set; }
        public int Conta { get; set; }
        public int DigitoConta { get; set; }

        public int BandoId { get; set; }
        public virtual Banco Banco { get; set; }

        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }



        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
