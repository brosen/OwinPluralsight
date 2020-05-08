using Microsoft.Owin;
using Owin;
using OwinPluralsight.Middleware;
using System.Diagnostics;

[assembly: OwinStartupAttribute(typeof(OwinPluralsight.Startup))]
namespace OwinPluralsight
{
    public partial class Startup
    {
        public static string html="<html><body>Hello World</body></html>";
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.Use<DebugMiddleware>(new DebugMiddlewareOptions());

            //delegate function below
            app.Use(async(ctx, next) => {
                await ctx.Response.WriteAsync(html); //since this is async, dont forget await so that it doesnt return until this is complete
                //response writes to response body
            }); 
        }


    }
}
