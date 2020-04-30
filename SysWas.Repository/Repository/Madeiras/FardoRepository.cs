using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IMadeiras;
using SysWas.Domain.Entidades.Madeiras;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Madeiras
{
    public class FardoRepository : BaseRepository<Fardo>, IFardoRepository
    {
        public FardoRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
