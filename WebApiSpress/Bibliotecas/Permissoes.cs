using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSpress.Models.Object;
using WebApiSpress.Models.Sql;

namespace WebApiSpress.Bibliotecas
{
    public class Permissoes
    {

        // ======================== VALIDAÇÃO DE ACESSO AOS MÉTODOS DA API ======================================//

        private static AcessoMetodoAPI acessoMetodosAPIs = new AcessoMetodoAPI();

        /// <summary>
        /// Retorna true se o usuário tem permissão para acessar o método da URL da API
        /// </summary>
        /// <param name="token"></param>
        /// <param name="url"></param>
        /// <param name="metodo"></param>
        /// <returns></returns>
        public static bool usuarioTemPermissaoMetodoURL(string token, string url, string metodo)
        {
            if (acessoMetodosAPIs.Count() == 0) PopulateAcessoMetodosAPIs();

            metodo = metodo.ToUpper();

            string method = metodo.Equals("GET") ? "Leitura" :
                            metodo.Equals("POST") || metodo.Equals("PATCH") ? "Cadastro" :
                            metodo.Equals("PUT") ? "Atualização" :
                            metodo.Equals("DELETE") ? "Remoção" : "";

            if (method.Equals("")) return false; // método HTTP inválido

            Int32 idController = GetIdUltimoControllerAcessado(token);
            if (idController == 0 || !usuarioTemPermissaoMetodoController(token, idController, method)) return false;

            // Controller acessado pode fazer a requisição?
            return acessoMetodosAPIs.IsMetodoControllerPermitidoInURL(url, idController, metodo);
        }

        /// <summary>
        /// Obtém o ID do controller a partir do dsController
        /// </summary>
        /// <param name="dscontrollers"></param> Lista dos dscontrollers, do filho para o pai
        /// <returns></returns>
        private static Int32 GetIdController(List<string> dscontrollers)
        {
            using (var _db = new painel_taxservices_dbContext())
            {
                _db.Configuration.ProxyCreationEnabled = false;

                if (dscontrollers.Count == 0) return 0;

                //_db.Configuration.ProxyCreationEnabled = false;
                var query = _db.webpages_Controllers.AsQueryable<webpages_Controllers>();

                // Verifica se o nome é único
                string ds_controller = dscontrollers[0].ToUpper();
                List<webpages_Controllers> list = query.Where(e => e.ds_controller.ToUpper().Equals(ds_controller)).ToList<webpages_Controllers>();
                if (dscontrollers.Count == 1 || list.Count == 1) return list[0].id_controller;

                // Verifica o nome dele com o nome do pai dele
                string ds_controller1 = dscontrollers[1].ToUpper();
                list = query.Where(e => e.ds_controller.ToUpper().Equals(ds_controller))
                            .Where(e => e.webpages_Controllers2.ds_controller.ToUpper().Equals(ds_controller1))
                            .ToList<webpages_Controllers>();

                if (dscontrollers.Count == 2 || list.Count == 1) return list[0].id_controller;

                // Verifica o nome dele com os nomes do pai e avô dele
                string ds_controller2 = dscontrollers[2].ToUpper();
                list = query.Where(e => e.ds_controller.ToUpper().Equals(ds_controller))
                            .Where(e => e.webpages_Controllers2.ds_controller.ToUpper().Equals(ds_controller1))
                            .Where(e => e.webpages_Controllers2.webpages_Controllers2.ds_controller.ToUpper().Equals(ds_controller2))
                            .ToList<webpages_Controllers>();

                if (list.Count > 1) return list[0].id_controller;
                return 0;

            }
        }

        /// <summary>
        /// Inicializa o objeto acessoMetodosAPIs, que armazena para cada API as possíveis origens (telas) da requisição e seus respectivos métodos
        /// </summary>
        private static void PopulateAcessoMetodosAPIs(){

            List<ControllersOrigem> controllersOrigem = new List<ControllersOrigem>();
            acessoMetodosAPIs.Clear();

            // -------------------------------- CONTROLLERS PORTAL -------------------------------- //
            Int32 idControllerPortalModulosFuncionalidades = GetIdController(new List<string>() { "MÓDULOS E FUNCIONALIDADES", "GESTÃO DE ACESSOS" });
            Int32 idControllerPortalPrivilegios = GetIdController(new List<string>() { "PRIVILÉGIOS", "GESTÃO DE ACESSOS" });
            Int32 idControllerPortalUsuarios = GetIdController(new List<string>() { "USUÁRIOS", "GESTÃO DE ACESSOS" });
            Int32 idControllerPortalMinhaConta = 91;
            // ...
            // ----------------------------- FIM - CONTROLLERS PORTAL ----------------------------- //

            // -------------------------------- CONTROLLERS MOBILE -------------------------------- //
            // ...
            // ----------------------------- FIM - CONTROLLERS MOBILE ----------------------------- //


            // ============================= ADMINISTRAÇÃO ======================================= //
            /*                            WEBPAGESCONTROLLERS                                      */
            controllersOrigem.Clear();
            // [PORTAL] ADMINISTRATIVO > GESTÃO DE ACESSOS > MÓDULOS E FUNCIONALIDADES
            controllersOrigem.Add(new ControllersOrigem(idControllerPortalModulosFuncionalidades, new string[] { "GET", "DELETE", "POST", "PUT" }));
            // [PORTAL] ADMINISTRATIVO > GESTÃO DE ACESSOS > PRIVILÉGIOS
            controllersOrigem.Add(new ControllersOrigem(idControllerPortalPrivilegios, new string[] { "GET" })); 
            // Adiciona
            acessoMetodosAPIs.Add(UrlAPIs.ADMINISTRACAO_WEBPAGESCONTROLLERS, controllersOrigem);
            /*                               WEBPAGESUSERS                                         */
            controllersOrigem.Clear();
            // [PORTAL] ADMINISTRATIVO > GESTÃO DE ACESSOS > USUÁRIOS
            controllersOrigem.Add(new ControllersOrigem(idControllerPortalUsuarios, new string[] { "GET", "DELETE", "POST", "PUT" }));
            // [PORTAL] MINHA CONTA
            controllersOrigem.Add(new ControllersOrigem(idControllerPortalMinhaConta, new string[] { "GET", "PUT" }));
            // Adiciona (OBS: ÚNICA RESTRIÇÃO É O "PUT" PARA ALTERAR O GRUPO EMPRESA => PODE VIR DE QUALQUER TELA)
            acessoMetodosAPIs.Add(UrlAPIs.ADMINISTRACAO_WEBPAGESUSERS, controllersOrigem);

        }


        // ======================== FIM - VALIDAÇÃO DE ACESSO AOS MÉTODOS DA API ======================== //



        /// <summary>
        /// Retorna true se o token informado é válido
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool Autenticado(string token, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            try
            {
                var verify = _db.LoginAutenticacaos.Where(v => v.token.Equals(token)).Select(v => v).FirstOrDefault();

                if (verify != null)
                    return true;

                return false;
            }
            catch
            {
                return false;
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

        /// <summary>
        /// A partir do token, obtém o objeto webpages_Users correspondente
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Null se o token for inválido</returns>
        public static webpages_Users GetUser(string token, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            try
            {
                return _db.LoginAutenticacaos.Where(v => v.token.Equals(token))
                            .Select(v => v.webpages_Users)
                            .FirstOrDefault<webpages_Users>();

            }
            catch
            {
                return null;
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
            //return _db.LoginAutenticacaos.Where(v => v.token.Equals(token)).Select(v => v.webpages_Users).FirstOrDefault();
        }

        /// <summary>
        /// A partir do token, obtém o id do usuário correspondente
        /// </summary>
        /// <param name="token"></param>
        /// <returns>0 se o token for inválido</returns>
        public static Int32 GetIdUser(string token, painel_taxservices_dbContext _dbContext = null)
        {
            webpages_Users user = GetUser(token, _dbContext);
            if (user != null) return (Int32)user.id_users;
            return 0;
        }

        /// <summary>
        /// A partir do token, obtém o id do grupo que o usuário correspondente está associado
        /// </summary>
        /// <param name="token"></param>
        /// <returns>0 se o token for inválido ou se o usuário não estiver associado a algum grupo</returns>
        public static Int32 GetIdGrupo(string token, painel_taxservices_dbContext _dbContext = null)
        {
            webpages_Users user = GetUser(token, _dbContext);
            if (user != null && user.id_grupo != null) return (Int32)user.id_grupo;
            return 0;
        }

        public static string GetConnectionString(string token, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            Int32 IdGrupo = 0;
            string connectionString = null;
            try
            {

                IdGrupo = GetIdGrupo(token, _db);
                if (IdGrupo > 0)
                {
                    connectionString = _db.ConnectionStrings
                                            .Where(c => c.Id_Grupo == IdGrupo)
                                            .Where(c => c.Rede == "Wan")
                                            .Select(c => c.ConnectionStrings)
                                            .FirstOrDefault<string>();

                }
            }
            catch
            {
                return null;
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

            if (IdGrupo == 0)
                throw new Exception("Falha ao buscar a String de Conexão, entre em contato com o Administrador.");

            return connectionString;
        }

        /// <summary>
        /// A partir do token, obtém o cnpj que o usuário correspondente está associado
        /// </summary>
        /// <param name="token"></param>
        /// <returns>"" (string vazia) se o token for inválido ou se o usuário não estiver associado a alguma filial</returns>
        public static string GetCNPJEmpresa(string token, painel_taxservices_dbContext _dbContext = null)
        {
            webpages_Users user = GetUser(token, _dbContext);
            if (user != null && user.id_grupo != null && user.nu_cnpjEmpresa != null) return user.nu_cnpjEmpresa;
            return "";
        }

        /// <summary>
        /// A partir do token, obtém o objeto webpages_Roles que o usuário correspondente está associado
        /// </summary>
        /// <param name="token"></param>
        /// <returns>null se o token for inválido ou se o usuário não estiver associado a nenhuma role do novo portal (id > 50)</returns>
        public static webpages_Roles GetRole(string token, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            webpages_Roles role = null;
            try
            {
                webpages_Users user = GetUser(token, _db);

                if (user != null)
                {
                    role = _db.webpages_UsersInRoles
                                .Where(r => r.UserId == user.id_users)
                                .Where(r => r.RoleId > 50)
                                .Select(r => r.webpages_Roles)
                                .FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
            return role;
        }

        /// <summary>
        /// A partir do token, obtém o id da role que o usuário correspondente está associado 
        /// </summary>
        /// <param name="token"></param>
        /// <returns>0 se o token for inválido ou se o usuário não estiver associado a nenhuma role do novo portal (id > 50)</returns>
        public static Int32 GetRoleId(string token, painel_taxservices_dbContext _dbContext = null)
        {
            webpages_Roles role = GetRole(token, _dbContext);
            if (role != null) return role.RoleId;
            return 0;
        }

        /// <summary>
        /// A partir do token, obtém o nome da role que o usuário correspondente está associado 
        /// </summary>
        /// <param name="token"></param>
        /// <returns>"" (string vazia) se o token for inválido ou se o usuário não estiver associado a nenhuma role do novo portal (id > 50)</returns>
        public static String GetRoleName(string token, painel_taxservices_dbContext _dbContext = null)
        {
            webpages_Roles role = GetRole(token, _dbContext);
            if (role != null) return role.RoleName;
            return "";
        }

        /// <summary>
        /// A partir do token, obtém o nível da role que o usuário correspondente está associado 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Int32 GetRoleLevel(string token, painel_taxservices_dbContext _dbContext = null)
        {
            webpages_Roles role = GetRole(token, _dbContext);
            if (role != null) return role.RoleLevel;
            return 4;
        }

        /// <summary>
        /// A partir do token, obtém o valor mínimo de nível de role a partir do privilégio que o usuário está associado
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Int32 GetRoleLevelMin(string token, painel_taxservices_dbContext _dbContext = null)
        {
            Int32 RoleLevel = GetRoleLevel(token, _dbContext);
            if (RoleLevel > 1) return RoleLevel + 1;
            return RoleLevel;
        }

        /// <summary>
        /// Retorna true se o a role associada ao usuário é de um perfil da ATOS
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool isAtosRole(string token, painel_taxservices_dbContext _dbContext = null)
        {
            Int32 RoleLevel = GetRoleLevel(token, _dbContext);
            return RoleLevel >= 0 && RoleLevel <= 2;
        }

        /// <summary>
        /// Retorna true se o a role é de um perfil da ATOS
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static bool isAtosRole(webpages_Roles role)
        {
            if (role == null) return false;
            return role.RoleLevel >= 0 && role.RoleLevel <= 2;
        }

        /// <summary>
        /// Retorna true se a role associado ao usuário é de um perfil vendedor da ATOS
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool isAtosRoleVendedor(string token, painel_taxservices_dbContext _dbContext = null)
        {
            string RoleName = GetRoleName(token, _dbContext);
            return isAtosRole(token, _dbContext) && RoleName.ToUpper().Equals("COMERCIAL");
        }

        /// <summary>
        /// Retorna true se a role é de um perfil vendedor da ATOS
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool isAtosRoleVendedor(webpages_Roles role)
        {
            if (role == null) return false;
            return isAtosRole(role) && role.RoleName.ToUpper().Equals("COMERCIAL");
        }

        /// <summary>
        /// Obtém uma lista contendo os ids dos grupos aos quais o usuário é o vendedor responsável
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static List<Int32> GetIdsGruposEmpresasVendedor(string token, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            List<Int32> lista = new List<Int32>();

            try
            {
                Int32 UserId = GetIdUser(token, _db);
                lista = _db.grupo_empresa
                            .Where(g => g.id_vendedor == UserId)
                            .Select(g => g.id_grupo)
                            .ToList<Int32>();
            }
            catch { }
            finally
            {
                if (_dbContext == null)
                {
                    // Fecha conexão
                    _db.Database.Connection.Close();
                    _db.Dispose();
                }
            }

            return lista;
        }

        /// <summary>
        /// A partir da descrição do método e do id do controller, obtém o id o método
        /// </summary>
        /// <param name="idController"></param>
        /// <param name="ds_method"></param>
        /// <returns>0 se o método não existe para o controller</returns>
        public static Int32 GetIdMethod(Int32 idController, string ds_method, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            Int32 idMethod = 0;

            try
            {
                webpages_Methods method = _db.webpages_Methods.Where(m => m.id_controller == idController)
                                                     .Where(m => m.ds_method.ToUpper().Equals(ds_method.ToUpper()))
                                                     .FirstOrDefault();
                if (method != null)
                    idMethod = method.id_method;

                return idMethod;

            }
            catch
            {
                return 0;
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

        /// <summary>
        /// Retorna o id do último controller (tela) acessado pelo usuário
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Int32 GetIdUltimoControllerAcessado(string token, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            try
            {
                Int32 UserId = GetIdUser(token, _db);

                if (UserId == 0) return 0;

                return _db.LogAcesso1
                                .Where(e => e.idUsers == UserId)
                                .OrderByDescending(e => e.dtAcesso)
                                .Select(e => e.idController ?? 0)
                                .FirstOrDefault();
            }
            catch
            {
                return 0;
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


        /// <summary>
        /// Retorna true se o usuário com o token informado possui permissão para o controller
        /// </summary>
        /// <param name="token"></param>
        /// <param name="idController"></param>
        /// <returns></returns>
        public static bool usuarioTemPermissaoController(string token, Int32 idController, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            try
            {
                Int32 idRole = GetRoleId(token, _db);
                if (idRole == 0) return false;

                return _db.webpages_Permissions.Where(p => p.id_roles == idRole)
                                                .Where(p => p.webpages_Methods.id_controller == idController)
                                                .Count() > 0;
            }
            catch
            {
                return false;
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


        /// <summary>
        /// Retorna true se o usuário com o token informado possui permissão para o método do controller
        /// </summary>
        /// <param name="token"></param>
        /// <param name="idController"></param>
        /// <returns></returns>
        public static bool usuarioTemPermissaoMetodoController(string token, Int32 idController, string metodo, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            try
            {
                Int32 idRole = GetRoleId(token, _db);
                if (idRole == 0) return false;

                metodo = metodo.ToLower();

                return _db.webpages_Permissions.Where(p => p.id_roles == idRole)
                                               .Where(p => p.webpages_Methods.id_controller == idController)
                                               .Where(p => p.webpages_Methods.ds_method.ToLower().Equals(metodo))
                                               .Count() > 0;

            }
            catch
            {
                return false;
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

        /// <summary>
        /// Retorna true se o usuário pode se associar ao grupo informado
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id_grupo"></param>
        /// <returns></returns>
        public static Boolean usuarioPodeSeAssociarAoGrupo(string token, Int32 id_grupo, painel_taxservices_dbContext _dbContext = null)
        {
            bool isAtosVendedor = isAtosRoleVendedor(token, _dbContext);

            // Perfil ATOS não vendedor pode se associar a qualquer grupo
            if (isAtosRole(token, _dbContext) && !isAtosVendedor) return true;

            // Perfil ATOS vendedor pode se associar aos grupos de sua "carteira"
            if (isAtosVendedor)
            {
                List<Int32> list = GetIdsGruposEmpresasVendedor(token, _dbContext);
                return list.Contains(id_grupo);
            }

            // Qualquer outro privilégio não pode mudar de grupo
            return false;
        }


        /// <summary>
        /// Retorna o Ids dos grupos com dsAPI "apispress"
        /// </summary>
        /// <returns></returns>
        public static int[] GetIdsGruposSpress(painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            try
            {
                return _db.grupo_empresa.Where(e => e.dsAPI.Equals("apispress")).Select(e => e.id_grupo).ToArray();
            }
            catch
            {
                return new int[0];
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

        /// <summary>
        /// Retorna o Id do grupo "TYRESOLES"
        /// </summary>
        /// <returns></returns>
        public static Int32 GetIdTyresoles(painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            try
            {
                grupo_empresa grupoTyresoles = _db.grupo_empresa.Where(e => e.ds_nome.StartsWith("TYRESOLES")).FirstOrDefault();
                if (grupoTyresoles == null) return 0;
                return grupoTyresoles.id_grupo;
            }
            catch
            {
                return 0;
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

        /// <summary>
        /// Retorna true se o grupo que o usuário está associado é o TYRESOLES
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool isIdGrupoTyresoles(string token, painel_taxservices_dbContext _dbContext = null)
        {
            Int32 IdGrupo = GetIdGrupo(token, _dbContext);
            return IdGrupo > 0 && IdGrupo == GetIdTyresoles(_dbContext);
        }
       

        /// <summary>
        /// Retorna true se o usuário tem permissão para se associar ao grupo "PETROX"
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool usuarioTemPermissaoAssociarTyresoles(string token, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            try
            {
                bool isAtosVendedor = Permissoes.isAtosRoleVendedor(token, _db);

                // Usuário ATOS que não é vendedor tem permissão
                if (isAtosRole(token) && !isAtosVendedor) return true;

                if (isAtosVendedor)
                {
                    // Vendedor tem que ter em sua "carteira" o grupo referido
                    Int32 idGrupoPetrox = GetIdTyresoles(_db);
                    if (idGrupoPetrox == 0) return false;
                    List<Int32> list = GetIdsGruposEmpresasVendedor(token, _db);
                    return list.Contains(idGrupoPetrox);
                }
                return isIdGrupoTyresoles(token, _db); // Usuário Não-Atos tem que estar amarrado ao grupo para ter autorização
            }
            catch
            {
                return false;
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


        /// <summary>
        /// Retorna true se o usuário tem permissão para se associar a algum grupo que tem dsAPI "apispress"
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool usuarioTemPermissaoAssociarGrupoSpress(string token, painel_taxservices_dbContext _dbContext = null)
        {
            painel_taxservices_dbContext _db;
            if (_dbContext == null)
            {
                _db = new painel_taxservices_dbContext();
                _db.Configuration.ProxyCreationEnabled = false;
            }
            else
                _db = _dbContext;

            try
            {
                bool isAtosVendedor = Permissoes.isAtosRoleVendedor(token, _db);

                // Usuário ATOS que não é vendedor tem permissão
                if (isAtosRole(token) && !isAtosVendedor) return true;

                int[] idsGruposSpress = GetIdsGruposSpress(_db);

                if (idsGruposSpress.Length == 0)
                    return false;

                if (isAtosVendedor)
                {
                    // Vendedor tem que ter em sua "carteira" o grupo referido
                    List<Int32> list = GetIdsGruposEmpresasVendedor(token, _db);
                    return list.Any(t => idsGruposSpress.Contains(t));
                }

                Int32 idGrupo = GetIdGrupo(token, _db);
                return idsGruposSpress.Contains(idGrupo); // Usuário Não-Atos tem que estar amarrado ao grupo para ter autorização
            }
            catch
            {
                return false;
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

    }

}