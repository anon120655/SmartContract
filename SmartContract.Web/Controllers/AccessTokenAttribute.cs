using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartContract.Web.Controllers
{
    public class AccessTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var accesstoken = context.HttpContext.Session.GetString("username");
            var rolecode = context.HttpContext.Session.GetString("rolecode");
            var subdomainserver = context.HttpContext.Session.GetString("subdomainserver");
            String pathSub = subdomainserver != null ? subdomainserver : String.Empty;

            string actionName = (string)context.RouteData.Values["Action"];
            string controllerName = (string)context.RouteData.Values["Controller"];
            Enum.TryParse(rolecode, out PermissionRole userRoleCode);

            if ((controllerName.ToLowerInvariant() == "home" ||
                 controllerName.ToLowerInvariant() == "contracttype") 
                && GroupRoles.GroupRoleUnit.Contains(userRoleCode))
            {
                String message = "ไม่มีสิทธิ์เข้าใช้งาน";
                context.Result = new RedirectResult($"{pathSub}/Authorize/SystemNoti?message={message}");
                return;
            }

            if ((controllerName.ToLowerInvariant() == "homevendor" ||
                 controllerName.ToLowerInvariant() == "contracttypevendor")
                && GroupRoles.GroupRoleAdmin.Contains(userRoleCode))
            {
                String message = "ไม่มีสิทธิ์เข้าใช้งาน";
                context.Result = new RedirectResult($"{pathSub}/Authorize/SystemNoti?message={message}");
                return;
            }


            if (string.IsNullOrWhiteSpace(accesstoken))
            {                
                context.Result = new RedirectResult($"{pathSub}/Authorize/LogOut");
                return;
            }

        }
    }
}
