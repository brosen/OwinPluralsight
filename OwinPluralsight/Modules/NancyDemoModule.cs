using Nancy;
using Nancy.Owin;

namespace OwinPluralsight.Modules
{
    public class NancyDemoModule : NancyModule
    {
        public NancyDemoModule()
        {
            //called everytime this path is called
            Get("/nancy", _ =>
            {
                var env = Context.GetOwinEnvironment();
                return "Hello from Nancy you requested: " + env["owin.RequestPathBase"] + env["owin.RequestPath"];
            });
        }
    }
}