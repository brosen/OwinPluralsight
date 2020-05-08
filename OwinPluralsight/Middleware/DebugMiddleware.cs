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
        public DebugMiddleware(AppFunc next) //takes one param to constructor
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var ctx = new OwinContext(env);
            Debug.WriteLine("Incoming request: " + ctx.Request.Path);
            await _next(env); 
            Debug.WriteLine("Outgoing request: " + ctx.Request.Path);
        }
    }
}