using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppFunc = System.Func<  //dont have to declare it like this, just easier that constantly writing Func all over
    System.Collections.Generic.IDictionary<string, object>,
    System.Threading.Tasks.Task
 >;

namespace OwinPluralsight.Middleware
{
    public class DebugMiddleware
    {
        AppFunc _next;
        DebugMiddlewareOptions _options;
        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
        {
            _next = next;
            _options = options;

            if (_options.OnIncomingRequest == null) //since coming from outside, do a null check
            {
                _options.OnIncomingRequest = (ctx) => { Debug.WriteLine("Incoming request: " + ctx.Request.Path); };
            }

            if (_options.OnOutgoingRequest == null) 
            {
                _options.OnOutgoingRequest = (ctx) => { Debug.WriteLine("Outgoing request: " + ctx.Request.Path); };
            }
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var ctx = new OwinContext(env);
            _options.OnIncomingRequest(ctx);
            await _next(env);
            _options.OnOutgoingRequest(ctx);
        }
    }
}