using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WXFrameworkWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Filters.Add(new AuthorizeAttribute());
            // Web API configuration and services
            config.Filters.Add(new ElmahErrorAttribute());
            // Web API routes
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "rest/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
             
            config.Routes.MapHttpRoute(
               name: "ApiByAction",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
            /*
             config.Routes.MapHttpRoute(
               name: "FileApi",
               routeTemplate: "rest/{controller}/{fileName}",
               defaults: new { fileName = RouteParameter.Optional }
           );
            */
      
             
        }
    }
}
