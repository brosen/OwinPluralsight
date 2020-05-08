using Microsoft.Owin;
using Owin;
using OwinPluralsight.Middleware;
using System.Diagnostics;
using Nancy.Owin;
using Nancy;
using System.Web.Http;

//[assembly: OwinStartupAttribute(typeof(OwinPluralsight.Startup))]
namespace OwinPluralsight
{
    public partial class Startup
    {
        public static string html="<html><body>Hello World</body></html>";
        public void Configuration(IAppBuilder app)
        {
            app.UseDebugMiddleware(new DebugMiddlewareOptions
            {
                OnIncomingRequest = (ctx) =>
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    ctx.Environment["DebugStopWatch"] = watch;
                },
                OnOutgoingRequest = (ctx) =>
                {
                    var watch = (Stopwatch)ctx.Environment["DebugStopWatch"];
                    watch.Stop();
                    Debug.WriteLine("Request took " + watch.ElapsedMilliseconds + " ms");
                }
            });

            //below not working???
           // var config = new HttpConfiguration();
            //config.MapHttpAttributeRoutes(); //look for routes in the application and map them like the one in hello world

            /*
             gets to nancy, config set to bypass nancy when path not found
             */
            app.UseNancy(conf =>
            {
                conf.PassThroughWhenStatusCodesAre(HttpStatusCode.NotFound);
            });

            //delegate function below
            //app.Use(async (ctx, next) =>
            //{
            //    await ctx.Response.WriteAsync(html); //since this is async, dont forget await so that it doesnt return until this is complete
            //    //response writes to response body
            //});
        }


    }
}
