using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSpress.Models.Object;
using WebApiSpress.Models.Sql;

namespace WebApiSpress.Bibliotecas
{
    public class LogAcesso
    {
        public static void New(Log data)
        {
            try
            {

                using (var _db = new painel_taxservices_dbContext())
                {
                    _db.Configuration.ProxyCreationEnabled = false;

                    LogAcesso1 log = new LogAcesso1();
                    log.idUsers = data.IdUser;
                    log.idController = data.IdController;
                    log.idMethod = data.IdMethod;
                    log.dtAcesso = data.DtAcesso;

                    _db.LogAcesso1.Add(log);
                    _db.SaveChanges();

                }
            }
            catch(Exception e)
            {
                throw new Exception("Mensagem: " + e.Message);
            }
        }
    }
}