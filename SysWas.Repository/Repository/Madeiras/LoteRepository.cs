using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IMadeiras;
using SysWas.Domain.Entidades.Madeiras;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Madeiras
{
    public class LoteRepository : BaseRepository<Lote>, ILoteRepository
    {
        public LoteRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
