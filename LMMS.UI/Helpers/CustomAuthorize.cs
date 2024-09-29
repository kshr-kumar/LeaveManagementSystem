﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LMMS.UI.Helpers
{
    public class CustomAuthorize : Attribute, IAuthorizationFilter
    {
        public string Roles { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           if(context.HttpContext.User.Identity.IsAuthenticated)
            {
                //check/roles/permission

                if(!context.HttpContext.User.IsInRole(Roles))
                {
                    context.Result = new RedirectToActionResult("AccessDenied", "Account", new { area = "" });
                }


            }
           else
            {
                string returnUrl = context.HttpContext.Request.Path;   
                context.Result = new RedirectToActionResult("Login", "Account", new { area = "" , ReturnUrl = returnUrl });
            }
        }
    }
}
