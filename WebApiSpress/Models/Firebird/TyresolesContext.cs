using System;
using System.Text;
using System.Data;
using System.Data.Entity;
using WebApiSpress.Models.Firebird.Mapping;
using FirebirdSql.Data.FirebirdClient;
using WebApiSpress.Models.Object;
using System.Collections.Generic;

namespace WebApiSpress.Models.Firebird
{
    public partial class TyresolesContext : DbContext
    {
        static TyresolesContext()
        {
            Database.SetInitializer<TyresolesContext>(null);
        }

        public TyresolesContext()
            : base("Name=TyresolesContext")
        {
            Database.CommandTimeout = 120; // 2 minuto
        }

        public DbSet<tb_forma_rectoMap> Tb_Forma_Recto { get; set; }
        public DbSet<tb_itens_rcMap> Tb_Itens_Rc { get; set; }
        public DbSet<tb_lojaMap> Tb_Loja { get; set; }
        public DbSet<tb_receberMap> Tb_Receber { get; set; }
        public DbSet<tb_vendasMap> Tb_Vendas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new tb_forma_rectoMap());
            modelBuilder.Configurations.Add(new tb_itens_rcMap());
            modelBuilder.Configurations.Add(new tb_lojaMap());
            modelBuilder.Configurations.Add(new tb_receberMap());
            modelBuilder.Configurations.Add(new tb_vendasMap());
        }

        public DataTable GetTitulos(String dta)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                String connstring = this.Database.Connection.ConnectionString;
                FbConnection conn = new FbConnection(connstring);
                conn.Open();

                string sql = "Select f.FILIALNROCGC As nrCNPJ, ('T' || Cast(cp.K0 As Varchar(33))) As nrNSU, cp.CACMODDATREGISTRO As dtVenda, (Case When cm.EXPMONCOD In ('BANESE', 'CAJUCARD', 'DINERS', 'DINERS+7', 'ELO', 'FLEXCARD', 'GOODCAR', 'HIPER', 'HIPER+7', 'MASTER', 'MASTER+7', 'SHELL', 'SODEXO', 'TKTCAR', 'VISA', 'VISA+7') Then 1 When cm.EXPMONCOD In ('AMERICAN', 'ELO') Then 2 End) As cdAdquirente, cm.EXPMONCOD As dsBandeira, cm.CACMODVLR As vlVenda, cm.CACMODNROPARCELAS As qtParcelas, cp.CACPARDATVENCTO As dtTitulo, cp.CACPARVLR As vlParcela, cp.CACPARNRO As nrParcela, cp.K0 As cdERP, cv.CACMOVDATOPERACAO As dtBaixaERP From TCCCACPAR cp Join TCCCACMOD cm On cm.CACADMCOD = cp.CACADMCOD AND cm.EXPMONCOD = cp.EXPMONCOD And cm.RECEBINRO = cp.RECEBINRO And cm.CACMODDATREGISTRO = cp.CACMODDATREGISTRO And cm.CACMODSEQ = cp.CACMODSEQ Left Join TCCCACMOV cv On cv.CACADMCOD = cp.CACADMCOD AND cv.EXPMONCOD = cp.EXPMONCOD And cv.RECEBINRO = cp.RECEBINRO And cv.CACMODDATREGISTRO = cp.CACMODDATREGISTRO And cv.CACMODSEQ = cp.CACMODSEQ And cv.cacparnro = cp.cacparnro Join TCCCAIXA c On c.CAIXACOD = cm.CACMODCODAGEORI Join TGLFILIAL f On f.FILIALCOD = c.FILIALCOD Where cp.CACPARDATVENCTO = " + dta + "" + " Union Select f.FILIALNROCGC  As nrCNPJ, ('T' || Cast(cp.K0 As Varchar(33))) As nrNSU, cp.CABMODDATREGISTRO As dtVenda, (Case When cm.EXPMONCOD In ('BANESEDE', 'REDSHOP', 'TCKETCAR', 'VISAELET') Then 1 End) As cdAdquirente, cm.EXPMONCOD As dsBandeira, cm.CABMODVLR As vlVenda, cm.CABMODNROPARCELAS As qtParcelas, cp.CABPARDATVENCTO As dtTitulo, cp.CABPARVLR As vlParcela, cp.CABPARNRO As nrParcela, cp.K0 As cdERP, cv.CABMOVDATOPERACAO As dtBaixaERP From TCCCABPAR cp Join TCCCABMOD cm On cm.CABADMCOD = cp.CABADMCOD AND cm.EXPMONCOD = cp.EXPMONCOD And cm.RECEBINRO = cp.RECEBINRO And cm.CABMODDATREGISTRO = cp.CABMODDATREGISTRO And cm.CABMODSEQ = cp.CABMODSEQ Left Join TCCCABMOV cv On cv.CABADMCOD = cp.CABADMCOD AND cv.EXPMONCOD = cp.EXPMONCOD And cv.RECEBINRO = cp.RECEBINRO And cv.CABMODDATREGISTRO = cp.CABMODDATREGISTRO And cv.CABMODSEQ = cp.CABMODSEQ And cv.caBparnro = cp.caBparnro Join TCCCAIXA c On c.CAIXACOD = cm.CABMODCODAGEORI Join TGLFILIAL f On f.FILIALCOD = c.FILIALCOD Where cp.CABPARDATVENCTO = " + dta + "";
                FbDataAdapter da = new FbDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];

                conn.Close();

                return dt;
            }
            catch (Exception msg)
            {
                throw msg;
            }
        }


        public List<TitulosExpress> GetTitulosExpress(String dta)
        {
            String connstring = this.Database.Connection.ConnectionString;
            //string connstring = Bibliotecas.Permissoes.GetConnectionString(token);
            FbConnection conn = new FbConnection(connstring);

            try
            {
                conn.Open();
            }
            catch
            {
                throw new Exception("Falha de comunicação com o servidor (Cliente)");
            }

            try
            {
                string sql = "Select f.FILIALNROCGC As nrCNPJ, ('T' || Cast(cp.K0 As Varchar(33))) As nrNSU, cp.CACMODDATREGISTRO As dtVenda, (Case When cm.EXPMONCOD In ('BANESE', 'CAJUCARD', 'DINERS', 'DINERS+7', 'ELO', 'FLEXCARD', 'GOODCAR', 'HIPER', 'HIPER+7', 'MASTER', 'MASTER+7', 'SHELL', 'SODEXO', 'TKTCAR', 'VISA', 'VISA+7') Then 1 When cm.EXPMONCOD In ('AMERICAN', 'ELO') Then 2 End) As cdAdquirente, cm.EXPMONCOD As dsBandeira, cm.CACMODVLR As vlVenda, cm.CACMODNROPARCELAS As qtParcelas, cp.CACPARDATVENCTO As dtTitulo, cp.CACPARVLR As vlParcela, cp.CACPARNRO As nrParcela, cp.K0 As cdERP, cv.CACMOVDATOPERACAO As dtBaixaERP From TCCCACPAR cp Join TCCCACMOD cm On cm.CACADMCOD = cp.CACADMCOD AND cm.EXPMONCOD = cp.EXPMONCOD And cm.RECEBINRO = cp.RECEBINRO And cm.CACMODDATREGISTRO = cp.CACMODDATREGISTRO And cm.CACMODSEQ = cp.CACMODSEQ Left Join TCCCACMOV cv On cv.CACADMCOD = cp.CACADMCOD AND cv.EXPMONCOD = cp.EXPMONCOD And cv.RECEBINRO = cp.RECEBINRO And cv.CACMODDATREGISTRO = cp.CACMODDATREGISTRO And cv.CACMODSEQ = cp.CACMODSEQ And cv.cacparnro = cp.cacparnro Join TCCCAIXA c On c.CAIXACOD = cm.CACMODCODAGEORI Join TGLFILIAL f On f.FILIALCOD = c.FILIALCOD Where cp.CACPARDATVENCTO = " + dta + "" + " Union Select f.FILIALNROCGC  As nrCNPJ, ('T' || Cast(cp.K0 As Varchar(33))) As nrNSU, cp.CABMODDATREGISTRO As dtVenda, (Case When cm.EXPMONCOD In ('BANESEDE', 'REDSHOP', 'TCKETCAR', 'VISAELET') Then 1 End) As cdAdquirente, cm.EXPMONCOD As dsBandeira, cm.CABMODVLR As vlVenda, cm.CABMODNROPARCELAS As qtParcelas, cp.CABPARDATVENCTO As dtTitulo, cp.CABPARVLR As vlParcela, cp.CABPARNRO As nrParcela, cp.K0 As cdERP, cv.CABMOVDATOPERACAO As dtBaixaERP From TCCCABPAR cp Join TCCCABMOD cm On cm.CABADMCOD = cp.CABADMCOD AND cm.EXPMONCOD = cp.EXPMONCOD And cm.RECEBINRO = cp.RECEBINRO And cm.CABMODDATREGISTRO = cp.CABMODDATREGISTRO And cm.CABMODSEQ = cp.CABMODSEQ Left Join TCCCABMOV cv On cv.CABADMCOD = cp.CABADMCOD AND cv.EXPMONCOD = cp.EXPMONCOD And cv.RECEBINRO = cp.RECEBINRO And cv.CABMODDATREGISTRO = cp.CABMODDATREGISTRO And cv.CABMODSEQ = cp.CABMODSEQ And cv.caBparnro = cp.caBparnro Join TCCCAIXA c On c.CAIXACOD = cm.CABMODCODAGEORI Join TGLFILIAL f On f.FILIALCOD = c.FILIALCOD Where cp.CABPARDATVENCTO = " + dta + "";

                FbCommand command = new FbCommand(sql, conn);

                List<TitulosExpress> titulos = new List<TitulosExpress>();

                using (FbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        titulos.Add(new TitulosExpress
                                    {
                                        nrCNPJ = Convert.ToString(dr["nrCNPJ"]),
                                        nrNSU = Convert.ToString(dr["nrNSU"]),
                                        dtVenda = Convert.ToDateTime(Convert.ToString(dr["dtVenda"]).Substring(0, 4) + "-" + Convert.ToString(dr["dtVenda"]).Substring(4, 2) + "-" + Convert.ToString(dr["dtVenda"]).Substring(6, 2)),
                                        //cdAdquirente = Convert.ToInt32(dr["cdAdquirente"]),
                                        cdSacado = dr["dsBandeira"].Equals(DBNull.Value) ? null : Convert.ToString(dr["dsBandeira"]),
                                        dsBandeira = dr["dsBandeira"].Equals(DBNull.Value) ? null : Convert.ToString(dr["dsBandeira"]),
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

                return titulos;
            }
            catch (Exception msg)
            {
                throw msg;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}