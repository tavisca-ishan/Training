﻿using MVCRoleBasedSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace RoleBasedMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authenticationCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authenticationCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authenticationCookie.Value);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                // if (authTicket.UserData == "OAuth") return;
                CustomPrincipalSerializedModel serializeModel =
                  serializer.Deserialize<CustomPrincipalSerializedModel>(authTicket.UserData);
                CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                newUser.Id = serializeModel.Id;
                newUser.Title = serializeModel.Title;
                newUser.FirstName = serializeModel.FirstName;
                newUser.LastName = serializeModel.LastName;
                newUser.EmailId = serializeModel.EmailId;
                newUser.Password = serializeModel.Password;
                HttpContext.Current.User = newUser;
            }
        }
    }
}