using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;
using WebApiSpress.Models.Sql;

namespace WebApiSpress.Bibliotecas
{
    public class LogAcaoUsuario
    {
        private static Semaphore semaforo;

        public LogAcaoUsuario()
        {
            semaforo = new Semaphore(1, 1);
        }


        public static tbLogAcessoUsuario New(string token, string dsJson, string dsMethod, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else _db = _dbContext;

            try
            {
                bool Mobile = Bibliotecas.Device.IsMobile();

                tbLogAcessoUsuario log = new tbLogAcessoUsuario();
                log.idUser = Bibliotecas.Permissoes.GetIdUser(token, _db);
                log.dsUrl = HttpContext.Current.Request.Url.Segments[1] + HttpContext.Current.Request.Url.Segments[2];

                string afterUrl = HttpContext.Current.Request.RawUrl.Replace((HttpContext.Current.Request.Url.Segments[0] + HttpContext.Current.Request.Url.Segments[1] + HttpContext.Current.Request.Url.Segments[2]), "");

                int index = afterUrl.IndexOf('?');
                if (index > -1)
                {
                    // tem filtros
                    log.dsFiltros = afterUrl.Substring(index);
                    log.dsParametros = afterUrl.Substring(0, index);
                }
                else
                {
                    // Não tem filtros
                    log.dsFiltros = String.Empty;
                    log.dsParametros = afterUrl;
                }
                //log.dsFiltros = HttpContext.Current.Request.RawUrl.LastIndexOf('?') > 0 ? HttpContext.Current.Request.RawUrl.Remove(0, HttpContext.Current.Request.RawUrl.LastIndexOf('?')) : String.Empty;

                log.dtAcesso = DateTime.Now;
                log.dsAplicacao = Mobile ? "M" : "P";
                log.dsMethod = dsMethod;
                log.idController = _db.LogAcesso1.Where(l => l.idUsers == log.idUser)
                                                 .Where(l => l.flMobile == Mobile)
                                                 .OrderByDescending(l => l.dtAcesso)
                                                 .Select(l => l.idController)
                                                 .FirstOrDefault();
                /* Campos alimentados no controller*/
                //log.codResposta = data.codResposta; 
                //log.msgErro = data.msgErro;
                log.dsJson = dsJson != null ? dsJson : String.Empty;
                log.dsUserAgent = HttpContext.Current.Request.UserAgent;
                return log;
            }
            catch (Exception e)
            {
                if (e is DbEntityValidationException)
                {
                    string erro = MensagemErro.getMensagemErro((DbEntityValidationException)e);
                    throw new Exception(erro.Equals("") ? "Falha ao salvar log" : erro);
                }
                throw new Exception(e.Message);
            }
            finally
            {
                if (_dbContext == null)
                {
                    // Fecha conexão
                    _db.Database.Connection.Close();
                    _db.Dispose();
                }
            }
        }

        public static void Save(tbLogAcessoUsuario data, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else _db = _dbContext;

            if (semaforo == null) semaforo = new Semaphore(1, 1);
            semaforo.WaitOne();
            try
            {
                _db.tbLogAcessoUsuarios.Add(data);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                if (e is DbEntityValidationException)
                {
                    string erro = MensagemErro.getMensagemErro((DbEntityValidationException)e);
                    throw new Exception(erro.Equals("") ? "Falha ao salvar log" : erro);
                }
                throw new Exception(e.Message);
            }
            finally
            {
                semaforo.Release(1);
                if (_dbContext == null)
                {
                    // Fecha conexão
                    _db.Database.Connection.Close();
                    _db.Dispose();
                }
            }
        }
    }
}