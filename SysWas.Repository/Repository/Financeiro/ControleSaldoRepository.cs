using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IFinanceiro;
using SysWas.Domain.Entidades.Financeiro;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Financeiro
{
    public class ControleSaldoRepository : BaseRepository<ControleSaldo>, IControleSaldoRepository
    {
        public ControleSaldoRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
