using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IUtilitarios;
using SysWas.Domain.Entidades.Utilitarios;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Utilitarios
{
    public class TelefoneRepository : BaseRepository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
