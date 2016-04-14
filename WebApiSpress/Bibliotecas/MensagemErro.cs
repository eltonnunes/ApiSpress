using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSpress.Bibliotecas
{
    public class MensagemErro
    {
        public static string getMensagemErro(DbEntityValidationException e)
        {
            string erro = String.Empty;
            foreach (var eve in e.EntityValidationErrors)
            {
                //Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                erro += "Type: " + eve.Entry.Entity.GetType().Name + "\n" +
                        "State: " + eve.Entry.State + "\n";
                foreach (var ve in eve.ValidationErrors)
                {
                    erro += "PROPERTY: " + ve.PropertyName + "\n" +
                            "MESSAGE: " + ve.ErrorMessage + "\n";
                    //Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                    //    ve.PropertyName, ve.ErrorMessage);
                }
                erro += "\n";
            }
            return erro;
        }

    }
}
