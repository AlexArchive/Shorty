using ServiceStack.Redis;
using Shorty.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shorty.Controllers
{
    public class HomeController : ApiController
    {
        public HttpResponseMessage Post(LongUrlModel model)
        {
            if (ModelState.IsValid)
            {
                var thisDomainName = Request.RequestUri.ToString().TrimEnd('/');
                if (model.LongUrl.StartsWith(thisDomainName))
                {
                    ModelState.AddModelError("", "This URL cannot be shortened. Please try another one.");
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                using (var client = new RedisClient())
                {
                    var stringClient = client.As<string>();
                    var index = stringClient.GetNextSequence();
                    var absolouteIdentifier = IdentifierGenerator.Encode((int) index);
                    stringClient.SetEntry(absolouteIdentifier, model.LongUrl);
                    return Request.CreateResponse(HttpStatusCode.OK, new { absolouteIdentifier });
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}