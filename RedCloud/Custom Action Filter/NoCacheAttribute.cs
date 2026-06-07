using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;

namespace RedCloud.Custom_Action_Filter
{
    public class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // Set response headers to prevent caching
            var headers = context.HttpContext.Response.Headers;
            headers[HeaderNames.CacheControl] = "no-cache, no-store, must-revalidate";
            headers[HeaderNames.Pragma] = "no-cache";
            headers[HeaderNames.Expires] = "0";

            base.OnResultExecuting(context);
        }





        public class AdminAuthorizationFilter : Attribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                //var UserName = context.HttpContext.Session.Get("UserName");
                var UserRoles = context.HttpContext.Session.GetString("UserRoles");
                var UserId = context.HttpContext.Session.GetInt32("UserId");
                //var Email = context.HttpContext.Session.Get("Email");
                if (UserId == 0 || UserId == null)
                {
                    context.Result = new RedirectToActionResult("Login", "Account", new { });
                }
            }
        }


        public class ResellerAuthorizationFilter : Attribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                //var UserName = context.HttpContext.Session.Get("UserName");
                var UserRoles = context.HttpContext.Session.GetString("UserRoles");
                //var UserId = context.HttpContext.Session.GetInt32("UserId");
                //var Email = context.HttpContext.Session.Get("Email");
                if (UserRoles != "Reseller Admin" || UserRoles != "Sub Admin Administrator")
                {
                    context.Result = new RedirectToActionResult("Login", "Account", new { });
                }
            }
        }


        public class OrganizatinAuthorizationFilter : Attribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {

                var UserRoles = context.HttpContext.Session.GetString("UserRoles");
                //var UserId = context.HttpContext.Session.GetInt32("UserId");
                if (UserRoles != "Organization Admin" || UserRoles != "Sub Admin Administrator")
                {
                    context.Result = new RedirectToActionResult("Login", "Account", new { });
                }
            }
        }




    }
}
