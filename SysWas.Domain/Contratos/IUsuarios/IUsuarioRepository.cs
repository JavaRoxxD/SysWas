using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Usuarios;

namespace SysWas.Domain.Contratos.IUsuarios
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {

        Usuario Obter(string email, string senha);
        Usuario Obter(string email);

    }
}
