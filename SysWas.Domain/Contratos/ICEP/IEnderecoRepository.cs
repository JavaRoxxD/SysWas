using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.CEP;

namespace SysWas.Domain.Contratos.ICEP
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {

        Endereco Obter(string cep);

    }
}
