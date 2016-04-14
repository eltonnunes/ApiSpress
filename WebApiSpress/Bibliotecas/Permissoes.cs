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
        public static bool Autenticado(string token)
        {
            using (var _db = new painel_taxservices_dbContext()){

                _db.Configuration.ProxyCreationEnabled = false;

                var verify = _db.LoginAutenticacaos.Where(v => v.token.Equals(token)).Select(v => v).FirstOrDefault();

                if (verify != null)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// A partir do token, obtém o objeto webpages_Users correspondente
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Null se o token for inválido</returns>
        public static webpages_Users GetUser(string token)
        {
            using (var _db = new painel_taxservices_dbContext())
            {
                _db.Configuration.ProxyCreationEnabled = false;

                return _db.LoginAutenticacaos.Where(v => v.token.Equals(token))
                            .Select(v => v.webpages_Users)
                            .FirstOrDefault<webpages_Users>();
            }
            //return _db.LoginAutenticacaos.Where(v => v.token.Equals(token)).Select(v => v.webpages_Users).FirstOrDefault();
        }

        /// <summary>
        /// A partir do token, obtém o id do usuário correspondente
        /// </summary>
        /// <param name="token"></param>
        /// <returns>0 se o token for inválido</returns>
        public static Int32 GetIdUser(string token)
        {
            webpages_Users user = GetUser(token);
            if (user != null) return (Int32) user.id_users;
            return 0;
        }

        /// <summary>
        /// A partir do token, obtém o id do grupo que o usuário correspondente está associado
        /// </summary>
        /// <param name="token"></param>
        /// <returns>0 se o token for inválido ou se o usuário não estiver associado a algum grupo</returns>
        public static Int32 GetIdGrupo(string token)
        {
            webpages_Users user = GetUser(token);
            if (user != null && user.id_grupo != null) return (Int32) user.id_grupo;
            return 0;
        }

        /// <summary>
        /// A partir do token, obtém o cnpj que o usuário correspondente está associado
        /// </summary>
        /// <param name="token"></param>
        /// <returns>"" (string vazia) se o token for inválido ou se o usuário não estiver associado a alguma filial</returns>
        public static string GetCNPJEmpresa(string token)
        {
            webpages_Users user = GetUser(token);
            if (user != null && user.id_grupo != null && user.nu_cnpjEmpresa != null) return user.nu_cnpjEmpresa;
            return "";
        }

        /// <summary>
        /// A partir do token, obtém o objeto webpages_Roles que o usuário correspondente está associado
        /// </summary>
        /// <param name="token"></param>
        /// <returns>null se o token for inválido ou se o usuário não estiver associado a nenhuma role do novo portal (id > 50)</returns>
        public static webpages_Roles GetRole(string token)
        {
            webpages_Users user = GetUser(token);
            if (user != null)
            {
                using (var _db = new painel_taxservices_dbContext())
                {
                    _db.Configuration.ProxyCreationEnabled = false;
                    return _db.webpages_UsersInRoles
                                            .Where(r => r.UserId == user.id_users)
                                            .Where(r => r.RoleId > 50)
                                            .Select(r => r.webpages_Roles)
                                            .FirstOrDefault();
                }
            }
            return null;
        }

        /// <summary>
        /// A partir do token, obtém o id da role que o usuário correspondente está associado 
        /// </summary>
        /// <param name="token"></param>
        /// <returns>0 se o token for inválido ou se o usuário não estiver associado a nenhuma role do novo portal (id > 50)</returns>
        public static Int32 GetRoleId(string token)
        {
            webpages_Roles role = GetRole(token);
            if (role != null) return role.RoleId;
            return 0;
        }

        /// <summary>
        /// A partir do token, obtém o nome da role que o usuário correspondente está associado 
        /// </summary>
        /// <param name="token"></param>
        /// <returns>"" (string vazia) se o token for inválido ou se o usuário não estiver associado a nenhuma role do novo portal (id > 50)</returns>
        public static String GetRoleName(string token)
        {
            webpages_Roles role = GetRole(token);
            if (role != null) return role.RoleName;
            return "";
        }

        /// <summary>
        /// A partir do token, obtém o nível da role que o usuário correspondente está associado 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Int32 GetRoleLevel(string token)
        {
            webpages_Roles role = GetRole(token);
            if (role != null) return role.RoleLevel;
            return 4;
        }

        /// <summary>
        /// A partir do token, obtém o valor mínimo de nível de role a partir do privilégio que o usuário está associado
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Int32 GetRoleLevelMin(string token)
        {
            Int32 RoleLevel = GetRoleLevel(token);
            if (RoleLevel > 1) return RoleLevel + 1;
            return RoleLevel;
        }

        /// <summary>
        /// Retorna true se o a role associada ao usuário é de um perfil da ATOS
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool isAtosRole(string token)
        {
            Int32 RoleLevel = GetRoleLevel(token);
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
        public static bool isAtosRoleVendedor(string token)
        {
            string RoleName = GetRoleName(token);
            return isAtosRole(token) && RoleName.ToUpper().Equals("COMERCIAL");
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
        public static List<Int32> GetIdsGruposEmpresasVendedor(string token)
        {
            List<Int32> lista = new List<Int32>();
 
            Int32 UserId = GetIdUser(token);

            using (var _db = new painel_taxservices_dbContext())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                lista = _db.grupo_empresa
                        .Where(g => g.id_vendedor == UserId)
                        .Select(g => g.id_grupo)
                        .ToList<Int32>();

                return lista;
            }
        }

        /// <summary>
        /// A partir da descrição do método e do id do controller, obtém o id o método
        /// </summary>
        /// <param name="idController"></param>
        /// <param name="ds_method"></param>
        /// <returns>0 se o método não existe para o controller</returns>
        public static Int32 GetIdMethod(Int32 idController, string ds_method)
        {
            Int32 idMethod = 0;

            using (var _db = new painel_taxservices_dbContext())
            {
                _db.Configuration.ProxyCreationEnabled = false;

                var method = _db.webpages_Methods.Where(m => m.id_controller == idController)
                                                 .Where(m => m.ds_method.ToUpper().Equals(ds_method.ToUpper()))
                                                 .FirstOrDefault();

                if (method != null)
                    idMethod = method.id_method;

                return idMethod;
            }
        }

        /// <summary>
        /// Retorna o id do último controller (tela) acessado pelo usuário
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Int32 GetIdUltimoControllerAcessado(string token)
        {
            Int32 UserId = GetIdUser(token);

            if (UserId == 0) return 0;

            using (var _db = new painel_taxservices_dbContext())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                return _db.LogAcesso1
                            .Where(e => e.idUsers == UserId)
                            .OrderByDescending(e => e.dtAcesso)
                            .Select(e => e.idController ?? 0)
                            .FirstOrDefault();
            }
        }


        /// <summary>
        /// Retorna true se o usuário com o token informado possui permissão para o controller
        /// </summary>
        /// <param name="token"></param>
        /// <param name="idController"></param>
        /// <returns></returns>
        public static bool usuarioTemPermissaoController(string token, Int32 idController)
        {
            Int32 idRole = GetRoleId(token);
            if (idRole == 0) return false;

            using (var _db = new painel_taxservices_dbContext())
            {
                _db.Configuration.ProxyCreationEnabled = false;

                return _db.webpages_Permissions.Where(p => p.id_roles == idRole)
                                               .Where(p => p.webpages_Methods.id_controller == idController)
                                               .Count() > 0;
            }
        }


        /// <summary>
        /// Retorna true se o usuário com o token informado possui permissão para o método do controller
        /// </summary>
        /// <param name="token"></param>
        /// <param name="idController"></param>
        /// <returns></returns>
        public static bool usuarioTemPermissaoMetodoController(string token, Int32 idController, string metodo)
        {
            Int32 idRole = GetRoleId(token);
            if (idRole == 0) return false;

            using (var _db = new painel_taxservices_dbContext())
            {
                _db.Configuration.ProxyCreationEnabled = false;

                metodo = metodo.ToLower();

                return _db.webpages_Permissions.Where(p => p.id_roles == idRole)
                                               .Where(p => p.webpages_Methods.id_controller == idController)
                                               .Where(p => p.webpages_Methods.ds_method.ToLower().Equals(metodo))
                                               .Count() > 0;
            }
        }

        /// <summary>
        /// Retorna true se o usuário pode se associar ao grupo informado
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id_grupo"></param>
        /// <returns></returns>
        public static Boolean usuarioPodeSeAssociarAoGrupo(string token, Int32 id_grupo)
        {
            bool isAtosVendedor = isAtosRoleVendedor(token);

            // Perfil ATOS não vendedor pode se associar a qualquer grupo
            if (isAtosRole(token) && !isAtosVendedor) return true;

            // Perfil ATOS vendedor pode se associar aos grupos de sua "carteira"
            if (isAtosVendedor)
            {
                List<Int32> list = GetIdsGruposEmpresasVendedor(token);
                return list.Contains(id_grupo);
            }

            // Qualquer outro privilégio não pode mudar de grupo
            return false;
        }

        /// <summary>
        /// Retorna o Id do grupo "Otica Santana"
        /// </summary>
        /// <returns></returns>
        public static Int32 GetIdOticaSantana()
        {
            using (var _db = new painel_taxservices_dbContext())
            {
                grupo_empresa grupoOticaSantana = _db.grupo_empresa.Where(e => e.ds_nome.StartsWith("OTICASANTANA")).FirstOrDefault();
                if (grupoOticaSantana == null) return 0;
                return grupoOticaSantana.id_grupo;
            }
        }

        /// <summary>
        /// Retorna true se o grupo que o usuário está associado é a Otica Santana
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool isIdGrupoOticaSantana(string token)
        {
            Int32 IdGrupo = GetIdGrupo(token);
            return IdGrupo > 0 && IdGrupo == GetIdOticaSantana();
        }

        /// <summary>
        /// Retorna true se o usuário tem permissão para se associar ao grupo "Otica Santana"
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool usuarioTemPermissaoAssociarOticaSantana(string token)
        {
            bool isAtosVendedor = Permissoes.isAtosRoleVendedor(token);

            // Usuário ATOS que não é vendedor tem permissão
            if (isAtosRole(token) && !isAtosVendedor) return true;

            if (isAtosVendedor)
            {
                // Vendedor tem que ter em sua "carteira" o grupo referido
                Int32 idGrupoOticaSantana = GetIdOticaSantana();
                if (idGrupoOticaSantana == 0) return false;
                using (var _db = new painel_taxservices_dbContext())
                {
                    List<Int32> list = GetIdsGruposEmpresasVendedor(token);
                    return list.Contains(idGrupoOticaSantana);
                }
            }
            else return isIdGrupoOticaSantana(token); // Usuário Não-Atos tem que estar amarrado ao grupo para ter autorização
        }
    }

}