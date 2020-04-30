using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Entrega
{
    public class Entrega : Entidade
    {

        public int Id { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
