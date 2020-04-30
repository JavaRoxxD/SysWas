﻿using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IFretes;
using SysWas.Domain.Entidades.Fretes;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Fretes
{
    public class ItemTabelaFreteRepository : BaseRepository<ItemTabelaFrete>, IItemTabelaFreteRepository
    {
        public ItemTabelaFreteRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
