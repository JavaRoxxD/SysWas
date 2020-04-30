using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IFretes;
using SysWas.Domain.Entidades.Fretes;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Fretes
{
    public class TabelaFreteRepository : BaseRepository<TabelaFrete>, ITabelaFreteRepository
    {
        public TabelaFreteRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
