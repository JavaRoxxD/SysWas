using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Insumos
{
    public class ControleInsumo : Entidade
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int QuantAlerta { get; set; }
        public double VolumeAlerta { get; set; }
        
        public bool Ativo { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
