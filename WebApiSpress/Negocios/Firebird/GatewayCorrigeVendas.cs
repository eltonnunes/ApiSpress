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
                                ", R.codResumoVenda AS R_codResumoVenda" +
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

                        string codResumoVenda = venda.R_codResumoVenda;
                        if(codResumoVenda != null && codResumoVenda.Length > 9)
                            codResumoVenda = codResumoVenda.Substring(codResumoVenda.Length - 9);

                        string EXPMONCOD = venda.R_cdSacado == null || venda.V_cdAdquirente == null ? null : venda.R_cdSacado;
                        
                        bool atualizaNsu = venda.R_cdAdquirente != 5 && venda.R_cdAdquirente != 6 && venda.R_cdAdquirente != 11 && venda.R_cdAdquirente != 14;
                        string dsMensagem = null;

                        VendaSpress vendaSpress = null;
                        try
                        {
                            #region BUSCA A VENDA NAS TABELA DE VENDAS

                            // Busca primeiro na tabela de vendas à crédito
                            script = "SELECT RECEBINRO, CACADMCOD, EXPMONCOD, CACMODDATREGISTRO, CACMODSEQ, CACMODNROPARCELAS" +
                                    ", CACMODCODBANATU,	CACMODCODAGEATU, CACMODCODCONATU, CACMODNROCARTAO, CACRESNRO, CACMODIDTSITUACAO" +
                                     " FROM TCCCACMOD" +
                                     " WHERE K0 = '" + K0 + "'";
                            command = new FbCommand(script, conn);
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
                                        PARCODBANATU = Convert.ToInt32(dr["CACMODCODBANATU"]),
                                        PARCODAGEATU = Convert.ToInt32(dr["CACMODCODAGEATU"]),
                                        PARNROCONATU = Convert.ToString(dr["CACMODCODCONATU"]),
                                        MODNROCARTAO = Convert.ToString(dr["CACMODNROCARTAO"]),
                                        K0 = K0,
                                        MODIDTSITUACAO = Convert.ToString(dr["CACMODIDTSITUACAO"]),
                                    };
                                }
                            }

                            if (vendaSpress == null)
                            {
                                // Verifica se existe na tabela de vendas à débito
                                script = "SELECT RECEBINRO, CABADMCOD, EXPMONCOD, CABMODDATREGISTRO, CABMODSEQ, CABMODNROPARCELAS" +
                                    ", CABMODCODBANATU,	CABMODCODAGEATU, CABMODCODCONATU, CABMODNROCARTAO, CABRESNRO, CABMODIDTSITUACAO" +
                                     " FROM TCCCABMOD" +
                                     " WHERE K0 = '" + K0 + "'";
                                command = new FbCommand(script, conn);
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
                                            PARCODBANATU = Convert.ToInt32(dr["CABMODCODBANATU"]),
                                            PARCODAGEATU = Convert.ToInt32(dr["CABMODCODAGEATU"]),
                                            PARNROCONATU = Convert.ToString(dr["CABMODCODCONATU"]),
                                            MODNROCARTAO = Convert.ToString(/*Convert.ToInt32(*/dr["CABMODNROCARTAO"]),//),
                                            K0 = K0,
                                            MODIDTSITUACAO = Convert.ToString(dr["CABMODIDTSITUACAO"]),
                                        };
                                    }
                                }
                            }
                            #endregion

                            // Venda foi encontrada?
                            if (vendaSpress == null)
                            {
                                dsMensagem = "Venda não encontrada no sistema do cliente";
                            }
                            else
                            {
                                if(vendaSpress.MODIDTSITUACAO != "AB")
                                {
                                    dsMensagem = "A venda não pode ser corrigida pois seus status não está commo aberto";
                                    // Não faz mais nada de correção
                                    vendaSpress = null;
                                }
                                // Avalia se sacado deve ser alterado
                                else if (EXPMONCOD != null && venda.V_cdSacado != null && !EXPMONCOD.Equals(venda.V_cdSacado))
                                {
                                    dsMensagem = "É necessário alterar o sacado [" + venda.V_cdSacado + "] para [" + EXPMONCOD + "]";
                                    // Não faz mais nada de correção
                                    vendaSpress = null;
                                }
                                else
                                {
                                    #region CORRIGE A VENDA
                                    #region ATUALIZAR QUANTIDADE DE PARCELAS E VALOR DA VENDA
                                    if (vendaSpress.TIPO == 'C')
                                    {
                                        script = "UPDATE TCCCACMOD" +
                                                 " SET CACMODVLR = " + venda.R_vlVenda.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                 ", CACMODNROPARCELAS = " + venda.R_qtParcelas +
                                                 ", CACMODIDTFORMA = '" + (venda.R_qtParcelas == 1 ? "RO" : "PS") + "'" + // forma da venda parcelada (rotativo/parcelado)
                                                 (atualizaNsu ? ", CACMODNROCARTAO = '" + nsuAtualizada + "'" : "") +
                                                 (codResumoVenda != null ? ", CACRESNRO = " + codResumoVenda : "") +
                                                 " WHERE K0 = '" + K0 + "'";
                                    }
                                    else
                                    {
                                        if (nsuAtualizada.Length > 6)
                                            nsuAtualizada = nsuAtualizada.Substring(nsuAtualizada.Length - 6);

                                        script = "UPDATE TCCCABMOD" +
                                                 " SET CABMODVLR = " + venda.R_vlVenda.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                 ", CABMODNROPARCELAS = 1" + //venda.R_qtParcelas +
                                                 (atualizaNsu ? ", CABMODNROCARTAO = " + nsuAtualizada : "") +
                                                 (codResumoVenda != null ? ", CABRESNRO = " + codResumoVenda : "") +
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

                                    List<ParcelaSpress> parcelasSpress = new List<ParcelaSpress>();
                                    #region BUSCA PARCELAS NO SPRESS
                                    if (vendaSpress.TIPO == 'C')
                                    {
                                        script = "SELECT PC.K0" + 
                                                 ", PC.CACPARNRO AS PARNRO" + 
                                                 ", PC.CACPARDATVENCTO AS PARDATVENCTO" + 
                                                 ", PC.CACPARVLR AS PARVLR" +
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
                                                 ", PD.CABPARNRO AS PARNRO" + 
                                                 ", PD.CABPARDATVENCTO AS PARDATVENCTO" + 
                                                 ", PD.CABPARVLR AS PARVLR" +
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
                                        while (dr.Read())
                                        {
                                            parcelasSpress.Add(new ParcelaSpress()
                                            {
                                                K0 = Convert.ToString(dr["K0"]),
                                                PARDATVENCTO = Convert.ToInt32(dr["PARDATVENCTO"]),
                                                PARNRO = Convert.ToInt32(dr["PARNRO"]),
                                                PARVLR = Convert.ToDecimal(dr["PARVLR"])
                                            });
                                        }
                                    }
                                    #endregion

                                    RecebimentoParcela[] rps;
                                    #region BUSCA PARCELAS NO CARD SERVICES
                                    script = "SELECT *" +
                                             " FROM pos.RecebimentoParcela P (NOLOCK)" +
                                             " WHERE P.idRecebimento = " + venda.R_id +
                                             " ORDER BY P.numParcela";
                                    try
                                    {
                                        rps = _dbAtos.Database.SqlQuery<RecebimentoParcela>(script).ToArray();
                                    }
                                    catch
                                    {
                                        throw new Exception("Falha de comunicação com o servidor (Atos - Parcelas)");
                                    }
                                    #endregion

                                    
                                    decimal taxaDesconto = new decimal(0.0);
                                    decimal taxaDescontoAntiga = new decimal(0.0);
                                    #region OBTÉM TAXA DE DESCONTO
                                    if (vendaSpress.TIPO == 'C')
                                    {
                                        script = "SELECT TX.CACTXFVLRTAXROT AS TAXAROTATIVO" +
                                                 ", TX.CACTXFVLRTAXPAR AS TAXAPARCELADO" +
                                                 " FROM TCCCACTXF TX" +
                                                 " WHERE TX.CACADMCOD = " + vendaSpress.ADMCOD +
                                                 " AND TX.EXPMONCOD = '" + vendaSpress.EXPMONCOD + "'";
                                    }
                                    else
                                    {
                                        script = "SELECT TX.CABTXFVLRTAXMEN AS TAXA" +
                                                 " FROM TCCCABTXF TX" +
                                                 " WHERE TX.CABADMCOD = " + vendaSpress.ADMCOD +
                                                 " AND TX.EXPMONCOD = '" + vendaSpress.EXPMONCOD + "'";
                                    }
                                    command = new FbCommand(script, conn);
                                    command.Transaction = transaction;

                                    using (FbDataReader dr = command.ExecuteReader())
                                    {
                                        if (dr.Read())
                                        {
                                            if (vendaSpress.TIPO == 'C')
                                            {
                                                if (venda.R_qtParcelas > 1)
                                                    taxaDesconto = Convert.ToDecimal(dr["TAXAPARCELADO"]);
                                                else
                                                    taxaDesconto = Convert.ToDecimal(dr["TAXAROTATIVO"]);

                                                if (vendaSpress.MODNROPARCELAS > 1)
                                                    taxaDescontoAntiga = Convert.ToDecimal(dr["TAXAPARCELADO"]);
                                                else
                                                    taxaDescontoAntiga = Convert.ToDecimal(dr["TAXAROTATIVO"]);
                                            }
                                            else
                                            {
                                                taxaDescontoAntiga = taxaDesconto = Convert.ToDecimal(dr["TAXA"]);
                                            }
                                        }
                                    }
                                    #endregion

                                    #region TRATA PARCELAS

                                    #region ATUALIZA/INSERE TÍTULOS
                                    List<int> parcelasASeremInseridas = new List<int>();
                                    int incremento = venda.R_qtParcelas > 1 ? 1 : 0;
                                    for (int n = 0; n < venda.R_qtParcelas; n++)
                                    {
                                        int numParcela = n + incremento;

                                        RecebimentoParcela rp = rps.Where(t => t.numParcela == numParcela).FirstOrDefault();

                                        // Verifica se a parcela existe
                                        ParcelaSpress parcelaSpress = parcelasSpress.Where(t => t.PARNRO == (n + 1)).FirstOrDefault();

                                        // Tem a parcela no Card Services?
                                        if (rp == null)
                                        {
                                            // Se não tem no Spress, vai ter que reportar que precisa ser inserida
                                            if (parcelasSpress == null)
                                                parcelasASeremInseridas.Add(n + 1);
                                            continue; // só trata
                                        }

                                        // Existe a parcela?
                                        if (parcelaSpress != null)
                                        {
                                            #region ATUALIZA VALOR E DATA DE VENCIMENTO
                                            if (vendaSpress.TIPO == 'C')
                                            {
                                                script = "UPDATE TCCCACPAR" +
                                                         " SET CACPARVLR = " + rp.valorParcelaBruta.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                         ", CACPARDATVENCTO = " + DatabaseQueries.GetIntDate(rp.dtaRecebimento) +
                                                         " WHERE K0 = '" + parcelaSpress.K0 + "'";
                                            }
                                            else
                                            {
                                                script = "UPDATE TCCCABPAR" +
                                                         " SET CABPARVLR = " + rp.valorParcelaBruta.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                         ", CABPARDATVENCTO = " + DatabaseQueries.GetIntDate(rp.dtaRecebimento) +
                                                         " WHERE K0 = '" + parcelaSpress.K0 + "'";
                                            }
                                            command = new FbCommand(script, conn);
                                            command.Transaction = transaction;

                                            try
                                            {
                                                command.ExecuteNonQuery();
                                            }
                                            catch (Exception e)
                                            {
                                                throw new Exception("Parcela '" + parcelaSpress.K0 + "'. " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            #region INSERE A PARCELA NO SPRESS
                                            if (vendaSpress.TIPO == 'C')
                                            {
                                                script = "INSERT INTO TCCCACPAR (CACADMCOD, EXPMONCOD, RECEBINRO, CACMODDATREGISTRO" +
                                                         ", CACMODSEQ, CACPARNRO, CACPARDATVENCTO, CACPARVLR, CACPARIDTSITUACAO" +
                                                         ", CACPARCODBANATU, CACPARCODAGEATU, CACPARNROCONATU)" +
                                                         " VALUES (" + vendaSpress.ADMCOD + ",  '" + vendaSpress.EXPMONCOD + "'" +
                                                         ", " + vendaSpress.RECEBINRO + ", " + vendaSpress.MODDATREGISTRO +
                                                         ", " + vendaSpress.MODSEQ + ", " + (n + 1) +
                                                         ", " + DatabaseQueries.GetIntDate(rp.dtaRecebimento) +
                                                         ", " + rp.valorParcelaBruta.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                         ", 'AB', " + vendaSpress.PARCODBANATU + ", " + vendaSpress.PARCODAGEATU +
                                                         ", '" + vendaSpress.PARNROCONATU + "')";
                                            }
                                            else
                                            {
                                                script = "INSERT INTO TCCCABPAR (CABADMCOD, EXPMONCOD, RECEBINRO, CABMODDATREGISTRO" +
                                                         ", CABMODSEQ, CABPARNRO, CABPARDATVENCTO, CABPARVLR, CABPARIDTSITUACAO" +
                                                         ", CABPARCODBANATU, CABPARCODAGEATU, CABPARNROCONATU)" +
                                                         " VALUES (" + vendaSpress.ADMCOD + ",  '" + vendaSpress.EXPMONCOD + "'" +
                                                         ", " + vendaSpress.RECEBINRO + ", " + vendaSpress.MODDATREGISTRO +
                                                         ", " + vendaSpress.MODSEQ + ", " + (n + 1) +
                                                         ", " + DatabaseQueries.GetIntDate(rp.dtaRecebimento) +
                                                         ", " + rp.valorParcelaBruta.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                         ", 'AB', " + vendaSpress.PARCODBANATU + ", " + vendaSpress.PARCODAGEATU +
                                                         ", '" + vendaSpress.PARNROCONATU + "')";
                                            }
                                            command = new FbCommand(script, conn);
                                            command.Transaction = transaction;

                                            try
                                            {
                                                command.ExecuteNonQuery();
                                            }
                                            catch (Exception e)
                                            {
                                                throw new Exception("Nova parcela " + (n + 1) + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                                            }
                                            #endregion
                                        }


                                        if (codResumoVenda != null)
                                        {
                                            decimal valorCalculado = new decimal(0.0);
                                            if (parcelaSpress != null && vendaSpress.RESNRO != 0 && !vendaSpress.RESNRO.ToString().Equals(codResumoVenda))
                                            {
                                                ResumoSpress resumoAntigo = null;
                                                #region ATUALIZA/REMOVE RESUMO ANTIGO
                                                // Busca resumo antigo
                                                if (vendaSpress.TIPO == 'C')
                                                {
                                                    script = "SELECT K0, CACADMCOD AS ADMCOD" + 
                                                             ", CACRESDATVENCTO AS RESDATVENCTO" + 
                                                             ", CACRESNRO AS RESNRO" + 
                                                             ", CACRESNROREGISTROS AS RESNROREGISTROS" + 
                                                             ", CACRESVLR AS RESVLR" + 
                                                             ", CACRESVLRCALC AS RESVLRCALC" +
                                                             ", CACRESIDTSITUACAO AS RESIDTSITUACAO" +
                                                             " FROM TCCCACRES" +
                                                             " WHERE CACRESNRO = " + vendaSpress.RESNRO +
                                                             " AND CACRESDATVENCTO = " + parcelaSpress.PARDATVENCTO + 
                                                             " AND CACADMCOD = " + vendaSpress.ADMCOD;
                                                }
                                                else
                                                {
                                                    script = "SELECT K0, CABADMCOD AS ADMCOD" +
                                                             ", CABRESDATVENCTO AS RESDATVENCTO" +
                                                             ", CABRESNRO AS RESNRO" +
                                                             ", CABRESNROREGISTROS AS RESNROREGISTROS" +
                                                             ", CABRESVLR AS RESVLR" +
                                                             ", CABRESVLRCALC AS RESVLRCALC" +
                                                             ", CABRESIDTSITUACAO AS RESIDTSITUACAO" +
                                                             " FROM TCCCABRES" +
                                                             " WHERE CABRESNRO = " + vendaSpress.RESNRO +
                                                             " AND CABRESDATVENCTO = " + parcelaSpress.PARDATVENCTO +
                                                             " AND CABADMCOD = " + vendaSpress.ADMCOD;
                                                }
                                                // Avalia resumo no vencimento
                                                command = new FbCommand(script, conn);
                                                command.Transaction = transaction;

                                                using (FbDataReader dr = command.ExecuteReader())
                                                {
                                                    if (dr.Read())
                                                    {
                                                        resumoAntigo = new ResumoSpress()
                                                        {
                                                            K0 = Convert.ToString(dr["K0"]),
                                                            ADMCOD = Convert.ToInt32(dr["ADMCOD"]),
                                                            RESNRO = Convert.ToInt32(dr["RESNRO"]),
                                                            RESDATVENCTO = Convert.ToInt32(dr["RESDATVENCTO"]),
                                                            RESNROREGISTROS = Convert.ToInt32(dr["RESNROREGISTROS"]),
                                                            RESVLR = Convert.ToDecimal(dr["RESVLR"]),
                                                            RESVLRCALC = Convert.ToDecimal(dr["RESVLRCALC"]),
                                                            RESIDTSITUACAO = Convert.ToString(dr["RESIDTSITUACAO"]),
                                                        };
                                                    }
                                                }

                                                
                                                if (resumoAntigo != null)
                                                {
                                                    if (resumoAntigo.RESNROREGISTROS <= 1)
                                                    {
                                                        #region DELETA RESUMO ANTIGO
                                                        if (vendaSpress.TIPO == 'C')
                                                        {
                                                            script = "DELETE TCCCACRES" +
                                                                     " WHERE K0 = '" + resumoAntigo.K0 + "')";
                                                        }
                                                        else
                                                        {
                                                            script = "DELETE TCCCABRES" +
                                                                     " WHERE K0 = '" + resumoAntigo.K0 + "')";
                                                        }
                                                        command = new FbCommand(script, conn);
                                                        command.Transaction = transaction;
                                                        try
                                                        {
                                                            command.ExecuteNonQuery();
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            throw new Exception("Remoção do resumo antigo " + resumoAntigo.RESNRO + " vencimento " + resumoAntigo.RESDATVENCTO + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                                                        }
                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        #region ATUALIZA RESUMO ANTIGO
                                                        // Obtém desconto
                                                        valorCalculado = decimal.Round(parcelaSpress.PARVLR * (new decimal(1.0) - taxaDescontoAntiga / new decimal(100.0)), 2);

                                                        if (vendaSpress.TIPO == 'C')
                                                        {
                                                            script = "UPDATE TCCCACRES" +
                                                                     " SET CACNROREGISTROS = " + (resumoAntigo.RESNROREGISTROS - 1) +
                                                                     ", CACRESVLR = " + (resumoAntigo.RESVLR > parcelaSpress.PARVLR ? resumoAntigo.RESVLR - parcelaSpress.PARVLR : 0).ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                                     ", CACRESVLRCALC = " + (resumoAntigo.RESVLRCALC > valorCalculado ? resumoAntigo.RESVLRCALC - valorCalculado : 0).ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                                     " WHERE K0 = '" + resumoAntigo.K0 + "')";
                                                        }
                                                        else
                                                        {
                                                            script = "UPDATE TCCCABRES" +
                                                                    " SET CABNROREGISTROS = " + (resumoAntigo.RESNROREGISTROS - 1) +
                                                                    ", CABRESVLR = " + (resumoAntigo.RESVLR > parcelaSpress.PARVLR ? resumoAntigo.RESVLR - parcelaSpress.PARVLR : 0).ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                                    ", CABRESVLRCALC = " + (resumoAntigo.RESVLRCALC > valorCalculado ? resumoAntigo.RESVLRCALC - valorCalculado : 0).ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                                    " WHERE K0 = '" + resumoAntigo.K0 + "')";
                                                        }
                                                        command = new FbCommand(script, conn);
                                                        command.Transaction = transaction;
                                                        try
                                                        {
                                                            command.ExecuteNonQuery();
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            throw new Exception("Atualização do resumo antigo " + resumoAntigo.RESNRO + " vencimento " + resumoAntigo.RESDATVENCTO + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                                                        }
                                                        #endregion
                                                    }
                                                }
                                                #endregion
                                            }

                                            ResumoSpress resumo = null;
                                            valorCalculado = decimal.Round(rp.valorParcelaBruta * (new decimal(1.0) - taxaDesconto / new decimal(100.0)), 2);
                                            #region ATUALIZA/INSERE RESUMO ATUAL
                                            
                                            // Busca resumo antigo
                                            if (vendaSpress.TIPO == 'C')
                                            {
                                                script = "SELECT K0, CACADMCOD AS ADMCOD" +
                                                         ", CACRESDATVENCTO AS RESDATVENCTO" +
                                                         ", CACRESNRO AS RESNRO" +
                                                         ", CACRESNROREGISTROS AS RESNROREGISTROS" +
                                                         ", CACRESVLR AS RESVLR" +
                                                         ", CACRESVLRCALC AS RESVLRCALC" +
                                                         ", CACRESIDTSITUACAO AS RESIDTSITUACAO" +
                                                         " FROM TCCCACRES" +
                                                         " WHERE CACRESNRO = " + codResumoVenda +
                                                         " AND CACRESDATVENCTO = " + DatabaseQueries.GetIntDate(rp.dtaRecebimento) +
                                                         " AND CACADMCOD = " + vendaSpress.ADMCOD;
                                            }
                                            else
                                            {
                                                script = "SELECT K0, CABADMCOD AS ADMCOD" +
                                                         ", CABRESDATVENCTO AS RESDATVENCTO" +
                                                         ", CABRESNRO AS RESNRO" +
                                                         ", CABRESNROREGISTROS AS RESNROREGISTROS" +
                                                         ", CABRESVLR AS RESVLR" +
                                                         ", CABRESVLRCALC AS RESVLRCALC" +
                                                         ", CABRESIDTSITUACAO AS RESIDTSITUACAO" +
                                                         " FROM TCCCABRES" +
                                                         " WHERE CABRESNRO = " + codResumoVenda +
                                                         " AND CABRESDATVENCTO = " + DatabaseQueries.GetIntDate(rp.dtaRecebimento) +
                                                         " AND CABADMCOD = " + vendaSpress.ADMCOD;
                                            }
                                            // Avalia resumo no vencimento
                                            command = new FbCommand(script, conn);
                                            command.Transaction = transaction;

                                            using (FbDataReader dr = command.ExecuteReader())
                                            {
                                                if (dr.Read())
                                                {
                                                    resumo = new ResumoSpress()
                                                    {
                                                        K0 = Convert.ToString(dr["K0"]),
                                                        ADMCOD = Convert.ToInt32(dr["ADMCOD"]),
                                                        RESNRO = Convert.ToInt32(dr["RESNRO"]),
                                                        RESDATVENCTO = Convert.ToInt32(dr["RESDATVENCTO"]),
                                                        RESNROREGISTROS = Convert.ToInt32(dr["RESNROREGISTROS"]),
                                                        RESVLR = Convert.ToDecimal(dr["RESVLR"]),
                                                        RESVLRCALC = Convert.ToDecimal(dr["RESVLRCALC"]),
                                                        RESIDTSITUACAO = Convert.ToString(dr["RESIDTSITUACAO"]),
                                                    };
                                                }
                                            }

                                            if (resumo == null)
                                            {
                                                int dataNow = DatabaseQueries.GetIntDate(DateTime.Now);
                                                #region INSERE NOVO RESUMO
                                                if (vendaSpress.TIPO == 'C')
                                                {
                                                    script = "INSERT INTO TCCCACRES (CACADMCOD, CACRESNRO, CACRESDATVENCTO, CACRESVLR" +
                                                             ", CACRESVLRCALC, CACRESNROREGISTROS, CACRESIDTSITUACAO, CACRESDATGERACAO" +
                                                             ", CACRESDATULTOPE, BANCOSCOD, AGEBANCOD, CONCORNRO, CACRESVLRINTEGRA)" +
                                                            " VALUES (" + vendaSpress.ADMCOD + ", " + codResumoVenda + ", " + DatabaseQueries.GetIntDate(rp.dtaRecebimento) + 
                                                            ", " + rp.valorParcelaBruta.ToString(CultureInfo.GetCultureInfo("en-GB")) + 
                                                            ", " + valorCalculado.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                            ", 1, 'AB', " + dataNow +
                                                            ", " + dataNow + ", 0, 0, '', 0)";
                                                }
                                                else
                                                {
                                                    script = "INSERT INTO TCCCABRES (CABADMCOD, CABRESNRO, CABRESDATVENCTO, CABRESVLR" +
                                                              ", CABRESVLRCALC, CABRESNROREGISTROS, CABRESIDTSITUACAO, CABRESDATGERACAO" +
                                                              ", CABRESDATULTOPE, BANCOSCOD, AGEBANCOD, CONCORNRO, CABRESVLRINTEGRA)" +
                                                             " VALUES (" + vendaSpress.ADMCOD + ", " + codResumoVenda + ", " + DatabaseQueries.GetIntDate(rp.dtaRecebimento) +
                                                             ", " + rp.valorParcelaBruta.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                             ", " + valorCalculado.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                             ", 1, 'AB', " + dataNow +
                                                             ", " + dataNow + ", 0, 0, '', 0)";
                                                }
                                                command = new FbCommand(script, conn);
                                                command.Transaction = transaction;
                                                try
                                                {
                                                    command.ExecuteNonQuery();
                                                }
                                                catch (Exception e)
                                                {
                                                    throw new Exception("Inserção do resumo " + codResumoVenda + " vencimento " + DatabaseQueries.GetIntDate(rp.dtaRecebimento) + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                                                }
                                                #endregion
                                            }
                                            else if (vendaSpress.RESNRO != 0 && !vendaSpress.RESNRO.ToString().Equals(codResumoVenda))
                                            {
                                                #region ATUALIZA RESUMO ANTIGO
                                                if (vendaSpress.TIPO == 'C')
                                                {
                                                    script = "UPDATE TCCCACRES" +
                                                             " SET CACNROREGISTROS = " + (resumo.RESNROREGISTROS + 1) +
                                                             ", CACRESVLR = " + (resumo.RESVLR + rp.valorParcelaBruta).ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                             ", CACRESVLRCALC = " + (resumo.RESVLRCALC + valorCalculado).ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                             " WHERE K0 = '" + resumo.K0 + "')";
                                                }
                                                else
                                                {
                                                    script = "UPDATE TCCCABRES" +
                                                            " SET CABNROREGISTROS = " + (resumo.RESNROREGISTROS - 1) +
                                                            ", CABRESVLR = " + (resumo.RESVLR - rp.valorParcelaBruta).ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                            ", CABRESVLRCALC = " + (resumo.RESVLR - valorCalculado).ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                            " WHERE K0 = '" + resumo.K0 + "')";
                                                }
                                                command = new FbCommand(script, conn);
                                                command.Transaction = transaction;
                                                try
                                                {
                                                    command.ExecuteNonQuery();
                                                }
                                                catch (Exception e)
                                                {
                                                    throw new Exception("Atualização do resumo " + resumo.RESNRO + " vencimento " + resumo.RESDATVENCTO + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                                                }
                                                #endregion  
                                            }
                                            #endregion
                                        }
                                    }
                                    #endregion

                                    if (parcelasASeremInseridas.Count > 0)
                                    {
                                        if (dsMensagem == null) dsMensagem = "";
                                        else dsMensagem += Environment.NewLine + Environment.NewLine;

                                        if (parcelasASeremInseridas.Count == 1)
                                            dsMensagem += "É necessário carregar a parcela " + parcelasASeremInseridas.First();
                                        else
                                            dsMensagem += "É necessário carregar as parcelas " + string.Join(", ", parcelasASeremInseridas);

                                        dsMensagem += ". Para isso, use o programa Boot ICard";
                                    }

                                    // Tem parcelas indevidas?
                                    List<ParcelaSpress> parcelasIndevidas = parcelasSpress.Where(t => t.PARNRO > venda.R_qtParcelas).ToList();
                                    #region REMOVE TÍTULOS INDEVIDOS
                                    for (int p = 0; p < parcelasIndevidas.Count; p++)
                                    {
                                        ParcelaSpress parcelaSpress = parcelasIndevidas[p];

                                        #region ATUALIZA/DELETA RESUMO
                                        ResumoSpress resumo = null;
                                        // Busca resumo antigo
                                        if (vendaSpress.TIPO == 'C')
                                        {
                                            script = "SELECT K0, CACADMCOD AS ADMCOD" +
                                                        ", CACRESDATVENCTO AS RESDATVENCTO" +
                                                        ", CACRESNRO AS RESNRO" +
                                                        ", CACRESNROREGISTROS AS RESNROREGISTROS" +
                                                        ", CACRESVLR AS RESVLR" +
                                                        ", CACRESVLRCALC AS RESVLRCALC" +
                                                        ", CACRESIDTSITUACAO AS RESIDTSITUACAO" +
                                                        " FROM TCCCACRES" +
                                                        " WHERE CACRESNRO = " + vendaSpress.RESNRO +
                                                        " AND CACRESDATVENCTO = " + parcelaSpress.PARDATVENCTO +
                                                        " AND CACADMCOD = " + vendaSpress.ADMCOD;
                                        }
                                        else
                                        {
                                            script = "SELECT K0, CABADMCOD AS ADMCOD" +
                                                        ", CABRESDATVENCTO AS RESDATVENCTO" +
                                                        ", CABRESNRO AS RESNRO" +
                                                        ", CABRESNROREGISTROS AS RESNROREGISTROS" +
                                                        ", CABRESVLR AS RESVLR" +
                                                        ", CABRESVLRCALC AS RESVLRCALC" +
                                                        ", CABRESIDTSITUACAO AS RESIDTSITUACAO" +
                                                        " FROM TCCCABRES" +
                                                        " WHERE CABRESNRO = " + vendaSpress.RESNRO +
                                                        " AND CABRESDATVENCTO = " + parcelaSpress.PARDATVENCTO +
                                                        " AND CABADMCOD = " + vendaSpress.ADMCOD;
                                        }
                                        // Avalia resumo no vencimento
                                        command = new FbCommand(script, conn);
                                        command.Transaction = transaction;

                                        using (FbDataReader dr = command.ExecuteReader())
                                        {
                                            if (dr.Read())
                                            {
                                                resumo = new ResumoSpress()
                                                {
                                                    K0 = Convert.ToString(dr["K0"]),
                                                    ADMCOD = Convert.ToInt32(dr["ADMCOD"]),
                                                    RESNRO = Convert.ToInt32(dr["RESNRO"]),
                                                    RESDATVENCTO = Convert.ToInt32(dr["RESDATVENCTO"]),
                                                    RESNROREGISTROS = Convert.ToInt32(dr["RESNROREGISTROS"]),
                                                    RESVLR = Convert.ToDecimal(dr["RESVLR"]),
                                                    RESVLRCALC = Convert.ToDecimal(dr["RESVLRCALC"]),
                                                    RESIDTSITUACAO = Convert.ToString(dr["RESIDTSITUACAO"]),
                                                };
                                            }
                                        }

                                        if (resumo != null)
                                        {
                                            if (resumo.RESNROREGISTROS <= 1)
                                            {
                                                #region DELETA RESUMO ANTIGO
                                                if (vendaSpress.TIPO == 'C')
                                                {
                                                    script = "DELETE TCCCACRES" +
                                                                " WHERE K0 = '" + resumo.K0 + "')";
                                                }
                                                else
                                                {
                                                    script = "DELETE TCCCABRES" +
                                                                " WHERE K0 = '" + resumo.K0 + "')";
                                                }
                                                command = new FbCommand(script, conn);
                                                command.Transaction = transaction;
                                                try
                                                {
                                                    command.ExecuteNonQuery();
                                                }
                                                catch (Exception e)
                                                {
                                                    throw new Exception("Remoção do resumo indevido " + resumo.RESNRO + " vencimento " + resumo.RESDATVENCTO + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                // Obtém desconto
                                                decimal valorCalculado = decimal.Round(parcelaSpress.PARVLR * (new decimal(1.0) - taxaDescontoAntiga / new decimal(100.0)), 2);

                                                #region ATUALIZA RESUMO ANTIGO
                                                if (vendaSpress.TIPO == 'C')
                                                {
                                                    script = "UPDATE TCCCACRES" +
                                                                " SET CACNROREGISTROS = " + (resumo.RESNROREGISTROS - 1) +
                                                                ", CACRESVLR = " + (resumo.RESVLR > parcelaSpress.PARVLR ? resumo.RESVLR - parcelaSpress.PARVLR : 0).ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                                ", CACRESVLRCALC = " + (resumo.RESVLRCALC > valorCalculado ? resumo.RESVLRCALC - valorCalculado : 0).ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                                " WHERE K0 = '" + resumo.K0 + "')";
                                                }
                                                else
                                                {
                                                    script = "UPDATE TCCCABRES" +
                                                            " SET CABNROREGISTROS = " + (resumo.RESNROREGISTROS - 1) +
                                                            ", CABRESVLR = " + (resumo.RESVLR > parcelaSpress.PARVLR ? resumo.RESVLR - parcelaSpress.PARVLR : 0).ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                            ", CABRESVLRCALC = " + (resumo.RESVLRCALC > valorCalculado ? resumo.RESVLRCALC - valorCalculado : 0).ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                            " WHERE K0 = '" + resumo.K0 + "')";
                                                }
                                                command = new FbCommand(script, conn);
                                                command.Transaction = transaction;
                                                try
                                                {
                                                    command.ExecuteNonQuery();
                                                }
                                                catch (Exception e)
                                                {
                                                    throw new Exception("Atualização do resumo indevido " + resumo.RESNRO + " vencimento " + resumo.RESDATVENCTO + ". " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                                                }
                                                #endregion
                                            }
                                        }
                                        #endregion

                                        #region DELETA O TÍTULO
                                        if (vendaSpress.TIPO == 'C')
                                        {
                                            script = "DELETE TCCCACPAR" +
                                                     " WHERE K0 = '" + parcelaSpress.K0 + "'";
                                        }
                                        else
                                        {
                                            script = "DELETE TCCCABPAR" +
                                                     " WHERE K0 = '" + parcelaSpress.K0 + "'";
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
                                            throw new Exception("Parcela " + parcelaSpress.PARNRO + " indevida da venda '" + K0 + "'. " + (e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message));
                                        }
                                        #endregion
                                    }
                                    #endregion

                                    #endregion

                                    #endregion
                                }
                            }

                            transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
                        }


                        // Atualizar tabela tbRecebimentoVenda
                        script = "UPDATE V" +
                                 " SET V.dtAjuste = getdate()" + 
                                 ", V.dsMensagem = " + (dsMensagem == null ? "NULL" : "'" + dsMensagem + "'") +
                                 // Só atualiza os campos se a venda foi encontrada no Spress
                                 (vendaSpress == null ? "" // não atualiza mais nenhum campo
                                                      : ", V.qtParcelas = " + venda.R_qtParcelas +
                                                        ", V.vlVenda = " + venda.R_vlVenda.ToString(CultureInfo.GetCultureInfo("en-GB")) +
                                                        (atualizaNsu ? ", V.nrNSU = '" + nsuAtualizada + "'" : "")
                                 ) +
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