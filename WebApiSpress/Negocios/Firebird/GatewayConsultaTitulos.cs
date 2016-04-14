using System;
using FirebirdSql.Data.FirebirdClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using WebApiSpress.Bibliotecas;
using WebApiSpress.Models.Object;
using WebApiSpress.Models.Firebird;
using WebApiSpress.Models.Sql;

namespace WebApiSpress.Negocios.Firebird
{
    public class GatewayConsultaTitulos
    {
        static TyresolesContext _db = new TyresolesContext();
        static painel_taxservices_dbContext _dbAtos = new painel_taxservices_dbContext();

        /// <summary>
        /// Auto Loader
        /// </summary>
        public GatewayConsultaTitulos()
        {
            _db.Configuration.ProxyCreationEnabled = false;
        }

        #region CAMPOS
        /// <summary>
        /// Enum CAMPOS
        /// </summary>
        public enum CAMPOS
        {
            DATA = 100
        };
        #endregion

        /*
          http://localhost:50939/Firebird/ConsultaTitulos/jqTJTNwrNW7fu7EZ5RtgyHvIss7en9X2n82oHiefLCK1YRIUz1SIVk5Sx8CUF63XexOYYZXmdSfrXz9n5QXpYz3SCrHhT3euuYaB0PmhvDoclTYs2UFZXHIXSGmGTf1ykr3ZOgAA?100=2016-02-17
         */

        /// <summary>
        ///  Retorna Titulos
        /// </summary>
        /// <param name="token"></param>
        /// <param name="colecao"></param>
        /// <param name="campo"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static Retorno Get(string token, int colecao = 0, int campo = 0, int orderBy = 0, int pageSize = 0, int pageNumber = 0, Dictionary<string, string> queryString = null)
        {
            Retorno retorno = new Retorno();

            string outValue = null;
            String dtFiltro = String.Empty;

            if (queryString.TryGetValue("" + (int)CAMPOS.DATA, out outValue))
                dtFiltro = queryString["" + (int)CAMPOS.DATA];

            //dtFiltro = "20160215";

            DataTable Collection = new DataTable();

            try
            {
                Collection = _db.GetTitulos(dtFiltro);
            }
            catch (Exception e)
            {
                throw e;
            }

            retorno.TotalDeRegistros = Collection.Rows.Count;
            
            int skipRows = (pageNumber - 1) * pageSize;
            pageNumber = 1;

            List<TitulosExpress> list = (from rw in Collection.AsEnumerable()
                                       select new TitulosExpress()
                                       {
                                           nrCNPJ = Convert.ToString(rw["nrCNPJ"]),
                                           nrNSU = Convert.ToString(rw["nrNSU"]),
                                           dtVenda = Convert.ToDateTime(Convert.ToString(rw["dtVenda"]).Substring(0, 4) + "-" + Convert.ToString(rw["dtVenda"]).Substring(4, 2) + "-" + Convert.ToString(rw["dtVenda"]).Substring(6, 2)),
                                           cdAdquirente = Convert.ToInt32(rw["cdAdquirente"]),
                                           dsBandeira = Convert.ToString(rw["dsBandeira"]),
                                           vlVenda = Convert.ToDouble(rw["vlVenda"]),
                                           qtParcelas = Convert.ToInt32(rw["qtParcelas"]),
                                           dtTitulo = Convert.ToDateTime(Convert.ToString(rw["dtTitulo"]).Substring(0, 4) + "-" + Convert.ToString(rw["dtTitulo"]).Substring(4, 2) + "-" + Convert.ToString(rw["dtTitulo"]).Substring(6, 2)),
                                           vlParcela = Convert.ToDouble(rw["vlParcela"]),
                                           nrParcela = Convert.ToInt32(rw["nrParcela"]),
                                           cdERP = Convert.ToString(rw["cdERP"]),
                                           dtBaixaERP = rw["dtBaixaERP"].Equals(DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(rw["dtBaixaERP"]).Substring(0, 4) + "-" + Convert.ToString(rw["dtBaixaERP"]).Substring(4, 2) + "-" + Convert.ToString(rw["dtBaixaERP"]).Substring(6, 2))
                                       }).ToList();                

            retorno.PaginaAtual = pageNumber;
            retorno.ItensPorPagina = pageSize;
            retorno.Registros = list.Select(e => e).ToList<dynamic>();
            
            return retorno;
        }        
    }
}
