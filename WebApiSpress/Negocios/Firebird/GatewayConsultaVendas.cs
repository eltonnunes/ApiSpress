using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using WebApiSpress.Bibliotecas;
using WebApiSpress.Models.Object;
using WebApiSpress.Models.Sql;

namespace WebApiSpress.Negocios.Firebird
{
    public class GatewayConsultaVendas
    {
        public GatewayConsultaVendas() { }

        #region CAMPOS
        /// <summary>
        /// Enum CAMPOS
        /// </summary>
        public enum CAMPOS
        {
            DATA = 100,
            ID_GRUPO = 101,
            NRCNPJ = 102,
        };
        #endregion


        /// <summary>
        ///  Retorna Vendas
        /// </summary>
        /// <param name="token"></param>
        /// <param name="colecao"></param>
        /// <param name="campo"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static Retorno Get(string token, int colecao = 0, int campo = 0, int orderBy = 0, int pageSize = 0, int pageNumber = 0, Dictionary<string, string> queryString = null, painel_taxservices_dbContext _dbAtosContext = null)//, AlphaContext _dbAlphaContext = null)
        {
            string outValue = null;
            String dtFiltro = String.Empty;
            if (!queryString.TryGetValue("" + (int)CAMPOS.DATA, out outValue))
                throw new Exception("É necessário informar a data");

            // Obtém a data
            dtFiltro = queryString["" + (int)CAMPOS.DATA];

            //dtFiltro = "20160215";
            dtFiltro = dtFiltro.Replace("-", "");

            
            string nrCNPJ = null;
            if (queryString.TryGetValue("" + (int)CAMPOS.NRCNPJ, out outValue))
                nrCNPJ = queryString["" + (int)CAMPOS.NRCNPJ];
            
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

            Retorno retorno = new Retorno();
            retorno.Registros = new List<dynamic>();

            try
            {
                if (connstring == null || connstring.Trim().Equals(""))
                    throw new Exception("Não foi possível obter a string de conexão do cliente");

                FbConnection conn = new FbConnection(connstring);

                try
                {
                    conn.Open();
                }
                catch//(Exception e)
                {
                    //throw new Exception("Falha na abertura da conexão (Cliente). " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                    throw new Exception("Falha de comunicação com o servidor do Cliente");
                }

                List<ConsultaVendas> list = new List<ConsultaVendas>();

                try
                {
                    // VENDAS À CRÉDITO
                    string script = "SELECT SUBSTRING(F.FILIALNROCGC FROM 2 FOR 14) AS nrCNPJ" +
                                ", (CASE WHEN VC.CACMODNROCARTAO IS NULL OR VC.CACMODNROCARTAO = ''" + // CACMODNROCARTAO : CHAR(16)
                                       " THEN NULL" +
                                       " ELSE CAST(VC.CACMODNROCARTAO AS VARCHAR(30))" +
                                  " END) AS nrNSU" +
                                ", CAST(SUBSTRING(VC.CACMODDATREGISTRO FROM 1 FOR 4) || '-' ||" + 
                                " SUBSTRING(VC.CACMODDATREGISTRO FROM 5 FOR 2) || '-' ||" + 
                                " SUBSTRING(VC.CACMODDATREGISTRO FROM 7 FOR 2) AS DATE) AS dtVenda" +
                                //", cdSacado = NULL" +
                                ", VC.EXPMONCOD AS dsBandeira" +
                                ", VC.CACMODVLR AS vlVenda" +
                                ", VC.CACMODNROPARCELAS AS qtParcelas" +
                                //", CAST(VC.RECEBINRO AS VARCHAR(15)) AS cdERP" +
                                ", VC.K0 AS cdERP" +
                                //", CAST(VC.CACRESNRO AS VARCHAR(30)) AS codResumoVenda" +
                                " FROM TCCCACMOD VC" +
                                " JOIN TCCCACMOV M ON M.RECEBINRO = VC.RECEBINRO" +
                                                 " AND M.EXPMONCOD = VC.EXPMONCOD" +
                                                 " AND M.CACADMCOD = VC.CACADMCOD" +
                                                 " AND M.CACMODDATREGISTRO = VC.CACMODDATREGISTRO" +
                                                 " AND M.CACMODSEQ = VC.CACMODSEQ" +
                                                 " AND M.CACMOVIDTOPERACAO = 'EN'" + // movimento de entrada
                                " JOIN TCCCAIXA C ON C.CAIXACOD = M.CACMODCODAGEATU" + 
                                " JOIN TGLFILIAL F ON F.FILIALCOD = C.FILIALCOD" +
                                " WHERE VC.CACMODIDTSITUACAO NOT IN ('CA', 'CR')" + // despreza vendas canceladas
                                " AND VC.CACMODDATREGISTRO = " + dtFiltro + 
                                (nrCNPJ == null ? "" : " AND F.FILIALNROCGC LIKE '%" + nrCNPJ + "'");

                    FbCommand command = new FbCommand(script, conn);

                    using (FbDataReader r = command.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            retorno.Registros.Add(new ConsultaVendas
                            {
                                cdERP = Convert.ToString(r["cdERP"]),
                                cdSacado = r["dsBandeira"].Equals(DBNull.Value) ? null : Convert.ToString(r["dsBandeira"]).Trim(),
                                dsBandeira = r["dsBandeira"].Equals(DBNull.Value) ? null : Convert.ToString(r["dsBandeira"]).Trim(),
                                dtVenda = (DateTime)r["dtVenda"],
                                nrCNPJ = Convert.ToString(r["nrCNPJ"]).Trim(),
                                nrNSU = r["nrNSU"].Equals(DBNull.Value) ? null : Convert.ToString(r["nrNSU"]).Trim(),
                                qtParcelas = Convert.ToInt32(r["qtParcelas"]),
                                vlVenda = Convert.ToDecimal(r["vlVenda"])
                            });
                        }
                    }


                    // Débito
                    script = "SELECT SUBSTRING(F.FILIALNROCGC FROM 2 FOR 14) AS nrCNPJ" +
                                ", (CASE WHEN VD.CABMODNROCARTAO IS NULL OR VD.CABMODNROCARTAO = 0" + // CABMODNROCARTAO : INTEGER
                                       " THEN NULL" +
                                       " ELSE CAST(VD.CABMODNROCARTAO AS VARCHAR(30))" +
                                  " END) AS nrNSU" +
                                ", CAST(SUBSTRING(VD.CABMODDATREGISTRO FROM 1 FOR 4) || '-' ||" +
                                " SUBSTRING(VD.CABMODDATREGISTRO FROM 5 FOR 2) || '-' ||" +
                                " SUBSTRING(VD.CABMODDATREGISTRO FROM 7 FOR 2) AS DATE) AS dtVenda" +
                                //", cdSacado = NULL" +
                                ", VD.EXPMONCOD AS dsBandeira" +
                                ", VD.CABMODVLR AS vlVenda" +
                                ", VD.CABMODNROPARCELAS AS qtParcelas" +
                                //", CAST(VD.RECEBINRO AS VARCHAR(15)) AS cdERP" +
                                ", VD.K0 AS cdERP" +
                                //", CAST(VD.CABRESNRO AS VARCHAR(30)) AS codResumoVenda" +
                                " FROM TCCCABMOD VD" +
                                " JOIN TCCCABMOV M ON M.RECEBINRO = VD.RECEBINRO" +
                                                 " AND M.EXPMONCOD = VD.EXPMONCOD" +
                                                 " AND M.CABADMCOD = VD.CABADMCOD" +
                                                 " AND M.CABMODDATREGISTRO = VD.CABMODDATREGISTRO" +
                                                 " AND M.CABMODSEQ = VD.CABMODSEQ" +
                                                 " AND M.CABMOVIDTOPERACAO = 'EN'" + // movimento de entrada
                                " JOIN TCCCAIXA C ON C.CAIXACOD = M.CABMODCODAGEATU" + 
                                " JOIN TGLFILIAL F ON F.FILIALCOD = C.FILIALCOD" +
                                " WHERE VD.CABMODIDTSITUACAO NOT IN ('CA', 'CR')" + // despreza vendas canceladas
                                " AND VD.CABMODDATREGISTRO = " + dtFiltro + // campo é inteiro!
                                (nrCNPJ == null ? "" : " AND F.FILIALNROCGC LIKE '%" + nrCNPJ + "'");

                    command = new FbCommand(script, conn);

                    using (FbDataReader r = command.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            retorno.Registros.Add(new ConsultaVendas
                            {
                                cdERP = Convert.ToString(r["cdERP"]),
                                cdSacado = r["dsBandeira"].Equals(DBNull.Value) ? null : Convert.ToString(r["dsBandeira"]).Trim(),
                                dsBandeira = r["dsBandeira"].Equals(DBNull.Value) ? null : Convert.ToString(r["dsBandeira"]).Trim(),
                                dtVenda = (DateTime)r["dtVenda"],
                                nrCNPJ = Convert.ToString(r["nrCNPJ"]).Trim(),
                                nrNSU = r["nrNSU"].Equals(DBNull.Value) ? null : Convert.ToString(r["nrNSU"]).Trim(),
                                qtParcelas = Convert.ToInt32(r["qtParcelas"]),
                                vlVenda = Convert.ToDecimal(r["vlVenda"])
                            });
                        }
                    }
                    
                }
                catch(Exception e)
                {
                    throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
                    //throw new Exception("Falha na consulta das vendas (Cliente)");
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
                    throw new Exception(erro.Equals("") ? "Falha ao consultar as vendas" : erro);
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