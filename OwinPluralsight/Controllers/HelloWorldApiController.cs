using System.Web.Http;

namespace OwinPluralsight.Controllers
{
    [RoutePrefix("api")]  //needs to start with api to be considered
    public class HelloWorldApiController : ApiController
    {
        [Route("hello")]
        [HttpGet]
        public IHttpActionResult HellowWorld()
        {
            return Content(System.Net.HttpStatusCode.OK, "Hello from Web Api");
        }
    }
}