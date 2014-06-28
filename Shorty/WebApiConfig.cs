using System.Web.Http;

namespace Shorty
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Shorten",
                routeTemplate: "",
                defaults: new { controller = "Home" }
            );

            config.Routes.MapHttpRoute(
                name: "Redirect",
                routeTemplate: "{shortUrl}",
                defaults: new { controller = "Redirect" }
            );
        }
    }
}
