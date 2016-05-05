using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using WebApiSpress.Bibliotecas;
using WebApiSpress.Models.Object;
using WebApiSpress.Models.Sql;

namespace WebApiSpress.Negocios.Firebird
{
    public class GatewayCorrigeVendas
    {
        /// <summary>
        /// Auto Loader
        /// </summary>
        public GatewayCorrigeVendas() { }

        public static void CorrigeVendas(string token, CorrigeVendaERP param, painel_taxservices_dbContext _dbAtosContext = null)//, AlphaContext _dbAlphaContext = null)
        {
            if (param == null || param.idsRecebimento == null)
                throw new Exception("Parâmetro inválido!");

            if (param.idsRecebimento.Count == 0)
                return;

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

                // Pesquisa as vendas
                string script = "SELECT R.id AS R_id" +
                                ", R.dtaVenda AS R_dtVenda" +
                                ", R.nsu AS R_nsu" +
                                ", B.cdAdquirente AS R_cdAdquirente" +
                                ", R.cdSacado AS R_cdSacado" +
                                ", R.valorVendaBruta AS R_vlVenda" +
                                ", R.cnpj AS R_cnpj" +
                                ", R.numParcelaTotal AS R_qtParcelas" +
                                ", V.idRecebimentoVenda AS V_id" +
                                ", V.cdAdquirente AS V_cdAdquirente" +
                                ", V.dtVenda AS V_dtVenda" +
                                ", V.nrNSU AS V_nsu" +
                                ", V.cdSacado AS V_cdSacado" +
                                ", V.vlVenda AS V_vlVenda" +
                                ", V.nrCNPJ AS V_cnpj" +
                                ", V.qtParcelas AS V_qtParcelas" +
                                ", V.cdERP AS V_cdERP" +
                                " FROM pos.Recebimento R (NOLOCK)" +
                                " JOIN cliente.empresa E (NOLOCK) ON E.nu_cnpj = R.cnpj" +
                                " JOIN card.tbBandeira B (NOLOCK) ON B.cdBandeira = R.cdBandeira" +
                                " JOIN card.tbRecebimentoVenda V (NOLOCK) ON V.idRecebimentoVenda = R.idRecebimentoVenda" +
                                //" LEFT JOIN card.tbBandeiraSacado BS on BS.cdGrupo = E.id_grupo and BS.cdBandeira = R.cdBandeira" +
                                " WHERE R.id IN (" + string.Join(", ", param.idsRecebimento) + ")";

                List<VendasCorrecaoSpress> Collection = new List<VendasCorrecaoSpress>();

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["painel_taxservices_dbContext"].ConnectionString);
                try
                {
                    connection.Open();
                }
                catch
                {
                    throw new Exception("Não foi possível estabelecer conexão com a base de dados da Atos");
                }

                try
                {
                    SqlCommand cmd = new SqlCommand(script, connection);
                    cmd.CommandTimeout = 60; // 1 minuto

                    List<IDataRecord> queryResult = new List<IDataRecord>();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Collection = reader.Cast<IDataRecord>().Select(r => new VendasCorrecaoSpress
                        {
                            R_cdSacado = r["R_cdSacado"].Equals(DBNull.Value) ? null : Convert.ToString(r["R_cdSacado"]),
                            R_cdAdquirente = Convert.ToInt32(r["R_cdAdquirente"]),
                            R_codResumoVenda = r["R_codResumoVenda"].Equals(DBNull.Value) ? null : Convert.ToString(r["R_codResumoVenda"]),
                            R_cnpj = Convert.ToString(r["R_cnpj"]),
                            R_dtVenda = (DateTime)r["R_dtVenda"],
                            R_id = Convert.ToInt32(r["R_id"]),
                            R_nsu = Convert.ToString(r["R_nsu"]),
                            R_qtParcelas = r["R_qtParcelas"].Equals(DBNull.Value) ? 1 : Convert.ToInt32(r["R_qtParcelas"]),
                            R_vlVenda = Convert.ToDecimal(r["R_vlVenda"]),
                            V_cdSacado = r["V_cdSacado"].Equals(DBNull.Value) ? null : Convert.ToString(r["V_cdSacado"]),
                            V_cdERP = Convert.ToString(r["V_cdERP"]), // obrigatório
                            V_cdAdquirente = r["V_cdAdquirente"].Equals(DBNull.Value) ? (int?)null : Convert.ToInt32(r["V_cdAdquirente"]),
                            V_cnpj = Convert.ToString(r["V_cnpj"]),
                            V_dtVenda = (DateTime)r["V_dtVenda"],
                            V_id = Convert.ToInt32(r["V_id"]),
                            V_nsu = Convert.ToString(r["V_nsu"]),
                            V_qtParcelas = r["V_qtParcelas"].Equals(DBNull.Value) ? 1 : Convert.ToInt32(r["V_qtParcelas"]),
                            V_vlVenda = Convert.ToDecimal(r["V_vlVenda"]),
                        }).ToList<VendasCorrecaoSpress>();
                    }
                }
                catch
                {
                    throw new Exception("Falha de comunicação com servidor (Atos)");
                }
                finally
                {
                    try
                    {
                        connection.Close();
                    }
                    catch { }
                }

                FbConnection conn = new FbConnection(connstring);

                FbCommand command;

                try
                {
                    conn.Open();
                }
                catch
                {
                    throw new Exception("Falha de comunicação com o servidor do Cliente");
                }

                try
                {
                    for (int k = 0; k < Collection.Count; k++)
                    {
                        FbTransaction transaction = conn.BeginTransaction();

                        VendasCorrecaoSpress venda = Collection[k];
                        /*
                         *  - Tudo que tiver o prefixo R_ => pos.Recebimento
                         *  - Tudo que tiver o prefixo V_ => card.tbRecebimentoVenda
                         */
                        string K0 = venda.V_cdERP;
                        string nsu = venda.V_nsu;
                        if (venda.V_nsu.StartsWith("T"))
                            nsu = null;
                        string nsuAtualizada = venda.R_nsu;

                        //string codResumoVenda
                        // CACRESNRO

                        string EXPMONCOD = venda.R_cdSacado == null || venda.V_cdAdquirente == null ? null : venda.R_cdSacado;
                        
                        bool atualizaNsu = venda.R_cdAdquirente != 5 && venda.R_cdAdquirente != 6 && venda.R_cdAdquirente != 11 && venda.R_cdAdquirente != 14;
                        string dsMensagem = null;
                        bool vendaCredito = true;
                        try
                        {
                            // BUSCA A VENDA NA TABELA DE VENDAS À CRÉDITO
                            script = "SELECT VC.RECEBINRO" +
                                     " FROM TCCCACMOD VC" +
                                     " WHERE VC.K0 = '" + K0 + "'";
                            command = new FbCommand(script, conn);
                            command.Transaction = transaction;

                            using (FbDataReader dr = command.ExecuteReader())
                            {
                                vendaCredito = dr.Read();
                            }

                            if (!vendaCredito)
                            {
                                // Verifica se de fato existe na tabela de vendas à débito
                                script = "SELECT VD.RECEBINRO" +
                                     " FROM TCCCABMOD VD" +
                                     " WHERE VD.K0 = '" + K0 + "'";
                                command = new FbCommand(script, conn);
                                command.Transaction = transaction;

                                using (FbDataReader dr = command.ExecuteReader())
                                {
                                    if (!dr.Read())
                                    {
                                        // VENDA NÃO EXISTE!

                                        // Deleta do portal?
                                        // ...

                                        continue; 
                                    }
                                }
                            }


                            #region ATUALIZAR QUANTIDADE DE PARCELAS E VALOR DA VENDA
                            if (vendaCredito)
                            {
                                script = "UPDATE TCCCACMOD" +
                                         " SET CACMODVLR = " + venda.R_vlVenda.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                         ", CACMODNROPARCELAS = " + venda.R_qtParcelas +
                                         (atualizaNsu ? ", CACMODNROCARTAO = '" + venda.R_nsu + "'" : "") + 
                                         " WHERE K0 = '" + K0 + "'";
                            }
                            else
                            {
                                if (nsuAtualizada.Length > 6)
                                    nsuAtualizada = nsuAtualizada.Substring(nsuAtualizada.Length - 6);

                                script = "UPDATE TCCCABMOD" +
                                         " SET CABMODVLR = " + venda.R_vlVenda.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                         ", CABMODNROPARCELAS = " + venda.R_qtParcelas +
                                         (atualizaNsu ? ", CABMODNROCARTAO = " + nsuAtualizada : "") +
                                         " WHERE K0 = '" + K0 + "'";
                            }
                            
                            command = new FbCommand(script, conn);
                            command.Transaction = transaction;

                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                                throw new Exception("Venda '" + K0 + "' " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                            }
                            #endregion

                            // Avalia se tem títulos gerados para a venda
                            bool temTitulosGerados = false;
                            if (vendaCredito)
                            {
                                script = "SELECT PC.K0" +
                                         " FROM TCCCACPAR PC" +
                                         " JOIN TCCCACMOD VC ON PC.RECEBINRO = VC.RECEBINRO" +
                                                           " AND PC.EXPMONCOD = VC.EXPMONCOD" +
                                                           " AND PC.CACADMCOD = VC.CACADMCOD" +
                                                           " AND PC.CACMODDATREGISTRO = VC.CACMODDATREGISTRO" +
                                                           " AND PC.CACMODSEQ = VC.CACMODSEQ" +
                                         " WHERE VC.K0 = '" + K0 + "'";
                            }
                            else
                            {
                                script = "SELECT PD.K0" +
                                         " FROM TCCCABPAR PD" +
                                         " JOIN TCCCABMOD VD ON PD.RECEBINRO = VD.RECEBINRO" +
                                                           " AND PD.EXPMONCOD = VD.EXPMONCOD" +
                                                           " AND PD.CABADMCOD = VD.CABADMCOD" +
                                                           " AND PD.CABMODDATREGISTRO = VD.CABMODDATREGISTRO" +
                                                           " AND PD.CABMODSEQ = VD.CABMODSEQ" +
                                         " WHERE VD.K0 = '" + K0 + "'";
                            }
                            // Procura parcela no sistema
                            command = new FbCommand(script, conn);
                            command.Transaction = transaction;

                            using (FbDataReader dr = command.ExecuteReader())
                            {
                                temTitulosGerados = dr.Read();
                            }

                            if (temTitulosGerados)
                            {
                                #region TRATA PARCELAS
                                // Consulta parcelas da venda
                                script = "SELECT *" +
                                         " FROM pos.RecebimentoParcela P (NOLOCK)" +
                                         " WHERE P.idRecebimento = " + venda.R_id +
                                         " ORDER BY P.numParcela";
                                RecebimentoParcela[] rps;
                                try
                                {
                                    rps = _dbAtos.Database.SqlQuery<RecebimentoParcela>(script).ToArray();
                                }
                                catch
                                {
                                    throw new Exception("Falha de comunicação com o servidor (Atos - Parcelas)");
                                }

                                int incremento = venda.R_qtParcelas > 1 ? 1 : 0;
                                for (int n = 0; n < venda.R_qtParcelas; n++)
                                {
                                    int numParcela = n + incremento;

                                    RecebimentoParcela rp = rps.Where(t => t.numParcela == numParcela).FirstOrDefault();

                                    string PK0 = string.Empty;

                                    if (vendaCredito)
                                    {
                                        script = "SELECT PC.K0" +
                                                 " FROM TCCCACPAR PC" +
                                                 " JOIN TCCCACMOD VC ON PC.RECEBINRO = VC.RECEBINRO" +
                                                                   " AND PC.EXPMONCOD = VC.EXPMONCOD" +
                                                                   " AND PC.CACADMCOD = VC.CACADMCOD" +
                                                                   " AND PC.CACMODDATREGISTRO = VC.CACMODDATREGISTRO" +
                                                                   " AND PC.CACMODSEQ = VC.CACMODSEQ" +
                                                 " WHERE VC.K0 = '" + K0 + "'" +
                                                 " AND PC.CACPARNRO IN (" + (venda.R_qtParcelas > 1 ? numParcela.ToString() : "0, 1") + ")";
                                    }
                                    else
                                    {
                                        script = "SELECT PD.K0" +
                                                 " FROM TCCCABPAR PD" +
                                                 " JOIN TCCCABMOD VD ON PD.RECEBINRO = VD.RECEBINRO" +
                                                                   " AND PD.EXPMONCOD = VD.EXPMONCOD" +
                                                                   " AND PD.CABADMCOD = VD.CABADMCOD" +
                                                                   " AND PD.CABMODDATREGISTRO = VD.CABMODDATREGISTRO" +
                                                                   " AND PD.CABMODSEQ = VD.CABMODSEQ" +
                                                 " WHERE VD.K0 = '" + K0 + "'" +
                                                 " AND PD.CABPARNRO IN (" + (venda.R_qtParcelas > 1 ? numParcela.ToString() : "0, 1") + ")";
                                    }
                                    // Procura parcela no sistema
                                    command = new FbCommand(script, conn);
                                    command.Transaction = transaction;

                                    using (FbDataReader dr = command.ExecuteReader())
                                    {
                                        if (dr.Read())
                                        {
                                            PK0 = Convert.ToString(dr["K0"]);
                                        }
                                    }

                                    // Existe a parcela?
                                    if (!PK0.Trim().Equals(""))
                                    {
                                        // SÓ ATUALIZA SE TIVER PARCELA NO CARD SERVICES
                                        if (rp != null)
                                        {
                                            if (vendaCredito)
                                            {
                                                script = "UPDATE TCCCACPAR" +
                                                         " SET CACPARVLR = " + rp.valorParcelaBruta.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                         ", CACPARDATVENCTO = " + DatabaseQueries.GetIntDate(rp.dtaRecebimento) +
                                                         " WHERE K0 = '" + PK0 + "'";
                                            }
                                            else
                                            {
                                                script = "UPDATE TCCCABPAR" +
                                                         " SET CABPARVLR = " + rp.valorParcelaBruta.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                         ", CABPARDATVENCTO = " + DatabaseQueries.GetIntDate(rp.dtaRecebimento) +
                                                         " WHERE K0 = '" + PK0 + "'";
                                            }
                                            command = new FbCommand(script, conn);
                                            command.Transaction = transaction;

                                            try
                                            {
                                                command.ExecuteNonQuery();
                                            }
                                            catch (Exception e)
                                            {
                                                throw new Exception("Parcela '" + PK0 + "'. " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                                            }
                                        }
                                    }
                                    else// if (rp != null)
                                    {
                                        // INSERT!
                                        if (dsMensagem == null) dsMensagem = "";
                                        else dsMensagem += Environment.NewLine + Environment.NewLine;
                                        dsMensagem += "É necessário inserir a parcela " + numParcela;
                                    }
                                }

                                // Deletar duplicatas indevidas
                                if (venda.R_qtParcelas > 1)
                                {
                                    #region DELETA TÍTULOS
                                    // Busca os pagamentos a serem deletados
                                    if (vendaCredito)
                                    {
                                        script = "SELECT PC.K0" +
                                                 " FROM TCCCACPAR PC" +
                                                 " JOIN TCCCACMOD VC ON PC.RECEBINRO = VC.RECEBINRO" +
                                                                   " AND PC.EXPMONCOD = VC.EXPMONCOD" +
                                                                   " AND PC.CACADMCOD = VC.CACADMCOD" +
                                                                   " AND PC.CACMODDATREGISTRO = VC.CACMODDATREGISTRO" +
                                                                   " AND PC.CACMODSEQ = VC.CACMODSEQ" +
                                                 " WHERE VC.K0 = '" + K0 + "'" +
                                                 " AND PC.CACPARNRO > " + venda.R_qtParcelas;
                                    }
                                    else
                                    {
                                        script = "SELECT PD.K0" +
                                                 " FROM TCCCABPAR PD" +
                                                 " JOIN TCCCABMOD VD ON PD.RECEBINRO = VD.RECEBINRO" +
                                                                   " AND PD.EXPMONCOD = VD.EXPMONCOD" +
                                                                   " AND PD.CABADMCOD = VD.CABADMCOD" +
                                                                   " AND PD.CABMODDATREGISTRO = VD.CABMODDATREGISTRO" +
                                                                   " AND PD.CABMODSEQ = VD.CABMODSEQ" +
                                                 " WHERE VD.K0 = '" + K0 + "'" +
                                                 " AND PD.CABPARNRO > " + venda.R_qtParcelas;
                                    }

                                    command = new FbCommand(script, conn);
                                    command.Transaction = transaction;

                                    List<string> parcelas = new List<string>();
                                    using (FbDataReader dr = command.ExecuteReader())
                                    {
                                        while (dr.Read())
                                        {
                                            parcelas.Add(Convert.ToString(dr["K0"]));
                                        }
                                    }

                                    if (parcelas.Count > 0)
                                    {
                                        // REMOVE AS PARCELAS INDEVIDAS
                                        if (vendaCredito)
                                        {
                                            script = "DELETE TCCCACPAR" +
                                                     " WHERE K0 IN ('" + string.Join("', '", parcelas) + "')";
                                        }
                                        else
                                        {
                                            script = "DELETE TCCCABPAR" +
                                                     " WHERE K0 IN ('" + string.Join("', '", parcelas) + "')";
                                        }

                                        // DELETA DUPLICATAS
                                        command = new FbCommand(script, conn);
                                        command.Transaction = transaction;
                                        try
                                        {
                                            command.ExecuteNonQuery();
                                        }
                                        catch (Exception e)
                                        {
                                            throw new Exception("Parcelas indevidas da venda '" + K0 + "'. " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                                        }
                                    }
                                    #endregion
                                }
                                #endregion
                            }

                            // Avalia se sacado deve ser alterado
                            if (EXPMONCOD != null && venda.V_cdSacado != null && !EXPMONCOD.Equals(venda.V_cdSacado))
                            {
                                if (dsMensagem == null) dsMensagem = "";
                                else dsMensagem += Environment.NewLine + Environment.NewLine;
                                dsMensagem += "É necessário alterar o sacado [" + venda.V_cdSacado + "] para [" + EXPMONCOD + "]";
                                #region ALTERA SACADO
                                /*bool novoSacadoCredito = false;
                                int MCOD = 0;
                                // Busca se o sacado é de vendas à crédito
                                script = "SELECT EC.CACADMCOD from TFICACADE EC WHERE EC.EXPMONCOD LIKE '" + EXPMONCOD + "%'";
                                command = new FbCommand(script, conn);
                                command.Transaction = transaction;

                                using (FbDataReader dr = command.ExecuteReader())
                                {
                                    while (dr.Read())
                                    {
                                        novoSacadoCredito = true;
                                        MCOD = Convert.ToInt32(dr["CACADMCOD"]);
                                    }
                                }

                                if (!novoSacadoCredito)
                                {
                                    // Busca se o sacado é de vendas à crédito
                                    script = "SELECT ED.CABADMCOD from TFICABADE ED WHERE ED.EXPMONCOD LIKE '" + EXPMONCOD + "%'";
                                    command = new FbCommand(script, conn);
                                    command.Transaction = transaction;

                                    using (FbDataReader dr = command.ExecuteReader())
                                    {
                                        while (dr.Read())
                                        {
                                            MCOD = Convert.ToInt32(dr["CABADMCOD"]);
                                        }
                                    }
                                }


                                if (MCOD != 0)
                                {
                                    if (vendaCredito == novoSacadoCredito)
                                    {
                                        // Obtém os campos antigos
                                        if (vendaCredito)
                                        {
                                            script = "SELECT VC.RECEBINRO AS RECEBINRO" +
                                                     ", VC.CACMODDATREGISTRO AS MODDATREGISTRO" +
                                                     ", VC.CACMODSEQ AS MODSEQ" +
                                                     ", VC.CACMOVSEQ AS MOVSEQ" +
                                                     " FROM TCCCACMOD VC" +
                                                     " WHERE VC.K0 = '" + K0 + "'";
                                        }
                                        else
                                        {
                                            script = "SELECT VD.RECEBINRO AS RECEBINRO" +
                                                     ", VD.CABMODDATREGISTRO AS MODDATREGISTRO" +
                                                     ", VD.CABMODSEQ AS MODSEQ" +
                                                     ", VD.CABMOVSEQ AS MOVSEQ" +
                                                     " FROM TCCCABMOD VD" +
                                                     " WHERE VC.K0 = '" + K0 + "'";
                                        }

                                        command = new FbCommand(script, conn);
                                        command.Transaction = transaction;

                                        int RECEBINRO = 0, MODDATREGISTRO = 0, MODSEQ = 0, MOVSEQ = 0;
                                        using (FbDataReader dr = command.ExecuteReader())
                                        {
                                            if (dr.Read())
                                            {
                                                RECEBINRO = Convert.ToInt32(dr["RECEBINRO"]);
                                                MODDATREGISTRO = Convert.ToInt32(dr["MODDATREGISTRO"]);
                                                MODSEQ = Convert.ToInt32(dr["MODSEQ"]);
                                                MOVSEQ = Convert.ToInt32(dr["MOVSEQ"]);
                                            }
                                        }

                                        if (RECEBINRO > 0)
                                        {
                                            // Atualiza

                                        }
                                        else
                                        {
                                            // Marca o flag
                                            precisaInserir = true;
                                        }
                                    }
                                    else
                                    {
                                        // marca o flag => teria que tirar de uma tabela e inserir em outra
                                        precisaInserir = true;
                                    }
                                }
                                */
                                #endregion
                            }


                            // temp
                            //transaction.Rollback();

                            transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
                        }


                        // Atualizar tabela tbRecebimentoVenda
                        // NÃO ALTERA NSU (momentaneamente => Tem adquirentes que não fornecem a NSU - caso da Getnet, Policard e Valecard)
                        script = "UPDATE V" +
                                 " SET V.qtParcelas = " + venda.R_qtParcelas +
                                 ", V.vlVenda = " + venda.R_vlVenda.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                 ", V.dsMensagem = " + (dsMensagem == null ? "NULL" : "'" + dsMensagem + "'") +
                                 (atualizaNsu ? ", V.nrNSU = '" + nsuAtualizada + "'" : "") +
                                 ", V.dtAjuste = getdate()" +
                                 " FROM card.tbRecebimentoVenda V" +
                                 " WHERE V.idRecebimentoVenda = " + venda.V_id;
                        try
                        {
                            _dbAtos.Database.ExecuteSqlCommand(script);
                        }
                        catch
                        {
                            throw new Exception("Falha de comunicação com o servidor (Atos - Venda)");
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