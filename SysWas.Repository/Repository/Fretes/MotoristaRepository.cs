using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IFretes;
using SysWas.Domain.Entidades.Fretes;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Fretes
{
    public class MotoristaRepository : BaseRepository<Motorista>, IMotoristaRepository
    {
        public MotoristaRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
