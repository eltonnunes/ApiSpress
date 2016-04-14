using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebApiSpress.Models.Sql.Mapping;

namespace WebApiSpress.Models.Sql
{
    public partial class painel_taxservices_dbContext : DbContext
    {
        static painel_taxservices_dbContext()
        {
            Database.SetInitializer<painel_taxservices_dbContext>(null);
        }

        public painel_taxservices_dbContext()
            : base("Name=painel_taxservices_dbContext")
        {
            Database.CommandTimeout = 60; // 1 minuto
        }

        public DbSet<ConnectionString> ConnectionStrings { get; set; }
        public DbSet<LogExceptionWinApp> LogExceptionWinApps { get; set; }
        public DbSet<Bandeira> Bandeiras { get; set; }
        public DbSet<Carga> Cargas { get; set; }
        public DbSet<ConciliacaoPagamento> ConciliacaoPagamentos { get; set; }
        public DbSet<ConciliacaoVenda> ConciliacaoVendas { get; set; }
        public DbSet<PDV> PDVs { get; set; }
        public DbSet<tbIPTef> tbIPTefs { get; set; }
        public DbSet<TipoPagamento> TipoPagamentoes { get; set; }
        public DbSet<empresa> empresas { get; set; }
        public DbSet<grupo_baseCnpj> grupo_baseCnpj { get; set; }
        public DbSet<grupo_empresa> grupo_empresa { get; set; }
        public DbSet<agendamento_finalizado> agendamento_finalizado { get; set; }
        public DbSet<arquivo_email> arquivo_email { get; set; }
        public DbSet<atualizacao_log> atualizacao_log { get; set; }
        public DbSet<bandeiras1> bandeiras1 { get; set; }
        public DbSet<cel_rede_autorizadora> cel_rede_autorizadora { get; set; }
        public DbSet<CodigoEstabelecimento> CodigoEstabelecimentoes { get; set; }
        public DbSet<colreltrn> colreltrns { get; set; }
        public DbSet<columnmodel> columnmodels { get; set; }
        public DbSet<columnmodelpadro> columnmodelpadroes { get; set; }
        public DbSet<conccliente> concclientes { get; set; }
        public DbSet<concessionaria> concessionarias { get; set; }
        public DbSet<config_entries> config_entries { get; set; }
        public DbSet<config_section> config_section { get; set; }
        public DbSet<confrel> confrels { get; set; }
        public DbSet<conv_formapgto_cb> conv_formapgto_cb { get; set; }
        public DbSet<convbandeira> convbandeiras { get; set; }
        public DbSet<convmodoentrada> convmodoentradas { get; set; }
        public DbSet<convproduto> convprodutoes { get; set; }
        public DbSet<convtransaco> convtransacoes { get; set; }
        public DbSet<ctl_exp> ctl_exp { get; set; }
        public DbSet<ctl_sequencia> ctl_sequencia { get; set; }
        public DbSet<DATABASECHANGELOG> DATABASECHANGELOGs { get; set; }
        public DbSet<DATABASECHANGELOGLOCK> DATABASECHANGELOGLOCKs { get; set; }
        public DbSet<DefGrupo> DefGrupoes { get; set; }
        public DbSet<defregional> defregionals { get; set; }
        public DbSet<descmeiospag> descmeiospags { get; set; }
        public DbSet<dtproperty> dtproperties { get; set; }
        public DbSet<estado_usuario> estado_usuario { get; set; }
        public DbSet<estadotransacao> estadotransacaos { get; set; }
        public DbSet<formapgto_cartao_pre> formapgto_cartao_pre { get; set; }
        public DbSet<formapgto_cartao_recarga> formapgto_cartao_recarga { get; set; }
        public DbSet<grp_concessionaria> grp_concessionaria { get; set; }
        public DbSet<Grupo> Grupoes { get; set; }
        public DbSet<historico_senhas> historico_senhas { get; set; }
        public DbSet<Hora> Horas { get; set; }
        public DbSet<Lixo> Lixoes { get; set; }
        public DbSet<log> logs { get; set; }
        public DbSet<log_cartao_pre> log_cartao_pre { get; set; }
        public DbSet<log_cartao_pre_tmp> log_cartao_pre_tmp { get; set; }
        public DbSet<log_eventos> log_eventos { get; set; }
        public DbSet<log_eventos_dados> log_eventos_dados { get; set; }
        public DbSet<log_eventos_desc_eventos> log_eventos_desc_eventos { get; set; }
        public DbSet<log_eventos_desc_origem> log_eventos_desc_origem { get; set; }
        public DbSet<logacesso> logacessoes { get; set; }
        public DbSet<logcb> logcbs { get; set; }
        public DbSet<logcb_det> logcb_det { get; set; }
        public DbSet<logcb_det_tmp> logcb_det_tmp { get; set; }
        public DbSet<logcb_tmp> logcb_tmp { get; set; }
        public DbSet<LogCbSuperFamilia> LogCbSuperFamilias { get; set; }
        public DbSet<logconsulta> logconsultas { get; set; }
        public DbSet<logconsulta_tmp> logconsulta_tmp { get; set; }
        public DbSet<logpp_consulta> logpp_consulta { get; set; }
        public DbSet<logpp_premiacao> logpp_premiacao { get; set; }
        public DbSet<logrecargacel> logrecargacels { get; set; }
        public DbSet<logrecargacel_tmp> logrecargacel_tmp { get; set; }
        public DbSet<logservcel> logservcels { get; set; }
        public DbSet<logtef> logtefs { get; set; }
        public DbSet<logtef_tmp> logtef_tmp { get; set; }
        public DbSet<logvendaoffline> logvendaofflines { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<modoentrada> modoentradas { get; set; }
        public DbSet<MSpeer_lsns> MSpeer_lsns { get; set; }
        public DbSet<MSpeer_request> MSpeer_request { get; set; }
        public DbSet<MSpeer_response> MSpeer_response { get; set; }
        public DbSet<MSpub_identity_range> MSpub_identity_range { get; set; }
        public DbSet<nfe_entrada> nfe_entrada { get; set; }
        public DbSet<nfe_saida_new> nfe_saida_new { get; set; }
        public DbSet<nivel_usuarios> nivel_usuarios { get; set; }
        public DbSet<notificacao_iservices> notificacao_iservices { get; set; }
        public DbSet<parametro_recepcao> parametro_recepcao { get; set; }
        public DbSet<pessoa> pessoas { get; set; }
        public DbSet<produto> produtos { get; set; }
        public DbSet<produtosporrede> produtosporredes { get; set; }
        public DbSet<qrtz_blob_triggers> qrtz_blob_triggers { get; set; }
        public DbSet<qrtz_calendars> qrtz_calendars { get; set; }
        public DbSet<qrtz_cron_triggers> qrtz_cron_triggers { get; set; }
        public DbSet<qrtz_fired_triggers> qrtz_fired_triggers { get; set; }
        public DbSet<qrtz_job_details> qrtz_job_details { get; set; }
        public DbSet<qrtz_job_listeners> qrtz_job_listeners { get; set; }
        public DbSet<qrtz_locks> qrtz_locks { get; set; }
        public DbSet<qrtz_paused_trigger_grps> qrtz_paused_trigger_grps { get; set; }
        public DbSet<qrtz_scheduler_state> qrtz_scheduler_state { get; set; }
        public DbSet<qrtz_simple_triggers> qrtz_simple_triggers { get; set; }
        public DbSet<qrtz_trigger_listeners> qrtz_trigger_listeners { get; set; }
        public DbSet<qrtz_triggers> qrtz_triggers { get; set; }
        public DbSet<recepcao_email> recepcao_email { get; set; }
        public DbSet<rede> redes { get; set; }
        public DbSet<regional> regionals { get; set; }
        public DbSet<sitefweb_projects> sitefweb_projects { get; set; }
        public DbSet<sitrede> sitredes { get; set; }
        public DbSet<SuporteLoja> SuporteLojas { get; set; }
        public DbSet<sysarticlecolumn> sysarticlecolumns { get; set; }
        public DbSet<sysarticle> sysarticles { get; set; }
        public DbSet<sysarticleupdate> sysarticleupdates { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<syspublication> syspublications { get; set; }
        public DbSet<sysreplserver> sysreplservers { get; set; }
        public DbSet<sysschemaarticle> sysschemaarticles { get; set; }
        public DbSet<syssubscription> syssubscriptions { get; set; }
        public DbSet<system_config_entries> system_config_entries { get; set; }
        public DbSet<system_config_section> system_config_section { get; set; }
        public DbSet<systranschema> systranschemas { get; set; }
        public DbSet<tab_bandeiras> tab_bandeiras { get; set; }
        public DbSet<tab_cb> tab_cb { get; set; }
        public DbSet<tab_codtrnweb_cb> tab_codtrnweb_cb { get; set; }
        public DbSet<tab_formapagto_cb> tab_formapagto_cb { get; set; }
        public DbSet<tab_tipodoc_cb> tab_tipodoc_cb { get; set; }
        public DbSet<tabaudit> tabaudits { get; set; }
        public DbSet<TabExp> TabExps { get; set; }
        public DbSet<TabMeiosPag> TabMeiosPags { get; set; }
        public DbSet<tbNotaDaGente> tbNotaDaGentes { get; set; }
        public DbSet<tipo_transacao> tipo_transacao { get; set; }
        public DbSet<tipoproduto> tipoprodutoes { get; set; }
        public DbSet<tot_trn> tot_trn { get; set; }
        public DbSet<transaco> transacoes { get; set; }
        public DbSet<uf> ufs { get; set; }
        public DbSet<usuario> usuarios { get; set; }
        public DbSet<tbBandeiraTef> tbBandeiraTefs { get; set; }
        public DbSet<tbProdutoTef> tbProdutoTefs { get; set; }
        public DbSet<tbModoEntradaTef> tbModoEntradaTefs { get; set; }
        public DbSet<tbEstadoTransacaoTef> tbEstadoTransacaoTefs { get; set; }
        public DbSet<tbRedeTef> tbRedeTefs { get; set; }
        public DbSet<tbSituacaoRedeTef> tbSituacaoRedeTefs { get; set; }
        public DbSet<tbTipoProdutoTef> tbTipoProdutoTefs { get; set; }
        public DbSet<tbTransacaoTef> tbTransacaoTefs { get; set; }
        public DbSet<webpages_Controllers> webpages_Controllers { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_Methods> webpages_Methods { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Permissions> webpages_Permissions { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
        public DbSet<webpages_Users> webpages_Users { get; set; }
        public DbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
        public DbSet<LogAcesso1> LogAcesso1 { get; set; }
        public DbSet<LoginAutenticacao> LoginAutenticacaos { get; set; }
        public DbSet<email> emails { get; set; }
        public DbSet<link> links { get; set; }
        public DbSet<newsletter> newsletters { get; set; }
        public DbSet<statistic> statistics { get; set; }
        public DbSet<fornecedor> fornecedors { get; set; }
        public DbSet<nfe_saida> nfe_saida { get; set; }
        public DbSet<LogNotaDaGente> LogNotaDaGentes { get; set; }
        public DbSet<NotaDaGente> NotaDaGentes { get; set; }
        public DbSet<PainelNotaDaGente> PainelNotaDaGentes { get; set; }
        public DbSet<SenhaNotaDaGente> SenhaNotaDaGentes { get; set; }
        public DbSet<merca> mercas { get; set; }
        public DbSet<merca_dePara> merca_dePara { get; set; }
        public DbSet<MercaFornecedor> MercaFornecedors { get; set; }
        public DbSet<pedido> pedidoes { get; set; }
        public DbSet<Adquirente> Adquirentes { get; set; }
        public DbSet<Amex> Amexes { get; set; }
        public DbSet<Bandeira1> Bandeiras2 { get; set; }
        public DbSet<BandeiraPos> BandeiraPos { get; set; }
        public DbSet<BaneseCard> BaneseCards { get; set; }
        public DbSet<Cielo> Cieloes { get; set; }
        public DbSet<ConciliacaoPagamentosPos> ConciliacaoPagamentosPos { get; set; }
        public DbSet<ConciliacaoRecebimento> ConciliacaoRecebimentoes { get; set; }
        public DbSet<FitCard> FitCards { get; set; }
        public DbSet<GetNetSantander> GetNetSantanders { get; set; }
        public DbSet<GoodCard> GoodCards { get; set; }
        public DbSet<GreenCard> GreenCards { get; set; }
        public DbSet<LogExecution> LogExecutions { get; set; }
        public DbSet<LogExecutionException> LogExecutionExceptions { get; set; }
        public DbSet<LoginOperadora> LoginOperadoras { get; set; }
        public DbSet<Nutricash> Nutricashes { get; set; }
        public DbSet<Omni> Omnis { get; set; }
        public DbSet<Operadora> Operadoras { get; set; }
        public DbSet<PoliCard> PoliCards { get; set; }
        public DbSet<Recebimento> Recebimentoes { get; set; }
        public DbSet<Recebimento_Original> Recebimento_Original { get; set; }
        public DbSet<Recebimento_Temp> Recebimento_Temp { get; set; }
        public DbSet<RecebimentoParcela> RecebimentoParcelas { get; set; }
        public DbSet<RedeCard> RedeCards { get; set; }
        public DbSet<RedeMed> RedeMeds { get; set; }
        public DbSet<Sodexo> Sodexoes { get; set; }
        public DbSet<TaxaAdministracao> TaxaAdministracaos { get; set; }
        public DbSet<tbRecebimentoTEF> tbRecebimentoTEFs { get; set; }
        public DbSet<TerminalLogico> TerminalLogicoes { get; set; }
        public DbSet<TicketCar> TicketCars { get; set; }
        public DbSet<ValeCard> ValeCards { get; set; }
        public DbSet<webpages_RoleLevels> webpages_RoleLevels { get; set; }
        public DbSet<tbContaCorrente> tbContaCorrentes { get; set; }
        public DbSet<tbContaCorrente_tbLoginAdquirenteEmpresa> tbContaCorrente_tbLoginAdquirenteEmpresas { get; set; }
        public DbSet<tbExtrato> tbExtratos { get; set; }
        public DbSet<tbRebimentoResumo> tbRebimentoResumos { get; set; }
        public DbSet<tbLogAcessoUsuario> tbLogAcessoUsuarios { get; set; }
        public DbSet<tbAdquirente> tbAdquirentes { get; set; }
        public DbSet<tbLoginAdquirenteEmpresa> tbLoginAdquirenteEmpresas { get; set; }
        public DbSet<tbManifesto> tbManifestos { get; set; }
        public DbSet<tbLogManifesto> tbLogManifestos { get; set; }
        public DbSet<tbBancoParametro> tbBancoParametro { get; set; }
        public DbSet<tbEmpresa> tbEmpresas { get; set; }
        public DbSet<tbEmpresaFilial> tbEmpresaFiliais { get; set; }
        public DbSet<tbEmpresaGrupo> tbEmpresaGrupos { get; set; }
        public DbSet<tbLogErro> tbLogErros { get; set; }
        public DbSet<tbControleNSU> tbControleNSUs { get; set; }
        public DbSet<tbCanal> tbCanals { get; set; }
        public DbSet<tbNews> tbNewss { get; set; }
        public DbSet<tbCatalogo> tbCatalogos { get; set; }
        public DbSet<tbNewsStatus> tbNewsStatuss { get; set; }
        public DbSet<tbNewsGrupos> tbNewsGrupos { get; set; }
        public DbSet<tbRecebimentoTitulo> tbRecebimentoTituloes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ConnectionStringMap());
            modelBuilder.Configurations.Add(new LogExceptionWinAppMap());
            modelBuilder.Configurations.Add(new BandeiraMap());
            modelBuilder.Configurations.Add(new CargaMap());
            modelBuilder.Configurations.Add(new ConciliacaoPagamentoMap());
            modelBuilder.Configurations.Add(new ConciliacaoVendaMap());
            modelBuilder.Configurations.Add(new PDVMap());
            modelBuilder.Configurations.Add(new tbIPTefMap());
            modelBuilder.Configurations.Add(new TipoPagamentoMap());
            modelBuilder.Configurations.Add(new empresaMap());
            modelBuilder.Configurations.Add(new grupo_baseCnpjMap());
            modelBuilder.Configurations.Add(new grupo_empresaMap());
            modelBuilder.Configurations.Add(new agendamento_finalizadoMap());
            modelBuilder.Configurations.Add(new arquivo_emailMap());
            modelBuilder.Configurations.Add(new atualizacao_logMap());
            modelBuilder.Configurations.Add(new bandeiras1Map());
            modelBuilder.Configurations.Add(new cel_rede_autorizadoraMap());
            modelBuilder.Configurations.Add(new CodigoEstabelecimentoMap());
            modelBuilder.Configurations.Add(new colreltrnMap());
            modelBuilder.Configurations.Add(new columnmodelMap());
            modelBuilder.Configurations.Add(new columnmodelpadroMap());
            modelBuilder.Configurations.Add(new concclienteMap());
            modelBuilder.Configurations.Add(new concessionariaMap());
            modelBuilder.Configurations.Add(new config_entriesMap());
            modelBuilder.Configurations.Add(new config_sectionMap());
            modelBuilder.Configurations.Add(new confrelMap());
            modelBuilder.Configurations.Add(new conv_formapgto_cbMap());
            modelBuilder.Configurations.Add(new convbandeiraMap());
            modelBuilder.Configurations.Add(new convmodoentradaMap());
            modelBuilder.Configurations.Add(new convprodutoMap());
            modelBuilder.Configurations.Add(new convtransacoMap());
            modelBuilder.Configurations.Add(new ctl_expMap());
            modelBuilder.Configurations.Add(new ctl_sequenciaMap());
            modelBuilder.Configurations.Add(new DATABASECHANGELOGMap());
            modelBuilder.Configurations.Add(new DATABASECHANGELOGLOCKMap());
            modelBuilder.Configurations.Add(new DefGrupoMap());
            modelBuilder.Configurations.Add(new defregionalMap());
            modelBuilder.Configurations.Add(new descmeiospagMap());
            modelBuilder.Configurations.Add(new dtpropertyMap());
            modelBuilder.Configurations.Add(new estado_usuarioMap());
            modelBuilder.Configurations.Add(new estadotransacaoMap());
            modelBuilder.Configurations.Add(new formapgto_cartao_preMap());
            modelBuilder.Configurations.Add(new formapgto_cartao_recargaMap());
            modelBuilder.Configurations.Add(new grp_concessionariaMap());
            modelBuilder.Configurations.Add(new GrupoMap());
            modelBuilder.Configurations.Add(new historico_senhasMap());
            modelBuilder.Configurations.Add(new HoraMap());
            modelBuilder.Configurations.Add(new LixoMap());
            modelBuilder.Configurations.Add(new logMap());
            modelBuilder.Configurations.Add(new log_cartao_preMap());
            modelBuilder.Configurations.Add(new log_cartao_pre_tmpMap());
            modelBuilder.Configurations.Add(new log_eventosMap());
            modelBuilder.Configurations.Add(new log_eventos_dadosMap());
            modelBuilder.Configurations.Add(new log_eventos_desc_eventosMap());
            modelBuilder.Configurations.Add(new log_eventos_desc_origemMap());
            modelBuilder.Configurations.Add(new logacessoMap());
            modelBuilder.Configurations.Add(new logcbMap());
            modelBuilder.Configurations.Add(new logcb_detMap());
            modelBuilder.Configurations.Add(new logcb_det_tmpMap());
            modelBuilder.Configurations.Add(new logcb_tmpMap());
            modelBuilder.Configurations.Add(new LogCbSuperFamiliaMap());
            modelBuilder.Configurations.Add(new logconsultaMap());
            modelBuilder.Configurations.Add(new logconsulta_tmpMap());
            modelBuilder.Configurations.Add(new logpp_consultaMap());
            modelBuilder.Configurations.Add(new logpp_premiacaoMap());
            modelBuilder.Configurations.Add(new logrecargacelMap());
            modelBuilder.Configurations.Add(new logrecargacel_tmpMap());
            modelBuilder.Configurations.Add(new logservcelMap());
            modelBuilder.Configurations.Add(new logtefMap());
            modelBuilder.Configurations.Add(new logtef_tmpMap());
            modelBuilder.Configurations.Add(new logvendaofflineMap());
            modelBuilder.Configurations.Add(new LojaMap());
            modelBuilder.Configurations.Add(new modoentradaMap());
            modelBuilder.Configurations.Add(new MSpeer_lsnsMap());
            modelBuilder.Configurations.Add(new MSpeer_requestMap());
            modelBuilder.Configurations.Add(new MSpeer_responseMap());
            modelBuilder.Configurations.Add(new MSpub_identity_rangeMap());
            modelBuilder.Configurations.Add(new nfe_entradaMap());
            modelBuilder.Configurations.Add(new nfe_saida_newMap());
            modelBuilder.Configurations.Add(new nivel_usuariosMap());
            modelBuilder.Configurations.Add(new notificacao_iservicesMap());
            modelBuilder.Configurations.Add(new parametro_recepcaoMap());
            modelBuilder.Configurations.Add(new pessoaMap());
            modelBuilder.Configurations.Add(new produtoMap());
            modelBuilder.Configurations.Add(new produtosporredeMap());
            modelBuilder.Configurations.Add(new qrtz_blob_triggersMap());
            modelBuilder.Configurations.Add(new qrtz_calendarsMap());
            modelBuilder.Configurations.Add(new qrtz_cron_triggersMap());
            modelBuilder.Configurations.Add(new qrtz_fired_triggersMap());
            modelBuilder.Configurations.Add(new qrtz_job_detailsMap());
            modelBuilder.Configurations.Add(new qrtz_job_listenersMap());
            modelBuilder.Configurations.Add(new qrtz_locksMap());
            modelBuilder.Configurations.Add(new qrtz_paused_trigger_grpsMap());
            modelBuilder.Configurations.Add(new qrtz_scheduler_stateMap());
            modelBuilder.Configurations.Add(new qrtz_simple_triggersMap());
            modelBuilder.Configurations.Add(new qrtz_trigger_listenersMap());
            modelBuilder.Configurations.Add(new qrtz_triggersMap());
            modelBuilder.Configurations.Add(new recepcao_emailMap());
            modelBuilder.Configurations.Add(new redeMap());
            modelBuilder.Configurations.Add(new regionalMap());
            modelBuilder.Configurations.Add(new sitefweb_projectsMap());
            modelBuilder.Configurations.Add(new sitredeMap());
            modelBuilder.Configurations.Add(new SuporteLojaMap());
            modelBuilder.Configurations.Add(new sysarticlecolumnMap());
            modelBuilder.Configurations.Add(new sysarticleMap());
            modelBuilder.Configurations.Add(new sysarticleupdateMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new syspublicationMap());
            modelBuilder.Configurations.Add(new sysreplserverMap());
            modelBuilder.Configurations.Add(new sysschemaarticleMap());
            modelBuilder.Configurations.Add(new syssubscriptionMap());
            modelBuilder.Configurations.Add(new system_config_entriesMap());
            modelBuilder.Configurations.Add(new system_config_sectionMap());
            modelBuilder.Configurations.Add(new systranschemaMap());
            modelBuilder.Configurations.Add(new tab_bandeirasMap());
            modelBuilder.Configurations.Add(new tab_cbMap());
            modelBuilder.Configurations.Add(new tab_codtrnweb_cbMap());
            modelBuilder.Configurations.Add(new tab_formapagto_cbMap());
            modelBuilder.Configurations.Add(new tab_tipodoc_cbMap());
            modelBuilder.Configurations.Add(new tabauditMap());
            modelBuilder.Configurations.Add(new TabExpMap());
            modelBuilder.Configurations.Add(new TabMeiosPagMap());
            modelBuilder.Configurations.Add(new tbNotaDaGenteMap());
            modelBuilder.Configurations.Add(new tipo_transacaoMap());
            modelBuilder.Configurations.Add(new tipoprodutoMap());
            modelBuilder.Configurations.Add(new tot_trnMap());
            modelBuilder.Configurations.Add(new transacoMap());
            modelBuilder.Configurations.Add(new ufMap());
            modelBuilder.Configurations.Add(new usuarioMap());
            modelBuilder.Configurations.Add(new tbBandeiraTefMap());
            modelBuilder.Configurations.Add(new tbEstadoTransacaoTefMap());
            modelBuilder.Configurations.Add(new tbModoEntradaTefMap());
            modelBuilder.Configurations.Add(new tbProdutoTefMap());
            modelBuilder.Configurations.Add(new tbRedeTefMap());
            modelBuilder.Configurations.Add(new tbSituacaoRedeTefMap());
            modelBuilder.Configurations.Add(new tbTipoProdutoTefMap());
            modelBuilder.Configurations.Add(new tbTransacaoTefMap()); 
            modelBuilder.Configurations.Add(new webpages_ControllersMap());
            modelBuilder.Configurations.Add(new webpages_MembershipMap());
            modelBuilder.Configurations.Add(new webpages_MethodsMap());
            modelBuilder.Configurations.Add(new webpages_OAuthMembershipMap());
            modelBuilder.Configurations.Add(new webpages_PermissionsMap());
            modelBuilder.Configurations.Add(new webpages_RolesMap());
            modelBuilder.Configurations.Add(new webpages_UsersMap());
            modelBuilder.Configurations.Add(new webpages_UsersInRolesMap());
            modelBuilder.Configurations.Add(new LogAcesso1Map());
            modelBuilder.Configurations.Add(new LoginAutenticacaoMap());
            modelBuilder.Configurations.Add(new emailMap());
            modelBuilder.Configurations.Add(new linkMap());
            modelBuilder.Configurations.Add(new newsletterMap());
            modelBuilder.Configurations.Add(new statisticMap());
            modelBuilder.Configurations.Add(new fornecedorMap());
            modelBuilder.Configurations.Add(new nfe_saidaMap());
            modelBuilder.Configurations.Add(new LogNotaDaGenteMap());
            modelBuilder.Configurations.Add(new NotaDaGenteMap());
            modelBuilder.Configurations.Add(new PainelNotaDaGenteMap());
            modelBuilder.Configurations.Add(new SenhaNotaDaGenteMap());
            modelBuilder.Configurations.Add(new mercaMap());
            modelBuilder.Configurations.Add(new merca_deParaMap());
            modelBuilder.Configurations.Add(new MercaFornecedorMap());
            modelBuilder.Configurations.Add(new pedidoMap());
            modelBuilder.Configurations.Add(new AdquirenteMap());
            modelBuilder.Configurations.Add(new AmexMap());
            modelBuilder.Configurations.Add(new Bandeira1Map());
            modelBuilder.Configurations.Add(new BandeiraPosMap());
            modelBuilder.Configurations.Add(new BaneseCardMap());
            modelBuilder.Configurations.Add(new CieloMap());
            modelBuilder.Configurations.Add(new ConciliacaoPagamentosPosMap());
            modelBuilder.Configurations.Add(new ConciliacaoRecebimentoMap());
            modelBuilder.Configurations.Add(new FitCardMap());
            modelBuilder.Configurations.Add(new GetNetSantanderMap());
            modelBuilder.Configurations.Add(new GoodCardMap());
            modelBuilder.Configurations.Add(new GreenCardMap());
            modelBuilder.Configurations.Add(new LogExecutionMap());
            modelBuilder.Configurations.Add(new LogExecutionExceptionMap());
            modelBuilder.Configurations.Add(new LoginOperadoraMap());
            modelBuilder.Configurations.Add(new NutricashMap());
            modelBuilder.Configurations.Add(new OmniMap());
            modelBuilder.Configurations.Add(new OperadoraMap());
            modelBuilder.Configurations.Add(new PoliCardMap());
            modelBuilder.Configurations.Add(new RecebimentoMap());
            modelBuilder.Configurations.Add(new Recebimento_OriginalMap());
            modelBuilder.Configurations.Add(new Recebimento_TempMap());
            modelBuilder.Configurations.Add(new RecebimentoParcelaMap());
            modelBuilder.Configurations.Add(new RedeCardMap());
            modelBuilder.Configurations.Add(new RedeMedMap());
            modelBuilder.Configurations.Add(new SodexoMap());
            modelBuilder.Configurations.Add(new TaxaAdministracaoMap());
            modelBuilder.Configurations.Add(new tbRecebimentoTEFMap());
            modelBuilder.Configurations.Add(new TerminalLogicoMap());
            modelBuilder.Configurations.Add(new TicketCarMap());
            modelBuilder.Configurations.Add(new ValeCardMap());
            modelBuilder.Configurations.Add(new webpages_RoleLevelsMap());
            modelBuilder.Configurations.Add(new tbContaCorrenteMap());
            modelBuilder.Configurations.Add(new tbContaCorrente_tbLoginAdquirenteEmpresaMap());
            modelBuilder.Configurations.Add(new tbExtratoMap());
            modelBuilder.Configurations.Add(new tbRebimentoResumoMap());
            modelBuilder.Configurations.Add(new tbLogAcessoUsuarioMap());
            modelBuilder.Configurations.Add(new tbAdquirenteMap());
            modelBuilder.Configurations.Add(new tbLoginAdquirenteEmpresaMap());
            modelBuilder.Configurations.Add(new tbManifestoMap());
            modelBuilder.Configurations.Add(new tbLogManifestoMap());
            modelBuilder.Configurations.Add(new tbBancoParametroMap());
            modelBuilder.Configurations.Add(new tbEmpresaFilialMap());
            modelBuilder.Configurations.Add(new tbEmpresaGrupoMap());
            modelBuilder.Configurations.Add(new tbEmpresaMap());
            modelBuilder.Configurations.Add(new tbLogErroMap());
            modelBuilder.Configurations.Add(new tbControleNSUMap());
            modelBuilder.Configurations.Add(new tbCanalMap());
            modelBuilder.Configurations.Add(new tbNewsMap());
            modelBuilder.Configurations.Add(new tbCatalogoMap());
            modelBuilder.Configurations.Add(new tbNewsStatusMap());
            modelBuilder.Configurations.Add(new tbNewsGrupoMap());
            modelBuilder.Configurations.Add(new tbRecebimentoTituloMap());
        }
    }
}
