using ServiceStack.Redis;
using Shorty.Models;
using System.Web.Http;

namespace Shorty.Controllers
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Post(LongUrlModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // prevent a redirect loop, basically.
            var hostAddress = Request.RequestUri.ToString().TrimEnd('/');
            if (model.LongUrl.StartsWith(hostAddress))
            {
                ModelState.AddModelError("", "This URL cannot be shortened. Please try another one.");
                return BadRequest(ModelState);
            }

            using (var client = new RedisClient())
            {
                var stringClient = client.As<string>();
                var index = stringClient.GetNextSequence();
                var absolouteIdentifier = IdentifierGenerator.Encode((int)index);
                stringClient.SetEntry(absolouteIdentifier, model.LongUrl);

                return Ok(new { absolouteIdentifier });
            }
        }
    }
}