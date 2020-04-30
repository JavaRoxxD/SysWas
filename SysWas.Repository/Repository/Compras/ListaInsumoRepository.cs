using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.ICompras;
using SysWas.Domain.Entidades.Compras;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Compras
{
    public class ListaInsumoRepository : BaseRepository<ListaInsumo>, IListaInsumoRepository
    {
        public ListaInsumoRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
