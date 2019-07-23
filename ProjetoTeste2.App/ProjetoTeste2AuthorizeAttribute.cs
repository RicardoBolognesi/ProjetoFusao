using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjetoTeste2.App
{
    public class ProjetoTeste2AuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private List<String> _allowedroles;

        public ProjetoTeste2AuthorizeAttribute(params string[] roles)
        {
            this._allowedroles = roles.ToList();
        }

        /// <summary>
        /// Check for Authorization
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationFilterContext authorizationFilterContext)
        {
            _allowedroles = this.Roles?.Split(',')?.ToList();
            IsUserAuthorized(authorizationFilterContext);
        }

        /// <summary>
        /// Método para verificar se o usuário está autorizado ou não
        /// se sim continuar a executar a ação se não redirecionar para a página de erro
        /// </summary>
        /// <param name="filterContext"></param>
        private void IsUserAuthorized(AuthorizationFilterContext authorizationFilterContext)
        {
            bool authorize = false;
            
            if (authorizationFilterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)authorizationFilterContext.HttpContext.User.Identity;

                var userRoles = identity.Claims
                         .Where(c => c.Type == ClaimTypes.Role)
                         .Select(c => c.Value);

                if (this.Roles is null)
                {
                    authorize = true;
                }
                else
                {
                    if (_allowedroles != null)
                    {
                        foreach (var role in _allowedroles)
                        {
                            if (userRoles.Contains(role))
                            {
                                authorize = true;
                            }
                        }
                    }
                }

            }
            if (!authorize)
            {
                authorizationFilterContext.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                return;
            }
        }
    }
}
