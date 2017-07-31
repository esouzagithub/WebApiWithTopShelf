using System.Web.Http;

namespace WebApiWithTopShelf {

    [RoutePrefix(@"")]
    public class HomeController : ApiController {

        [HttpGet]
        [Route("get/")]
        public IHttpActionResult Get()
        {

            return Ok("OK");
        }
    }
}

