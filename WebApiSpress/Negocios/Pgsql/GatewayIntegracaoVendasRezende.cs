using FirebirdSql.Data.FirebirdClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Web;
using WebApiSpress.Bibliotecas;
using WebApiSpress.Models.Object;
using WebApiSpress.Models.Sql;

namespace WebApiSpress.Negocios.Pgsql
{
    public class GatewayIntegracaoVendasRezende
    {
        /// <summary>
        /// Enum CAMPOS
        /// </summary>
        public enum CAMPOS
        {
            DATA = 100,
            ID_GRUPO = 101,
            NRCNPJ = 102,
            COMPARATIVO = 103,
        };

        public static string[] CNPJS_VENDAS_REZENDE = { "13007828001004",   // POSTO GONÇALO
                                                        "13007828001519" }; // POSTO LAGARTO

        /// <summary>
        /// Retorna ADMCOD, EXPMONCOD, TABELA ("C" : CRÉDITO => CAC | "D" : DÉBITO => CAB)
        /// </summary>
        /// <param name="cdSacado"></param>
        /// <param name="qtParcelas"></param>
        /// <returns></returns>
        public static string[] GetEspecieMonetariaFromSacadoTyresoles(int cdSacado, int qtParcelas)
        {
            switch (cdSacado)
            {
                case 2: return new string[] { "4", "VISA" + (qtParcelas >= 7 ? "+7" : ""), "C" };
                case 3: return new string[] { "2", "VISAELET", "D" };
                case 4: return new string[] { "1", "MASTER" + (qtParcelas >= 7 ? "+7" : ""), "C" }; // cabal, avista?? maestro pela REDE
                case 5: return new string[] { "1", "REDSHOP", "D" };
                case 6: return new string[] { "5", "AMERICAN", "C" };
                case 8: return new string[] { "8", "GOODCAR", "C" };
                case 9: return new string[] { "2", "HIPER" + (qtParcelas >= 7 ? "+7" : ""), "C" };
                case 10: return new string[] { "3", "BANESEDE", "D" };
                case 11: return new string[] { "3", "BANESE", "C" };
                case 19: return new string[] { "1", "DINERS" + (qtParcelas >= 7 ? "+7" : ""), "C" }; // diners pela REDE
                case 22: return new string[] { "4", "ELOD", "D" };
                case 23: return new string[] { "4", "ELO", "C" };
                case 98: return new string[] { "6", "TCKTCAR", "C" };
                case 167: return new string[] { "11", "SODEXO", "C" };
                case 171: return new string[] { "1", "SHELL", "C" };
                case 72721: return new string[] { "1", "DINERS" + (qtParcelas >= 7 ? "+7" : ""), "C" }; // diners pela CIELO
                case 72723: return new string[] { "1", "REDSHOP", "D" }; // MAESTRO pela CIELO
                default: return null;
            }
        }

        public static VendaSpress GetVendaSpress(string K0, FbConnection conn, FbTransaction transaction = null)
        {
            if (conn == null)
                throw new Exception("Conexão inválida!");

            if (!conn.State.Equals(ConnectionState.Open))
                throw new Exception("Comunicação com o servidor do Cliente não estabelecida!");

            VendaSpress vendaSpress = null;
            // Busca primeiro na tabela de vendas à crédito
            string script = "SELECT RECEBINRO, CACADMCOD, EXPMONCOD, CACMODDATREGISTRO, CACMODSEQ, CACMODNROPARCELAS" +
                    ", CACMODCODBANATU,	CACMODCODAGEATU, CACMODCODCONATU, CACMODNROCARTAO, CACRESNRO, CACMODIDTSITUACAO" +
                    ", CACMODDATPRORROG, CACMODVLR, CACADMIDTREGISTRO, CACMODIDTFORMA, CLIENTNRO, CACMODCODBANORI" +
                    ", CACMODCODAGEORI, CACMODCODCONORI" +
                     " FROM TCCCACMOD" +
                     " WHERE K0 = '" + K0 + "'";
            FbCommand command = new FbCommand(script, conn);
            if (transaction != null)
                command.Transaction = transaction;

            using (FbDataReader dr = command.ExecuteReader())
            {
                if (dr.Read())
                {
                    //vendaCredito = true;
                    vendaSpress = new VendaSpress()
                    {
                        TIPO = 'C',
                        ADMCOD = Convert.ToInt32(dr["CACADMCOD"]),
                        RECEBINRO = Convert.ToInt32(dr["RECEBINRO"]),
                        RESNRO = dr["CACRESNRO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["CACRESNRO"]),
                        EXPMONCOD = Convert.ToString(dr["EXPMONCOD"]),
                        MODSEQ = Convert.ToInt32(dr["CACMODSEQ"]),
                        MODDATREGISTRO = Convert.ToInt32(dr["CACMODDATREGISTRO"]),
                        MODNROPARCELAS = Convert.ToInt32(dr["CACMODNROPARCELAS"]),
                        MODCODBANATU = Convert.ToInt32(dr["CACMODCODBANATU"]),
                        CACMODDATPRORROG = Convert.ToInt32(dr["CACMODDATPRORROG"]),
                        MODCODAGEATU = Convert.ToInt32(dr["CACMODCODAGEATU"]),
                        MODCODCONATU = Convert.ToString(dr["CACMODCODCONATU"]),
                        MODNROCARTAO = Convert.ToString(dr["CACMODNROCARTAO"]),
                        K0 = K0,
                        MODIDTSITUACAO = Convert.ToString(dr["CACMODIDTSITUACAO"]),
                        MODVLR = Convert.ToDecimal(dr["CACMODVLR"]),
                        MODVLRTXFHIST = Convert.ToDecimal(dr["CACMODVLRTXFHIST"]),
                        CACADMIDTREGISTRO = Convert.ToString(dr["CACADMIDTREGISTRO"]),
                        CACMODIDTFORMA = Convert.ToString(dr["CACMODIDTFORMA"]),
                        CLIENTNRO = Convert.ToInt32(dr["CLIENTNRO"]),
                        MODCODBANORI = Convert.ToInt32(dr["CACMODCODBANORI"]),
                        MODCODAGEORI = Convert.ToInt32(dr["CACMODCODAGEORI"]),
                        MODCODCONORI = Convert.ToString(dr["CACMODCODCONORI"]),
                    };
                }
            }

            if (vendaSpress == null)
            {
                // Verifica se existe na tabela de vendas à débito
                script = "SELECT RECEBINRO, CABADMCOD, EXPMONCOD, CABMODDATREGISTRO, CABMODSEQ, CABMODNROPARCELAS" +
                    ", CABMODCODBANATU,	CABMODCODAGEATU, CABMODCODCONATU, CABMODNROCARTAO, CABRESNRO, CABMODIDTSITUACAO" +
                    ", CABMODVLR, CABMODVLRTXFHIST, CLIENTNRO, CABMODCODBANORI, CABMODCODAGEORI, CABMODCODCONORI" +
                    ", CABMODNRODIAREC, BANCOSCOD, AGEBANCOD, CONCORNRO" +
                     " FROM TCCCABMOD" +
                     " WHERE K0 = '" + K0 + "'";
                command = new FbCommand(script, conn);
                if (transaction != null)
                    command.Transaction = transaction;

                using (FbDataReader dr = command.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vendaSpress = new VendaSpress()
                        {
                            TIPO = 'D',
                            ADMCOD = Convert.ToInt32(dr["CABADMCOD"]),
                            RECEBINRO = Convert.ToInt32(dr["RECEBINRO"]),
                            RESNRO = dr["CABRESNRO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["CABRESNRO"]),
                            EXPMONCOD = Convert.ToString(dr["EXPMONCOD"]),
                            MODSEQ = Convert.ToInt32(dr["CABMODSEQ"]),
                            MODDATREGISTRO = Convert.ToInt32(dr["CABMODDATREGISTRO"]),
                            MODNROPARCELAS = Convert.ToInt32(dr["CABMODNROPARCELAS"]),
                            MODCODBANATU = Convert.ToInt32(dr["CABMODCODBANATU"]),
                            MODCODAGEATU = Convert.ToInt32(dr["CABMODCODAGEATU"]),
                            MODCODCONATU = Convert.ToString(dr["CABMODCODCONATU"]),
                            MODNROCARTAO = Convert.ToString(/*Convert.ToInt32(*/dr["CABMODNROCARTAO"]),//),
                            K0 = K0,
                            MODIDTSITUACAO = Convert.ToString(dr["CABMODIDTSITUACAO"]),
                            CABMODNRODIAREC = Convert.ToInt32(dr["CABMODNRODIAREC"]),
                            BANCOSCOD = Convert.ToInt32(dr["BANCOSCOD"]),
                            AGEBANCOD = Convert.ToInt32(dr["AGEBANCOD"]),
                            CONCORNRO = Convert.ToString(dr["CONCORNRO"]),
                            MODVLR = Convert.ToDecimal(dr["CABMODVLR"]),
                            MODVLRTXFHIST = Convert.ToDecimal(dr["CABMODVLRTXFHIST"]),
                            CLIENTNRO = Convert.ToInt32(dr["CLIENTNRO"]),
                            MODCODBANORI = Convert.ToInt32(dr["CABMODCODBANORI"]),
                            MODCODAGEORI = Convert.ToInt32(dr["CABMODCODAGEORI"]),
                            MODCODCONORI = Convert.ToString(dr["CABMODCODCONORI"]),
                        };
                    }
                }
            }

            return vendaSpress;
        }


        public static List<VendaRezende> ConsultaVendas(string connstring, string dtFiltro, string[] CNPJS, int pageSize = 0, int skipRows = 0)
        {
            if (connstring == null || connstring.Trim().Equals(""))
                throw new Exception("String de conexão deve ser informado!");

            if (CNPJS == null || CNPJS.Length == 0)
                throw new Exception("Filiais da consulta no Rezende devem ser informadas!");

            if (dtFiltro == null || dtFiltro.Trim().Equals(""))
                throw new Exception("Data deve ser informada!");

            NpgsqlConnection conn = new NpgsqlConnection(connstring);

            try
            {
                conn.Open();
            }
            catch
            {
                throw new Exception("Falha de comunicação com o servidor (Rezende)");
            }

            List<VendaRezende> vendas = new List<VendaRezende>();

            try
            {
                string script = "SELECT E.num_cnpj AS nrCNPJ" +
                                ", P.num_transacao_tef AS nrNSU" +
				                ", C.dta_cupom AS dtVenda" + 
				                ", F.cod_pessoa_sacado AS cdSacado" +
                                ", F.des_forma_pagto AS frmPagto" +
                                ", SUM(D.val_duplicata) AS vlVenda" +
				                ", (CASE WHEN D.qtd_parcelas_tef = 0 OR D.qtd_parcelas_tef IS NULL" + 
                                                     " THEN 1" +
						                             " ELSE D.qtd_parcelas_tef" +
                                " END) AS qtParcelas" + 
				                ", C.seq_cupom AS cdERP" +
                                ", C.num_cupom AS numCupom" +
                                " FROM tab_cupom_fiscal C" +
                                " JOIN tab_pagamento_cupom P ON P.seq_cupom = C.seq_cupom" +
                                " JOIN tab_duplicata_receber D on P.seq_cupom = D.seq_cupom AND P.seq_pagamento = D.seq_pagamento" +
                                " JOIN tab_forma_pagto_pdv F ON F.cod_forma_pagto = D.cod_forma_pagto" +
                                " JOIN tab_empresa E ON E.cod_empresa = C.cod_empresa" +
                                " WHERE C.dta_cupom = '" + dtFiltro + "'" +
			                    " AND F.ind_tipo = 'CC'" +
                                " AND E.num_cnpj IN ('" + string.Join("', '", CNPJS) + "')" +
                                " GROUP BY C.seq_cupom, C.dta_cupom, E.num_cnpj, P.num_transacao_tef" +
                                ", D.qtd_parcelas_tef, F.cod_pessoa_sacado, C.num_cupom, F.des_forma_pagto" +
                                " ORDER BY C.seq_cupom, P.num_transacao_tef" + 
                                (pageSize == 0 ? "" : " LIMIT " + pageSize) +
                                (skipRows == 0 ? "" : " OFFSET " + skipRows);

                // Define a query
                NpgsqlCommand command = new NpgsqlCommand(script, conn);

                using (NpgsqlDataReader dr = command.ExecuteReader())
                {
                    vendas = dr.Cast<IDataRecord>()
                                .Select(r => new VendaRezende
                                {
                                    cdERP = Convert.ToInt32(r["cdERP"]),
                                    cdSacado = Convert.ToInt32(r["cdSacado"]),
                                    frmPagto = Convert.ToString(r["frmPagto"].Equals(DBNull.Value) ? "" : r["frmPagto"]),
                                    dtVenda = (DateTime)r["dtVenda"],
                                    nrCNPJ = Convert.ToString(r["nrCNPJ"]),
                                    nrNSU = r["nrNSU"].Equals(DBNull.Value) ? null : Convert.ToString(r["nrNSU"]),
                                    qtParcelas = Convert.ToInt32(r["qtParcelas"]),
                                    vlVenda = Convert.ToDecimal(r["vlVenda"]),
                                    numCupom = Convert.ToInt32(r["numCupom"])
                                })
                                .ToList<VendaRezende>();
                }
            }
            catch
            {
                throw new Exception("Falha de comunicação com o servidor (Rezende)");
            }
            finally
            {
                conn.Close();
            }

            return vendas;
        }


        public static Retorno ImportaVendasRezende(string token, int colecao, int campo, int orderBy, int pageSize, int pageNumber, Dictionary<string, string> queryString, painel_taxservices_dbContext _dbAtos)
        {
            string outValue = null;
            String dtFiltro = String.Empty;
            if (!queryString.TryGetValue("" + (int)CAMPOS.DATA, out outValue))
                throw new Exception("É necessário informar a data");

            // Obtém a data
            dtFiltro = queryString["" + (int)CAMPOS.DATA];

            string nrCNPJ = null;
            if (queryString.TryGetValue("" + (int)CAMPOS.NRCNPJ, out outValue))
                nrCNPJ = queryString["" + (int)CAMPOS.NRCNPJ];

            bool obterComparativo = true;
            if (queryString.TryGetValue("" + (int)CAMPOS.COMPARATIVO, out outValue))
                obterComparativo = Convert.ToBoolean(queryString["" + (int)CAMPOS.COMPARATIVO]);

            int cdGrupo = Permissoes.GetIdGrupo(token, _dbAtos);

            string[] CNPJs = nrCNPJ == null ? CNPJS_VENDAS_REZENDE : new string[] { nrCNPJ };

            Retorno retorno = new Retorno();
            retorno.Registros = new List<dynamic>();

            try
            {
                // PAGINAÇÃO
                int skipRows = (pageNumber - 1) * pageSize;

                // OBTÉM AS VENDAS DO REZENDE
                string connstringRezende = ConfigurationManager.ConnectionStrings["TyresolesRezendeContext"].ConnectionString;
                List<VendaRezende> vendas = ConsultaVendas(connstringRezende, dtFiltro, CNPJs);//, pageSize, skipRows);

                retorno.TotalDeRegistros = vendas.Count;
                if (vendas.Count > pageSize && pageNumber > 0 && pageSize > 0)
                    vendas = vendas.Skip(skipRows).Take(pageSize).ToList<VendaRezende>();
                else
                    pageNumber = 1;

                retorno.PaginaAtual = pageNumber;
                retorno.ItensPorPagina = pageSize;

                //string connstring = Bibliotecas.Permissoes.GetConnectionString(token, _dbAtos);
                string connstring = "User=SYSDBA;Password=masterkey;Database=C:\\IBX\\dealer.fdb;Dialect=3;Charset=NONE";

                if (connstring == null || connstring.Trim().Equals(""))
                    throw new Exception("Não foi possível obter a string de conexão do cliente");

                FbConnection conn = new FbConnection(connstring);

                try
                {
                    conn.Open();
                }
                catch
                {
                    throw new Exception("Falha de comunicação com o servidor do Cliente (Spress)");
                }

                try
                {
                    for (int k = 0; k < vendas.Count; k++)
                    {
                        VendaRezende vendaRezende = vendas[k];

                        VendaSpress vendaSpress = obterComparativo ? null : GetVendaSpress(_dbAtos, conn, cdGrupo, vendaRezende.cdERP, vendaRezende.nrNSU);
                        if (vendaSpress == null)
                        {
                            vendaSpress = new VendaSpress();
                            #region OBTÉM OBJETO VENDA SPRESS A PARTIR DA VENDA REZENDE
                            vendaSpress.CLIENTNRO = 53650; // cartões de crédito não identificado

                            #region OBTEM ESPÉCIE MONETÁRIA
                            string[] especieMonetaria = GetEspecieMonetariaFromSacadoTyresoles(vendaRezende.cdSacado, vendaRezende.qtParcelas);
                            if (especieMonetaria == null)
                                throw new Exception("Não foi possível obter a espécie monetária da forma de pagamento '" + vendaRezende.frmPagto + "'");

                            vendaSpress.ADMCOD = Convert.ToInt32(especieMonetaria[0]);
                            vendaSpress.EXPMONCOD = especieMonetaria[1];
                            vendaSpress.TIPO = especieMonetaria[2][0];

                            #endregion

                            // Data da Venda
                            vendaSpress.MODDATREGISTRO = Convert.ToInt32(vendaRezende.dtVenda.ToString("yyyyMMdd"));
                            // Valor da Venda
                            vendaSpress.MODVLR = vendaRezende.vlVenda;
                            // Número de parcelas
                            vendaSpress.MODNROPARCELAS = vendaRezende.qtParcelas;

                            #region CAIXA DE ORIGEM
                            string script = "SELECT FILIALCOD" +
                                            " FROM TGLFILIAL" +
                                            " WHERE SUBSTRING(FILIALNROCGC FROM 2 FOR 14) = '" + vendaRezende.nrCNPJ + "'";
                            FbCommand command = new FbCommand(script, conn);
                            using (FbDataReader r = command.ExecuteReader())
                            {
                                if (!r.Read())
                                    throw new Exception("Caixa não identificado para a filial " + vendaRezende.nrCNPJ);
                                vendaSpress.MODCODAGEORI = vendaSpress.MODCODAGEATU = Convert.ToInt32(r["FILIALCOD"]);
                            }
                            vendaSpress.MODCODBANORI = vendaSpress.MODCODBANATU = 0;
                            vendaSpress.MODCODCONORI = vendaSpress.MODCODCONATU = vendaSpress.EXPMONCOD;
                            #endregion

                            // Seq
                            vendaSpress.MODSEQ = 1;
                            // Sem resumo associado
                            vendaSpress.RESNRO = 0;
                            // Situação: Aberto
                            vendaSpress.MODIDTSITUACAO = "AB";
                            // NSU => pega somente os 4 últimos dígitos => forçar NSU estar errada!
                            if (vendaRezende.nrNSU == null || vendaRezende.nrNSU.Trim().Equals("0") || vendaRezende.nrNSU.Trim().Equals(""))
                                vendaSpress.MODNROCARTAO = "";
                            else if (vendaRezende.nrNSU.Length > 4)
                                vendaSpress.MODNROCARTAO = vendaRezende.nrNSU.Substring(vendaRezende.nrNSU.Length - 4);
                            else
                                vendaSpress.MODNROCARTAO = vendaRezende.nrNSU;

                            #region TAXA IOC
                            if (vendaSpress.TIPO == 'C')
                            {
                                script = "SELECT " + (vendaRezende.qtParcelas > 1 ? "CACTXFVLRTAXPAR" : "CACTXFVLRTAXROT") + " AS TAXA" +
                                         " FROM TCCCACTXF" +
                                         " WHERE CACADMCOD = " + vendaSpress.ADMCOD +
                                         " AND EXPMONCOD = '" + vendaSpress.EXPMONCOD + "'" +
                                         " AND FILIALCOD = " + vendaSpress.MODCODAGEATU;
                            }
                            else
                            {
                                script = "SELECT CABTXFVLRTAXMEN AS TAXA" +
                                         " FROM TCCCABTXF" +
                                         " WHERE CABADMCOD = " + vendaSpress.ADMCOD +
                                         " AND EXPMONCOD = '" + vendaSpress.EXPMONCOD + "'" +
                                         " AND FILIALCOD = " + vendaSpress.MODCODAGEATU;
                            }
                            command = new FbCommand(script, conn);
                            using (FbDataReader r = command.ExecuteReader())
                            {
                                if (!r.Read())
                                {
                                    if(connstring.Contains("Database=C:\\IBX\\dealer.fdb"))// base local
                                        vendaSpress.MODVLRTXFHIST = new decimal(0.0);
                                    else
                                        throw new Exception("Taxa não identificada para a filial " + vendaRezende.nrCNPJ +
                                                            ", espécie monetária " + vendaSpress.EXPMONCOD);
                                }
                                else
                                    vendaSpress.MODVLRTXFHIST = Convert.ToDecimal(r["TAXA"]);
                            }
                            #endregion

                            // Específicos de CAB
                            vendaSpress.CABMODNRODIAREC = 1;
                            vendaSpress.BANCOSCOD = 0;
                            vendaSpress.AGEBANCOD = 0;
                            vendaSpress.CONCORNRO = String.Empty;

                            // Específicos de CAC
                            vendaSpress.CACADMIDTREGISTRO = "O"; // online
                            vendaSpress.CACMODDATPRORROG = vendaSpress.MODDATREGISTRO;
                            vendaSpress.CACMODIDTFORMA = vendaRezende.qtParcelas > 1 ? "PS" : "RO"; // Forma de pagamento
                            #endregion

                            if (!obterComparativo)
                            {
                                InsereVendaNoSpress(conn, vendaSpress, vendaRezende.numCupom);

                                #region ATUALIZA TABELA tbIntegracaoERPs
                                string k0 = GetK0(_dbAtos, cdGrupo, vendaRezende.cdERP, vendaRezende.nrNSU);
                                string key = GetCdERPOrigem(vendaRezende.cdERP, vendaRezende.nrNSU);

                                if (k0 != null)
                                {
                                    // Atualiza
                                    script = "UPDATE I" +
                                             " SET cdERPDestino = '" + vendaSpress.K0 + "'" +
                                             " FROM card.tbIntegracaoERPs" + // tabela rezende-spress
                                             " WHERE cdGrupo = " + cdGrupo +
                                             " AND dsTipo = 'VENDA'" +
                                             " AND cdERPOrigem = '" + key + "'";
                                }
                                else
                                {
                                    // Insere
                                    script = "INSERT INTO card.tbIntegracaoERPs (cdGrupo, cdERPOrigem, dsTipo, cdERPDestino)" +
                                             " VALUES(" + cdGrupo + ", '" + key + "'" + ", 'VENDA'" + ", '" + vendaSpress.K0 + "')";
                                }
                                try
                                {
                                    _dbAtos.Database.ExecuteSqlCommand(script);
                                }
                                catch
                                {
                                    throw new Exception("Falha ao salvar na tabela de integração (Atos)");
                                }
                                #endregion
                            }
                        }

                        // Adiciona
                        if (!obterComparativo)
                            retorno.Registros.Add(vendaSpress);
                        else
                        {
                            retorno.Registros.Add(new
                            {
                                Rezende = vendaRezende,
                                Spress = vendaSpress
                            });
                        }

                    }
                }
                catch(Exception e)
                {
                    throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
                }
                finally
                {
                    conn.Close();
                }

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
        }


        public static VendaSpress GetVendaSpress(painel_taxservices_dbContext _dbAtos, FbConnection conn, int cdGrupo, int seq_cupom, string num_transacao_tef)
        {
            string K0 = GetK0(_dbAtos, cdGrupo, seq_cupom, num_transacao_tef);
            if (K0 == null)
                return null;

            return GetVendaSpress(K0, conn);
        }

        public static string GetCdERPOrigem(int seq_cupom, string num_transacao_tef)
        {
            return "S" + seq_cupom + "N" + (num_transacao_tef == null ? "" : num_transacao_tef);
        }

        public static string GetK0(painel_taxservices_dbContext _dbAtos, int cdGrupo, int seq_cupom, string num_transacao_tef)
        {
            if (_dbAtos == null)
                throw new Exception("Conexão com a base da Atos inválida!");

            if (seq_cupom == 0 || cdGrupo == 0)
                return null;

            string key = GetCdERPOrigem(seq_cupom, num_transacao_tef);

            return _dbAtos.Database.SqlQuery<string>("SELECT cdERPDestino" + 
                                              " FROM card.tbIntegracaoERPs (NOLOCK)" + // tabela rezende-spress
                                              " WHERE cdGrupo = " + cdGrupo +
                                              " AND dsTipo = 'VENDA'" +
                                              " AND cdERPOrigem = '" + key + "'")
                                    .FirstOrDefault();
        }

        public static void InsereVendaNoSpress(FbConnection conn, VendaSpress vendaSpress, int numCupom)
        {
            if (conn == null)
                throw new Exception("Conexão inválida!");

            if (!conn.State.Equals(ConnectionState.Open))
                throw new Exception("Comunicação com o servidor do Cliente não estabelecida!");

            if (vendaSpress == null)
                throw new Exception("Venda inválida!");

            FbTransaction transaction = conn.BeginTransaction();

            try
            {
                DateTime dataOperacao = DateTime.Now;
                int USUARICOD = 9990; // USUARIO ATOS CAPITAL


                //vendaSpress.MODSEQ = 1; // NOVO REGISTRO => MODSEQ = 1
                //vendaSpress.CACADMIDTREGISTRO = "O"; // Online
                //vendaSpress.RESNRO = 0; // sem resumo
                //vendaSpress.MODIDTSITUACAO = "AB"; // Situação: Aberto

                FbCommand command;
                string script;

                #region INSERE NOVO REGISTRO EM TCCRECEBI
                script = "SELECT (MAX(RECEBINRO) + 1) AS RECEBINRO FROM TCCRECEBI";
                command = new FbCommand(script, conn);
                command.Transaction = transaction;
                int recebinro = 0;
                using (FbDataReader r = command.ExecuteReader())
                {
                    if (!r.Read())
                        throw new Exception("Falha ao obter próximo código de recebimento!");
                    recebinro = Convert.ToInt32(r["RECEBINRO"]);
                }

                //
                script = "INSERT INTO TCCRECEBI (RECEBINRO, USUARICOD, RECEBIDATOPERACAO, RECEBIDESOBS, RECEBIIDTNF" + 
                         ", RECEBIIDTDOCTO, RECEBIIDTADIANT, RECEBIIDTTROCA, RECEBIIDTDIVER, RECEBIIDTESTORNADO, RECEBIIDTPRENF)" +
                         " VALUES (" + recebinro + ", " + USUARICOD + ", " + dataOperacao.ToString("yyyyMMdd") + 
                         ", 'Recebimentos diversos', 'S', 'N', 'N', 'N', 'N', 'N', 'N')";
                command = new FbCommand(script, conn);
                command.Transaction = transaction;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Criação do recebimento " + recebinro + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                }
                #endregion

                #region INSERE EM TCCCAxMOD
                if (vendaSpress.TIPO == 'C')
                {
                    script = "INSERT INTO TCCCACMOD (CACADMCOD, EXPMONCOD, RECEBINRO, CACMODDATREGISTRO" +
                             ", CACMODSEQ, CACMODDATPRORROG, CACMODVLR, CACMODVLRTXFHIST, CACADMIDTREGISTRO" +
                             ", CACMODIDTFORMA, CACRESNRO, CLIENTNRO, CACMODNROPARCELAS, CACMODIDTSITUACAO" +
                             ", CACMODNROCARTAO, CACMODCODBANORI, CACMODCODAGEORI, CACMODCODCONORI" +
                             ", CACMODCODBANATU, CACMODCODAGEATU, CACMODCODCONATU)" +
                             " VALUES (" + vendaSpress.ADMCOD +    // CACADMCOD
                             ", '" + vendaSpress.EXPMONCOD + "'" + // EXPMONCOD
                             ", " + recebinro +  // RECEBINRO
                             ", " + vendaSpress.MODDATREGISTRO + // CACMODDATREGISTRO
                             ", " + vendaSpress.MODSEQ + // CACMODSEQ
                             ", " + vendaSpress.MODDATREGISTRO + // CACMODDATPRORROG
                             ", " + vendaSpress.MODVLR.ToString(CultureInfo.GetCultureInfo("en-GB")) + // CACMODVLR
                             ", " + vendaSpress.MODVLRTXFHIST.ToString(CultureInfo.GetCultureInfo("en-GB")) +// CACMODVLRTXFHIST
                             ", '" + vendaSpress.CACADMIDTREGISTRO + "'" + // CACADMIDTREGISTRO ('O' ou 'M')
                             ", '" + vendaSpress.CACMODIDTFORMA + "'" + // CACMODIDTFORMA ('PS' ou 'RO')
                             ", " + vendaSpress.RESNRO + // CACRESNRO
                             ", " + vendaSpress.CLIENTNRO + // CLIENTNRO
                             ", " + vendaSpress.MODNROPARCELAS + // CACMODNROPARCELAS
                             ", '" + vendaSpress.MODIDTSITUACAO + "'" + // CACMODIDTSITUACAO ('AB': aberto)
                             ", " + (vendaSpress.MODNROCARTAO == null ? "NULL" : "'" + vendaSpress.MODNROCARTAO + "'") + //CACMODNROCARTAO (nsu)
                             ", " + vendaSpress.MODCODBANORI + // CACMODCODBANORI
                             ", " + vendaSpress.MODCODAGEORI + // CACMODCODAGEORI
                             ", '" + vendaSpress.MODCODCONORI + "'" + // CACMODCODCONORI
                             ", " + vendaSpress.MODCODBANATU + // CACMODCODBANATU
                             ", " + vendaSpress.MODCODAGEATU + // CACMODCODBANATU
                             ", '" + vendaSpress.MODCODCONATU + "'" + // CACMODCODBANATU
                             ")";
                }
                else
                {
                    // NSU em CAB é do tipo INT (max 6 dígitos)
                    if(vendaSpress.MODNROCARTAO == null)
                        vendaSpress.MODNROCARTAO = "0";
                    else
                    {
                        if(vendaSpress.MODNROCARTAO.Length > 6)
                            vendaSpress.MODNROCARTAO = vendaSpress.MODNROCARTAO.Substring(vendaSpress.MODNROCARTAO.Length - 6);
                        try
                        {
                            Convert.ToInt32(vendaSpress.MODNROCARTAO);
                        }
                        catch
                        {
                            vendaSpress.MODNROCARTAO = "0";
                        }
                    }

                    script = "INSERT INTO TCCCABMOD (CABADMCOD, EXPMONCOD, RECEBINRO, CABMODDATREGISTRO" +
                             ", CABMODSEQ, CABMODVLR, CABMODVLRTXFHIST, CABRESNRO, CLIENTNRO, CABMODNROPARCELAS" +
                             ", CABMODNRODIAREC, CABMODIDTSITUACAO, BANCOSCOD, AGEBANCOD, CONCORNRO" +
                             ", CABMODNROCARTAO, CABMODCODBANORI, CABMODCODAGEORI, CABMODCODCONORI" +
                             ", CABMODCODBANATU, CABMODCODAGEATU, CABMODCODCONATU)" +
                             " VALUES (" + vendaSpress.ADMCOD +    // CABADMCOD
                             ", '" + vendaSpress.EXPMONCOD + "'" + // EXPMONCOD
                             ", " + recebinro +  // RECEBINRO
                             ", " + vendaSpress.MODDATREGISTRO + // CABMODDATREGISTRO
                             ", " + vendaSpress.MODSEQ + // CABMODSEQ
                             ", " + vendaSpress.MODVLR.ToString(CultureInfo.GetCultureInfo("en-GB")) + // CABMODVLR
                             ", " + vendaSpress.MODVLRTXFHIST.ToString(CultureInfo.GetCultureInfo("en-GB")) +// CABMODVLRTXFHIST
                             ", " + vendaSpress.RESNRO + // CABRESNRO
                             ", " + vendaSpress.CLIENTNRO + // CLIENTNRO
                             ", " + vendaSpress.MODNROPARCELAS + // CABMODNROPARCELAS
                             ", " + vendaSpress.CABMODNRODIAREC + // CABMODNRODIAREC (QUAL O VALOR DEFAULT??)
                             ", '" + vendaSpress.MODIDTSITUACAO + "'" + // CABMODIDTSITUACAO ('AB': aberto)
                             ", " + vendaSpress.BANCOSCOD + // BANCOSCOD
                             ", " + vendaSpress.AGEBANCOD + // AGEBANCOD
                             ", '" + vendaSpress.CONCORNRO + "'" + // CONCORNRO
                             ", " + vendaSpress.MODNROCARTAO + //CABMODNROCARTAO (nsu)
                             ", " + vendaSpress.MODCODBANORI + // CABMODCODBANORI
                             ", " + vendaSpress.MODCODAGEORI + // CABMODCODAGEORI
                             ", '" + vendaSpress.MODCODCONORI + "'" + // CABMODCODCONORI
                             ", " + vendaSpress.MODCODBANATU + // CABMODCODBANATU
                             ", " + vendaSpress.MODCODAGEATU + // CABMODCODBANATU
                             ", '" + vendaSpress.MODCODCONATU + "'" + // CABMODCODBANATU
                             ")";
                }
                command = new FbCommand(script, conn);
                command.Transaction = transaction;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Inserção da venda " + vendaSpress.TIPO + " receb " + recebinro + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                }
                #endregion

                #region INSERE MOVIMENTAÇÃO DE ENTRADA

                if (vendaSpress.TIPO == 'C')
                {
                    script = "INSERT INTO TCCCACMOV (CACADMCOD, EXPMONCOD, RECEBINRO, CACMODDATREGISTRO" +
                             ", CACMODSEQ, CACMOVSEQ, CACMOVDATOPERACAO, CACMOVIDTOPERACAO, CACMOVVLROPERACAO" +
                             ", USUARICOD, CACMOVDATPRORROG, CACMOVVLRCUSFIN, CACMOVVLRCUSPAG, CACMOVCODINDICE" +
                             ", CACMODCODBANATU, CACMODCODAGEATU, CACMODCODCONATU, CACPARNRO)" +
                             " VALUES (" + vendaSpress.ADMCOD +  // CACADMCOD
                             ", '" + vendaSpress.EXPMONCOD + "'" +  // EXPMONCOD
                             ", " + recebinro +  // RECEBINRO
                             ", " + vendaSpress.MODDATREGISTRO + // CACMODDATREGISTRO
                             ", " + vendaSpress.MODSEQ +  // CACMODSEQ
                             ", 1" + // CACMOVSEQ
                             ", " + dataOperacao.ToString("yyyyMMdd") + // CACMOVDATOPERACAO
                             ", 'EN'" + // CACMOVIDTOPERACAO
                             ", " + vendaSpress.MODVLR.ToString(CultureInfo.GetCultureInfo("en-GB")) + // CACMOVVLROPERACAO
                             ", " + USUARICOD + // USUARICOD
                             ", " + vendaSpress.MODDATREGISTRO + // CACMOVDATPRORROG
                             ", 0" + //CACMOVVLRCUSFIN (Custo Financeiro)
                             ", 0" + // CACMOVVLRCUSPAG (Custo Pago)
                             ", ''" + // CACMOVCODINDICE (Indice)
                             ", " + vendaSpress.MODCODBANATU + // CACMODCODBANATU
                             ", " + vendaSpress.MODCODAGEATU + // CACMODCODAGEATU
                             ", '" + vendaSpress.MODCODCONATU + "'" + // CACMODCODCONATU 
                             ", 0)"; // CACPARNRO
                }
                else
                {
                    script = "INSERT INTO TCCCABMOV (CABADMCOD, EXPMONCOD, RECEBINRO, CABMODDATREGISTRO" +
                             ", CABMODSEQ, CABMOVSEQ, CABMOVDATOPERACAO, CABMOVIDTOPERACAO, CABMOVVLROPERACAO" +
                             ", USUARICOD, CABMODCODBANATU, CABMODCODAGEATU, CABMODCODCONATU, CABPARNRO)" +
                             " VALUES (" + vendaSpress.ADMCOD +  // CABADMCOD
                             ", '" + vendaSpress.EXPMONCOD + "'" +  // EXPMONCOD
                             ", " + recebinro +  // RECEBINRO
                             ", " + vendaSpress.MODDATREGISTRO + // CABMODDATREGISTRO
                             ", " + vendaSpress.MODSEQ +  // CABMODSEQ
                             ", 1" + // CABMOVSEQ
                             ", " + dataOperacao.ToString("yyyyMMdd") + // CABMOVDATOPERACAO
                             ", 'EN'" + // CABMOVIDTOPERACAO
                             ", " + vendaSpress.MODVLR.ToString(CultureInfo.GetCultureInfo("en-GB")) + // CABMOVVLROPERACAO
                             ", " + USUARICOD + // USUARICOD
                             ", " + vendaSpress.MODCODBANATU + // CABMODCODBANATU
                             ", " + vendaSpress.MODCODAGEATU + // CABMODCODAGEATU
                             ", '" + vendaSpress.MODCODCONATU + "'" + // CABMODCODCONATU 
                             ", 0)"; // CABPARNRO
                }
                command = new FbCommand(script, conn);
                command.Transaction = transaction;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Movimentação de entrada da venda " + vendaSpress.TIPO + " receb " + recebinro + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                }
                #endregion

                // Formata o recebimento com 10 dígitos
                string recebimentoNro = "0000000000" + recebinro;
                recebimentoNro = recebimentoNro.Substring(recebimentoNro.Length - 10);
                string MOVBANDES = "Recebimento Nr." + recebimentoNro.Substring(1) + ",  NFC:   " + numCupom;

                #region MOVBAN
                script = "INSERT INTO TCCMOVBAN (MOVBANDATOPER, MOVBANNROHORA, MOVBANNROMIN, MOVBANNROSEG, MOVBANIDTNAT" + 
                         ", MOVBANIDTORIG, MOVBANIDTDEST, MOVBANVLR, ESPDOCCOD, MOVBANNRODOCBAN, MOVBANDES, MOVBANIDTCONTAB" + 
                         ", USUARICOD, MOVBANNRORECPAG, MOVBANIDTSITLANCTO)" + 
                         " VALUES (" + dataOperacao.ToString("yyyyMMdd") + // MOVBANDATOPER 
                         ", " + dataOperacao.Hour + // MOVBANNROHORA
                         ", " + dataOperacao.Minute + // MOVBANNROMIN
                         ", " + dataOperacao.Second + // MOVBANNROSEG
                         ", 'C'" + // MOVBANIDTNAT (Crédito)
                         ", 'CX'" + // MOVBANIDTORIG (Caixa)
                         ", ''" + // MOVBANIDTDEST (Destino)
                         ", " + vendaSpress.MODVLR.ToString(CultureInfo.GetCultureInfo("en-GB")) + // MOVBANVLR
                         ", 'NFC'" + // ESPDOCCOD
                         ", '" + recebimentoNro + "'" + // MOVBANNROMIN
                         ", '" + MOVBANDES + "'" + // MOVBANDES
                         ", 'S'" + // MOVBANIDTCONTAB
                         ", " + USUARICOD + // USUARICOD 
                         ", " + recebinro + // MOVBANNRORECPAG
                         ", '')"; // MOVBANIDTSITLANCTO

                command = new FbCommand(script, conn);
                command.Transaction = transaction;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Movimentação Bancária da venda " + vendaSpress.TIPO + " receb " + recebinro + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                }
                #endregion

                #region MOVBCX
                script = "INSERT INTO TCCMOVBCX (MOVBCXCODBANCO, MOVBCXCODAGECAIX, MOVBCXCODCONEXPMO, MOVBANDATOPER" +
                         ", MOVBANNROHORA, MOVBANNROMIN, MOVBANNROSEG, OPEMOVIDTNAT, OPEMOVIDTORIG, MOVBANIDTCONCILIA)" +
                         " VALUES (" + vendaSpress.MODCODBANORI + // MOVBCXCODBANCO
                         ", " + vendaSpress.MODCODAGEORI + // MOVBCXCODCONEXPMO 
                         ", '" + vendaSpress.MODCODCONORI + "'" + // MOVBCXCODCONEXPMO
                         ", " + dataOperacao.ToString("yyyyMMdd") + // MOVBANDATOPER 
                         ", " + dataOperacao.Hour + // MOVBANNROHORA
                         ", " + dataOperacao.Minute + // MOVBANNROMIN
                         ", " + dataOperacao.Second + // MOVBANNROSEG
                         ", 'C'" + // OPEMOVIDTNAT (Crédito)
                         ", 'CX'" + // OPEMOVIDTORIG (Caixa)
                         ", 'N')"; // MOVBANIDTCONCILIA (Destino)

                command = new FbCommand(script, conn);
                command.Transaction = transaction;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Movimentação Bancária X da venda " + vendaSpress.TIPO + " receb " + recebinro + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                }
                #endregion

                #region CAxTRA
                if (vendaSpress.TIPO == 'C')
                {
                    script = "INSERT INTO TCCCACTRA (CACADMCOD, EXPMONCOD, RECEBINRO, CACMODDATREGISTRO" +
                             ", CACMODSEQ, CACMOVSEQ, MOVBANDATOPER, MOVBANNROHORA, MOVBANNROMIN, MOVBANNROSEG)";
                }
                else
                {
                    script = "INSERT INTO TCCCABTRA (CABADMCOD, EXPMONCOD, RECEBINRO, CABMODDATREGISTRO" +
                             ", CABMODSEQ, CABMOVSEQ, MOVBANDATOPER, MOVBANNROHORA, MOVBANNROMIN, MOVBANNROSEG)";
                }
                script += " VALUES (" + vendaSpress.ADMCOD +  // ADMCOD
                             ", '" + vendaSpress.EXPMONCOD + "'" +  // EXPMONCOD
                             ", " + recebinro +  // RECEBINRO
                             ", " + vendaSpress.MODDATREGISTRO + // MODDATREGISTRO
                             ", " + vendaSpress.MODSEQ +  // CACMODSEQ
                             ", 1" + // CACMOVSEQ
                             ", " + dataOperacao.ToString("yyyyMMdd") + // MOVBANDATOPER
                             ", " + dataOperacao.Hour + // MOVBANNROHORA
                             ", " + dataOperacao.Minute + // MOVBANNROMIN
                             ", " + dataOperacao.Second + // MOVBANNROSEG
                             ")"; 

                command = new FbCommand(script, conn);
                command.Transaction = transaction;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("CAxTRA da venda " + vendaSpress.TIPO + " receb " + recebinro + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                }
                #endregion

                string contaCartao = "112020001";
                string contaTaxaAdministracao = "331160034";
                string contaTransitoriaVendas = "161010002";

                int millisecond = 17;
                string LANDIAHORLANCAM = dataOperacao.ToString("HHmmss") + millisecond;

                #region LANDIA

                #region CONTA CARTÃO - DÉBITO
                script = "INSERT INTO TGLLANDIA (FILIALCOD, LANDIADATLANCAM, LANDIAHORLANCAM, SISTEMCOD" +
                         ", TIPOPECOD, LANDIADESDOCTO, LANDIAIDTDEBCRE, PLACONCODEXP, CENCUSCODEXP" +
                         ", LANDIADESHISTORICO, HISPADCOD, LANDIAVLRLANCAM)" +
                         " VALUES (" + vendaSpress.MODCODAGEORI + // FILIALCOD
                         ", " + dataOperacao.ToString("yyyyMMdd") + // LANDIADATLANCAM
                         ", " + LANDIAHORLANCAM + // LANDIAHORLANCAM
                         ", 39" + // SISTEMCOD (módulo de tesouraria)
                         ", 0" + // TIPOPECOD
                         ", ''" + // LANDIADESDOCTO
                         ", 'D'" + // LANDIAIDTDEBCRE (Crédito)
                         ", '" + contaCartao + "'" + // PLACONCODEXP (Caixa)
                         ", ''" + // CENCUSCODEXP (sem custo)
                         ", '" + MOVBANDES + "'" + // LANDIADESHISTORICO
                         ", 999" + // HISPADCOD
                         ", " + vendaSpress.MODVLR.ToString(CultureInfo.GetCultureInfo("en-GB")) + // LANDIAVLRLANCAM
                         ")";

                command = new FbCommand(script, conn);
                command.Transaction = transaction;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Lançamento contábil de débito na conta de cartão de crédito da venda " + vendaSpress.TIPO + " receb " + recebinro + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                }
                #endregion

                millisecond += 10;
                LANDIAHORLANCAM = dataOperacao.ToString("HHmmss") + millisecond;

                #region CONTA CARTÃO - CRÉDITO
                script = "INSERT INTO TGLLANDIA (FILIALCOD, LANDIADATLANCAM, LANDIAHORLANCAM, SISTEMCOD" + 
                         ", TIPOPECOD, LANDIADESDOCTO, LANDIAIDTDEBCRE, PLACONCODEXP, CENCUSCODEXP" + 
                         ", LANDIADESHISTORICO, HISPADCOD, LANDIAVLRLANCAM)" +
                         " VALUES (" + vendaSpress.MODCODAGEORI + // FILIALCOD
                         ", " + dataOperacao.ToString("yyyyMMdd") + // LANDIADATLANCAM
                         ", " + LANDIAHORLANCAM + // LANDIAHORLANCAM
                         ", 39" + // SISTEMCOD (módulo de tesouraria)
                         ", 0" + // TIPOPECOD
                         ", ''" + // LANDIADESDOCTO
                         ", 'C'" + // LANDIAIDTDEBCRE (Crédito)
                         ", '" + contaCartao + "'" + // PLACONCODEXP (Caixa)
                         ", ''" + // CENCUSCODEXP (sem custo)
                         ", '" + MOVBANDES + "'" + // LANDIADESHISTORICO
                         ", 999" + // HISPADCOD
                         ", " + vendaSpress.MODVLRTXFHIST.ToString(CultureInfo.GetCultureInfo("en-GB")) + // LANDIAVLRLANCAM
                         ")"; 

                command = new FbCommand(script, conn);
                command.Transaction = transaction;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Lançamento contábil de crédito na conta de cartão de crédito da venda " + vendaSpress.TIPO + " receb " + recebinro + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                }
                #endregion

                millisecond += 10;
                LANDIAHORLANCAM = dataOperacao.ToString("HHmmss") + millisecond;

                #region CONTA TAXA ADMINISTRAÇÃO - DÉBITO
                script = "INSERT INTO TGLLANDIA (FILIALCOD, LANDIADATLANCAM, LANDIAHORLANCAM, SISTEMCOD" +
                         ", TIPOPECOD, LANDIADESDOCTO, LANDIAIDTDEBCRE, PLACONCODEXP, CENCUSCODEXP" +
                         ", LANDIADESHISTORICO, HISPADCOD, LANDIAVLRLANCAM)" +
                         " VALUES (" + vendaSpress.MODCODAGEORI + // FILIALCOD
                         ", " + dataOperacao.ToString("yyyyMMdd") + // LANDIADATLANCAM
                         ", " + LANDIAHORLANCAM + // LANDIAHORLANCAM
                         ", 39" + // SISTEMCOD (módulo de tesouraria)
                         ", 0" + // TIPOPECOD
                         ", ''" + // LANDIADESDOCTO
                         ", 'D'" + // LANDIAIDTDEBCRE (Crédito)
                         ", '" + contaTaxaAdministracao + "'" + // PLACONCODEXP (Caixa)
                         ", ''" + // CENCUSCODEXP (sem custo)
                         ", '" + MOVBANDES + "'" + // LANDIADESHISTORICO
                         ", 999" + // HISPADCOD
                         ", " + vendaSpress.MODVLRTXFHIST.ToString(CultureInfo.GetCultureInfo("en-GB")) + // LANDIAVLRLANCAM
                         ")";

                command = new FbCommand(script, conn);
                command.Transaction = transaction;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Lançamento contábil de débito na conta de taxas da venda " + vendaSpress.TIPO + " receb " + recebinro + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                }
                #endregion

                millisecond += 10;
                LANDIAHORLANCAM = dataOperacao.ToString("HHmmss") + millisecond;

                #region CONTA TRANSITÓRIA DE VENDAS - CRÉDITO
                script = "INSERT INTO TGLLANDIA (FILIALCOD, LANDIADATLANCAM, LANDIAHORLANCAM, SISTEMCOD" +
                         ", TIPOPECOD, LANDIADESDOCTO, LANDIAIDTDEBCRE, PLACONCODEXP, CENCUSCODEXP" +
                         ", LANDIADESHISTORICO, HISPADCOD, LANDIAVLRLANCAM)" +
                         " VALUES (" + vendaSpress.MODCODAGEORI + // FILIALCOD
                         ", " + dataOperacao.ToString("yyyyMMdd") + // LANDIADATLANCAM
                         ", " + LANDIAHORLANCAM + // LANDIAHORLANCAM
                         ", 39" + // SISTEMCOD (módulo de tesouraria)
                         ", 0" + // TIPOPECOD
                         ", ''" + // LANDIADESDOCTO
                         ", 'C'" + // LANDIAIDTDEBCRE (Crédito)
                         ", '" + contaTransitoriaVendas + "'" + // PLACONCODEXP (Conta)
                         ", ''" + // CENCUSCODEXP (sem custo)
                         ", '" + MOVBANDES + "'" + // LANDIADESHISTORICO
                         ", 999" + // HISPADCOD
                         ", " + vendaSpress.MODVLR.ToString(CultureInfo.GetCultureInfo("en-GB")) + // LANDIAVLRLANCAM
                         ")";

                command = new FbCommand(script, conn);
                command.Transaction = transaction;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Lançamento contábil de crédito na conta transitória da venda " + vendaSpress.TIPO + " receb " + recebinro + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                }
                #endregion

                #endregion

                transaction.Commit();

                // Atualiza recebinro
                vendaSpress.RECEBINRO = recebinro;

                // Obtém o K0
                if (vendaSpress.TIPO == 'C')
                {
                    script = "SELECT K0" + 
                             " FROM TCCCACMOD" +
                             " WHERE CACADMCOD = " + vendaSpress.ADMCOD + 
                             " AND EXPMONCOD = '" + vendaSpress.EXPMONCOD + "'" + 
                             " AND RECEBINRO = " + vendaSpress.RECEBINRO + 
                             " AND CACMODDATREGISTRO = " + vendaSpress.MODDATREGISTRO + 
                             " AND CACMODSEQ = " + vendaSpress.MODSEQ;
                }
                else
                {
                    script = "SELECT K0" +
                             " FROM TCCCABMOD" +
                             " WHERE CABADMCOD = " + vendaSpress.ADMCOD +
                             " AND EXPMONCOD = '" + vendaSpress.EXPMONCOD + "'" +
                             " AND RECEBINRO = " + vendaSpress.RECEBINRO +
                             " AND CABMODDATREGISTRO = " + vendaSpress.MODDATREGISTRO +
                             " AND CABMODSEQ = " + vendaSpress.MODSEQ;
                }
                command = new FbCommand(script, conn);
                using (FbDataReader dr = command.ExecuteReader())
                {
                    if (!dr.Read())
                        throw new Exception("Falha de comunicação com o servidor do Cliente!");
                    vendaSpress.K0 = Convert.ToString(dr["K0"]);                
                }
            }
            catch(Exception e)
            {
                transaction.Rollback();
                throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
            }
        }
    }
}