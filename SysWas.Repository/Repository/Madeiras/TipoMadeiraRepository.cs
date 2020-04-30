using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IMadeiras;
using SysWas.Domain.Entidades.Madeiras;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Madeiras
{
    public class TipoMadeiraRepository : BaseRepository<TipoMadeira>, ITipoMadeiraRepository
    {
        public TipoMadeiraRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
