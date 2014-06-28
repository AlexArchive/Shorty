using ServiceStack.Redis;
using Shorty.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shorty.Controllers
{
    public class HomeController : ApiController
    {
        public HttpResponseMessage Post(LongUrl model)
        {
            using (var client = new RedisClient())
            {
                var stringClient = client.As<string>();
                var index = stringClient.GetNextSequence();
                var absolouteIdentifier = IdentifierGenerator.Encode((int) index);
                stringClient.SetEntry(absolouteIdentifier, model.UrlToShorten);
                return Request.CreateResponse(HttpStatusCode.OK, new { absolouteIdentifier });
            }
        }
    }
}