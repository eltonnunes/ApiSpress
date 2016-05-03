using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiSpress.Bibliotecas;
using WebApiSpress.Models.Object;
using WebApiSpress.Models.Sql;
using WebApiSpress.Negocios.Firebird;

namespace WebApiSpress.Controllers.Firebird
{
    public class ConsultaTitulosController : ApiController
    {
        public HttpResponseMessage Get(string token, int colecao = 0, int campo = 0, int orderBy = 0, int pageSize = 0, int pageNumber = 0)
        {
            //tbLogAcessoUsuario log = new tbLogAcessoUsuario();

            try
            {
                //log = Bibliotecas.LogAcaoUsuario.New(token, null, "Get");

                Dictionary<string, string> queryString = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
                HttpResponseMessage retorno = new HttpResponseMessage();
                if (Permissoes.Autenticado(token) && Permissoes.usuarioTemPermissaoAssociarTyresoles(token))
                {
                    Retorno dados = GatewayConsultaTitulos.Get(token, colecao, campo, orderBy, pageSize, pageNumber, queryString);
                    //log.codResposta = (int)HttpStatusCode.OK;
                    //Bibliotecas.LogAcaoUsuario.Save(log);
                    return Request.CreateResponse<Retorno>(HttpStatusCode.OK, dados);
                }
                else
                {
                    //log.codResposta = (int)HttpStatusCode.Unauthorized;
                    //Bibliotecas.LogAcaoUsuario.Save(log);
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            catch (Exception e)
            {
                HttpStatusCode codigoErro = HttpStatusCode.InternalServerError;
                if (e.Message.Equals("401")) codigoErro = HttpStatusCode.Unauthorized;
                //log.codResposta = (int)codigoErro;
                //log.msgErro = e.Message;
                //Bibliotecas.LogAcaoUsuario.Save(log);
                //throw new HttpResponseException(codigoErro);
                return Request.CreateResponse(codigoErro, e.Message);
            }
        }
    }
}





