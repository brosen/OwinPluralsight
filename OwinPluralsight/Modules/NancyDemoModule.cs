using Nancy;
using Nancy.Owin;
using Nancy.Security;

namespace OwinPluralsight.Modules
{
    public class NancyDemoModule : NancyModule
    {
        public NancyDemoModule()
        {
            this.RequiresMSOwinAuthentication();

            //called everytime this path is called
            Get("/nancy", _ =>
            {
                var env = Context.GetOwinEnvironment();

                var user = Context.GetMSOwinUser();

                return "Hello from Nancy you requested: " + env["owin.RequestPathBase"] + env["owin.RequestPath"] + ". User " +user.Identity.Name;
            });
        }
    }
}