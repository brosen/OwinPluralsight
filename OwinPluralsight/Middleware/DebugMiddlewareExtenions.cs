using OwinPluralsight.Middleware;

namespace Owin //<- easier to find
{
    public static class DebugMiddlewareExtenions
    {
        public static void UseDebugMiddleware(this IAppBuilder app, DebugMiddlewareOptions options = null)
        {
            if (options == null)
            {
                options = new DebugMiddlewareOptions();
            }

            app.Use<DebugMiddleware>(options);
        }
    }
}