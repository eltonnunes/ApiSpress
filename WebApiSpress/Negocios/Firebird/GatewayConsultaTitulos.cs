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
        //static TyresolesContext _db = new TyresolesContext();
        //static painel_taxservices_dbContext _dbAtos = new painel_taxservices_dbContext();

        /// <summary>
        /// Auto Loader
        /// </summary>
        public GatewayConsultaTitulos()
        {
            //_db.Configuration.ProxyCreationEnabled = false;
        }

        #region CAMPOS
        /// <summary>
        /// Enum CAMPOS
        /// </summary>
        public enum CAMPOS
        {
            DATA = 100,
            ID_GRUPO = 101,
            TIPODATA = 102,
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
        public static Retorno Get(string token, int colecao = 0, int campo = 0, int orderBy = 0, int pageSize = 0, int pageNumber = 0, Dictionary<string, string> queryString = null, painel_taxservices_dbContext _dbAtosContext = null)
        {
            string outValue = null;
            String dtFiltro = String.Empty;

            if (!queryString.TryGetValue("" + (int)CAMPOS.DATA, out outValue))
                throw new Exception("É necessário informar a data");

            // Obtém a data
            dtFiltro = queryString["" + (int)CAMPOS.DATA];

            //dtFiltro = "20160215";
            dtFiltro = dtFiltro.Replace("-", "");

            string tipoData = "R";
            if (queryString.TryGetValue("" + (int)CAMPOS.TIPODATA, out outValue))
            {
                tipoData = queryString["" + (int)CAMPOS.TIPODATA];
                if (!tipoData.Equals("V") && !tipoData.Equals("R"))
                    tipoData = "R"; // default
            }


            painel_taxservices_dbContext _dbAtos;
            if (_dbAtosContext == null)
            {
                _dbAtos = new painel_taxservices_dbContext();
                _dbAtos.Configuration.ProxyCreationEnabled = false;
            }
            else
                _dbAtos = _dbAtosContext;

            string connstring = Bibliotecas.Permissoes.GetConnectionString(token, _dbAtos);
            //string connstring = "User=SYSDBA;Password=masterkey;Database=C:\\IBX\\dealer.fdb;Dialect=3;Charset=NONE";
            try
            {
                if (connstring == null || connstring.Trim().Equals(""))
                    throw new Exception("Não foi possível obter a string de conexão do cliente");

                FbConnection conn = new FbConnection(connstring);

                try
                {
                    conn.Open();
                }
                catch
                {
                    throw new Exception("Falha de comunicação com o servidor do Cliente");
                }

                Retorno retorno = new Retorno();
                retorno.Registros = new List<dynamic>();

                try
                {
                    // VENDAS À CRÉDITO
                    string sql = "Select SUBSTRING(F.FILIALNROCGC FROM 2 FOR 14) AS nrCNPJ" +
                                 //", ('T' || Cast(cp.K0 As Varchar(33))) As nrNSU" + 
                                 ", (CASE WHEN cm.CACMODNROCARTAO IS NULL OR cm.CACMODNROCARTAO = ''" + // CACMODNROCARTAO : CHAR(16)
                                       " THEN NULL" +
                                       " ELSE CAST(cm.CACMODNROCARTAO AS VARCHAR(30))" +
                                  " END) AS nrNSU" +
                                 ", cp.CACMODDATREGISTRO As dtVenda" +
                                 /*", (Case When cm.EXPMONCOD In ('BANESE', 'CAJUCARD', 'DINERS', 'DINERS+7'" +
                                                               ", 'ELO', 'FLEXCARD', 'GOODCAR', 'HIPER'" +
                                                               ", 'HIPER+7', 'MASTER', 'MASTER+7', 'SHELL'" +
                                                               ", 'SODEXO', 'TKTCAR', 'VISA', 'VISA+7') Then 1" +
                                        " When cm.EXPMONCOD In ('AMERICAN', 'ELO') Then 2" +
                                   " End) As cdAdquirente" +*/
                                 ", cm.EXPMONCOD As dsBandeira" +
                                 ", cm.CACMODVLR As vlVenda" +
                                 ", cm.CACMODNROPARCELAS As qtParcelas" +
                                 ", cp.CACPARDATVENCTO As dtTitulo" +
                                 ", cp.CACPARVLR As vlParcela" +
                                 ", cp.CACPARNRO As nrParcela" +
                                 ", cp.K0 As cdERP" +
                                 ", cv.CACMOVDATOPERACAO As dtBaixaERP" +
                                 " From TCCCACPAR cp" +
                                 " Join TCCCACMOD cm On cm.CACADMCOD = cp.CACADMCOD" +
                                                  " AND cm.EXPMONCOD = cp.EXPMONCOD" +
                                                  " And cm.RECEBINRO = cp.RECEBINRO" +
                                                  " And cm.CACMODDATREGISTRO = cp.CACMODDATREGISTRO" +
                                                  " And cm.CACMODSEQ = cp.CACMODSEQ" +
                                 " JOIN TCCCACMOV M ON M.RECEBINRO = cm.RECEBINRO" +
                                                 " AND M.EXPMONCOD = cm.EXPMONCOD" +
                                                 " AND M.CACADMCOD = cm.CACADMCOD" +
                                                 " AND M.CACMODDATREGISTRO = cm.CACMODDATREGISTRO" +
                                                 " AND M.CACMODSEQ = cm.CACMODSEQ" +
                                                 " AND M.CACMOVIDTOPERACAO = 'EN'" + // movimento de entrada
                                 " Left Join TCCCACMOV cv On cv.CACADMCOD = cm.CACADMCOD" +
                                                       " AND cv.EXPMONCOD = cm.EXPMONCOD" +
                                                       " And cv.RECEBINRO = cm.RECEBINRO" +
                                                       " And cv.CACMODDATREGISTRO = cm.CACMODDATREGISTRO" +
                                                       " And cv.CACMODSEQ = cm.CACMODSEQ" +
                                                       " And cv.CACPARNRO = cp.CACPARNRO" +
                                 " Join TCCCAIXA c On c.CAIXACOD = M.CACMODCODAGEATU" +
                                 " Join TGLFILIAL f On f.FILIALCOD = c.FILIALCOD" +
                                 " Where cm.CACMODIDTSITUACAO NOT IN ('CA', 'CR')" + // despreza vendas canceladas
                                 " AND " + (tipoData.Equals("V") ? "cm.CACMODDATREGISTRO" : "cp.CACPARDATVENCTO") + " = " + dtFiltro;
                    FbCommand command = new FbCommand(sql, conn);

                    using (FbDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            retorno.Registros.Add(new TitulosExpress
                            {
                                nrCNPJ = Convert.ToString(dr["nrCNPJ"]).Trim(),
                                nrNSU = dr["nrNSU"].Equals(DBNull.Value) ? null : Convert.ToString(dr["nrNSU"]),
                                dtVenda = Convert.ToDateTime(Convert.ToString(dr["dtVenda"]).Substring(0, 4) + "-" + Convert.ToString(dr["dtVenda"]).Substring(4, 2) + "-" + Convert.ToString(dr["dtVenda"]).Substring(6, 2)),
                                //cdAdquirente = Convert.ToInt32(dr["cdAdquirente"]),
                                dsBandeira = dr["dsBandeira"].Equals(DBNull.Value) ? null : Convert.ToString(dr["dsBandeira"]).Trim(),
                                cdSacado = dr["dsBandeira"].Equals(DBNull.Value) ? null : Convert.ToString(dr["dsBandeira"]).Trim(),
                                vlVenda = Convert.ToDouble(dr["vlVenda"]),
                                qtParcelas = Convert.ToInt32(dr["qtParcelas"]),
                                dtTitulo = Convert.ToDateTime(Convert.ToString(dr["dtTitulo"]).Substring(0, 4) + "-" + Convert.ToString(dr["dtTitulo"]).Substring(4, 2) + "-" + Convert.ToString(dr["dtTitulo"]).Substring(6, 2)),
                                vlParcela = Convert.ToDouble(dr["vlParcela"]),
                                nrParcela = Convert.ToInt32(dr["nrParcela"]),
                                cdERP = Convert.ToString(dr["cdERP"]),
                                dtBaixaERP = dr["dtBaixaERP"].Equals(DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dr["dtBaixaERP"]).Substring(0, 4) + "-" + Convert.ToString(dr["dtBaixaERP"]).Substring(4, 2) + "-" + Convert.ToString(dr["dtBaixaERP"]).Substring(6, 2))
                            });
                        }
                    }

                    // VENDAS À DÉBITO
                    sql = " Select SUBSTRING(F.FILIALNROCGC FROM 2 FOR 14) AS nrCNPJ" +
                          ", (CASE WHEN cm.CABMODNROCARTAO IS NULL OR cm.CABMODNROCARTAO = 0" + // CABMODNROCARTAO : INTEGER
                                " THEN NULL" +
                                " ELSE CAST(cm.CABMODNROCARTAO AS VARCHAR(30))" +
                           " END) AS nrNSU" +
                          ", cp.CABMODDATREGISTRO As dtVenda" +
                          /*", (Case When cm.EXPMONCOD In ('BANESEDE', 'REDSHOP', 'TCKETCAR', 'VISAELET', 'HIPERDE') Then 1" +
                                 " When cm.EXPMONCOD In ('ELODE') Then 2" +
                            " End) As cdAdquirente" +*/
                          ", cm.EXPMONCOD As dsBandeira" +
                          ", cm.CABMODVLR As vlVenda" +
                          ", cm.CABMODNROPARCELAS As qtParcelas" +
                          ", cp.CABPARDATVENCTO As dtTitulo" +
                          ", cp.CABPARVLR As vlParcela" +
                          ", cp.CABPARNRO As nrParcela" +
                          ", cp.K0 As cdERP" +
                          ", cv.CABMOVDATOPERACAO As dtBaixaERP" +
                          " From TCCCABPAR cp" +
                          " Join TCCCABMOD cm On cm.CABADMCOD = cp.CABADMCOD" +
                                           " AND cm.EXPMONCOD = cp.EXPMONCOD" +
                                           " And cm.RECEBINRO = cp.RECEBINRO" +
                                           " And cm.CABMODDATREGISTRO = cp.CABMODDATREGISTRO" +
                                           " And cm.CABMODSEQ = cp.CABMODSEQ" +
                          " JOIN TCCCABMOV M ON M.RECEBINRO = cm.RECEBINRO" +
                                          " AND M.EXPMONCOD = cm.EXPMONCOD" +
                                          " AND M.CABADMCOD = cm.CABADMCOD" +
                                          " AND M.CABMODDATREGISTRO = cm.CABMODDATREGISTRO" +
                                          " AND M.CABMODSEQ = cm.CABMODSEQ" +
                                          " AND M.CABMOVIDTOPERACAO = 'EN'" + // movimento de entrada
                          " Left Join TCCCABMOV cv On cv.CABADMCOD = cm.CABADMCOD" +
                                                " AND cv.EXPMONCOD = cm.EXPMONCOD" +
                                                " And cv.RECEBINRO = cm.RECEBINRO" +
                                                " And cv.CABMODDATREGISTRO = cm.CABMODDATREGISTRO" +
                                                " And cv.CABMODSEQ = cm.CABMODSEQ" +
                                                " And cv.CABPARNRO = cp.CABPARNRO" +
                          " Join TCCCAIXA c On c.CAIXACOD = M.CABMODCODAGEATU" +
                          " Join TGLFILIAL f On f.FILIALCOD = c.FILIALCOD" +
                          " Where cm.CABMODIDTSITUACAO NOT IN ('CA', 'CR')" + // despreza vendas canceladas
                          " AND " + (tipoData.Equals("V") ? "cm.CABMODDATREGISTRO" : "cp.CABPARDATVENCTO") + " = " + dtFiltro;

                    command = new FbCommand(sql, conn);

                    using (FbDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            retorno.Registros.Add(new TitulosExpress
                            {
                                nrCNPJ = Convert.ToString(dr["nrCNPJ"]).Trim(),
                                nrNSU = dr["nrNSU"].Equals(DBNull.Value) ? null : Convert.ToString(dr["nrNSU"]),
                                dtVenda = Convert.ToDateTime(Convert.ToString(dr["dtVenda"]).Substring(0, 4) + "-" + Convert.ToString(dr["dtVenda"]).Substring(4, 2) + "-" + Convert.ToString(dr["dtVenda"]).Substring(6, 2)),
                                //cdAdquirente = Convert.ToInt32(dr["cdAdquirente"]),
                                dsBandeira = dr["dsBandeira"].Equals(DBNull.Value) ? null : Convert.ToString(dr["dsBandeira"]).Trim(),
                                cdSacado = dr["dsBandeira"].Equals(DBNull.Value) ? null : Convert.ToString(dr["dsBandeira"]).Trim(),
                                vlVenda = Convert.ToDouble(dr["vlVenda"]),
                                qtParcelas = Convert.ToInt32(dr["qtParcelas"]),
                                dtTitulo = Convert.ToDateTime(Convert.ToString(dr["dtTitulo"]).Substring(0, 4) + "-" + Convert.ToString(dr["dtTitulo"]).Substring(4, 2) + "-" + Convert.ToString(dr["dtTitulo"]).Substring(6, 2)),
                                vlParcela = Convert.ToDouble(dr["vlParcela"]),
                                nrParcela = Convert.ToInt32(dr["nrParcela"]),
                                cdERP = Convert.ToString(dr["cdERP"]),
                                dtBaixaERP = dr["dtBaixaERP"].Equals(DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dr["dtBaixaERP"]).Substring(0, 4) + "-" + Convert.ToString(dr["dtBaixaERP"]).Substring(4, 2) + "-" + Convert.ToString(dr["dtBaixaERP"]).Substring(6, 2))
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
                }
                finally
                {
                    conn.Close();
                }

                retorno.TotalDeRegistros = retorno.Registros.Count;

                int skipRows = (pageNumber - 1) * pageSize;
                pageNumber = 1;

                retorno.PaginaAtual = pageNumber;
                retorno.ItensPorPagina = pageSize;

                return retorno;
            }
            catch (Exception e)
            {
                if (e is DbEntityValidationException)
                {
                    string erro = MensagemErro.getMensagemErro((DbEntityValidationException)e);
                    throw new Exception(erro.Equals("") ? "Falha ao corrigir as vendas" : erro);
                }
                throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
            }
            finally
            {
                if (_dbAtosContext == null)
                {
                    // Fecha conexão
                    _dbAtos.Database.Connection.Close();
                    _dbAtos.Dispose();
                }
            }
        }
    }
}
