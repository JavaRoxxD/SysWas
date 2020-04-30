using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysWas.Domain.Entidades.Utilitarios
{
    public abstract class Entidade
    {


        private List<string> _messageValidation { get; set; }
        private List<string> messageValidation
        {

            get { return _messageValidation ?? (_messageValidation = new List<string>()); }

        }

        protected void ClearMessageValidation() {

            messageValidation.Clear();

        }


        protected void AddMessageValidation(string message)
        {
            messageValidation.Add(message);
        }


        public string GetMessageValidation()
        {
            return string.Join(". ", messageValidation);
        }



        public abstract void Validate();

        public bool isValidate
        {

            get { return !messageValidation.Any(); }

        }



    }
}
