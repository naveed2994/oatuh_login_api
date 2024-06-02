using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Test_Api.Helper.Enums;

namespace Test_Api.Helper
{
    public class AuthorizeRoles : TypeFilterAttribute
    {



        public AuthorizeRoles(params RoleType[] roles)
            : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { roles };
        }

    }

    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly IHttpContextAccessor httpContextAccessor;


        private readonly List<RoleType> Roles;
        public AuthorizeActionFilter(RoleType[] roles, IHttpContextAccessor? httpContextAccessor)
        {
            Roles = roles.ToList();
            this.httpContextAccessor = httpContextAccessor;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.GetTokenAsync("access_token").Result;

            if (!string.IsNullOrEmpty(token))
            {

                var role = context.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).First().Value;
                var roles = new List<string>();

                RoleType type = (RoleType)Enum.Parse(typeof(RoleType), role);
                if (!Roles.Contains(type))
                {
                    context.Result = new ObjectResult(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                     { "controller", "Game" },
                     { "action", "Unauthorized" }
                });

            }
        }

    }

}
