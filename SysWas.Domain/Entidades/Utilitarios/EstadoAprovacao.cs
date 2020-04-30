using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Enumerados;

namespace SysWas.Domain.Entidades.Utilitarios
{
    public class EstadoAprovacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public bool EmEspera
        {
            get { return Id == (int)EstadoAprovacaoEnum.EmEspera; }
        }
        public bool Negado
        {
            get { return Id == (int)EstadoAprovacaoEnum.Negado; }
        }
        public bool Aprovado
        {
            get { return Id == (int)EstadoAprovacaoEnum.Aprovado; }
        }


    }
}
