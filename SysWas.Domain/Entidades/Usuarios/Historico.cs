using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Usuarios
{
    public class Historico : Entidade
    {
        //Estrutuarar da melhor forma

        public int Id { get; set; }

        public DateTime DataHistorico { get; set; }
        public string AcaoRealizada { get; set; }
        public string Tabela { get; set; }
        public int IdAcao { get; set; }





        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }


    }
}
