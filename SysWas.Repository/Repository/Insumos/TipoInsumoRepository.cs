using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IInsumos;
using SysWas.Domain.Entidades.Insumos;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Insumos
{
    public class TipoInsumoRepository : BaseRepository<TipoInsumo>, ITipoInsumoRepository
    {
        public TipoInsumoRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
