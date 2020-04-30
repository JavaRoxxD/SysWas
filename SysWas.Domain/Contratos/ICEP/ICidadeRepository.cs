using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysWas.Domain.Entidades.CEP;

namespace SysWas.Domain.Contratos.ICEP
{
    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        IEnumerable<Cidade> Obter(int uf);
    }
}
