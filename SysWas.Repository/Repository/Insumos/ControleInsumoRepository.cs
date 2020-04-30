using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IInsumos;
using SysWas.Domain.Entidades.Insumos;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Insumos
{
    public class ControleInsumoRepository : BaseRepository<ControleInsumo>, IControleInsumoRepository
    {
        public ControleInsumoRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
