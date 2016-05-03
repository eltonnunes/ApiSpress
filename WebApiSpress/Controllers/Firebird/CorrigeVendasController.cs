using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApiSpress.Bibliotecas;
using WebApiSpress.Models.Object;
using WebApiSpress.Models.Sql;
using WebApiSpress.Negocios.Firebird;

namespace WebApiSpress.Controllers.Firebird
{
    public class CorrigeVendasController : ApiController
    {
        public HttpResponseMessage Put(string token, CorrigeVendaERP param)
        {
            // Abre nova conexão
            using (painel_taxservices_dbContext _dbAtos = new painel_taxservices_dbContext())
            {
                //tbLogAcessoUsuario log = new tbLogAcessoUsuario();
                try
                {
                    //log = Bibliotecas.LogAcaoUsuario.New(token, JsonConvert.SerializeObject(param), "Put", _dbAtos);

                    HttpResponseMessage retorno = new HttpResponseMessage();
                    if (Permissoes.Autenticado(token, _dbAtos) && Permissoes.usuarioTemPermissaoAssociarTyresoles(token, _dbAtos))
                    {
                        GatewayCorrigeVendas.CorrigeVendas(token, param, _dbAtos);
                        //log.codResposta = (int)HttpStatusCode.OK;
                        //Bibliotecas.LogAcaoUsuario.Save(log, _dbAtos);
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        //log.codResposta = (int)HttpStatusCode.Unauthorized;
                        //Bibliotecas.LogAcaoUsuario.Save(log, _dbAtos);
                        return Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }
                catch (Exception e)
                {
                    HttpStatusCode httpStatus = e.Message.StartsWith("Permissão negada") || e.Message.StartsWith("401") ? HttpStatusCode.Unauthorized : HttpStatusCode.InternalServerError;
                    //log.codResposta = (int)httpStatus;
                    //log.msgErro = e.Message;
                    //Bibliotecas.LogAcaoUsuario.Save(log);
                    //throw new HttpResponseException(HttpStatusCode.InternalServerError);
                    return Request.CreateResponse(httpStatus, e.Message);
                }
            }
        }
    }
}