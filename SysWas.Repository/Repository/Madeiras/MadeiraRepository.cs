using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IMadeiras;
using SysWas.Domain.Entidades.Madeiras;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Madeiras
{
    public class MadeiraRepository : BaseRepository<Madeira>, IMadeiraRepository
    {
        public MadeiraRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
