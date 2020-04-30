using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IUtilitarios;
using SysWas.Domain.Entidades.Utilitarios;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Utilitarios
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
