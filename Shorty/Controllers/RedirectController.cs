using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceStack.Redis;

namespace Shorty.Controllers
{
    public class RedirectController : ApiController
    {
        public HttpResponseMessage Get(string shortUrl)
        {
            using (var client = new RedisClient())
            {
                var stringClient = client.As<string>();
                var expandedUrl = stringClient.GetValue(shortUrl);
                var response = Request.CreateResponse(HttpStatusCode.Moved);
                response.Headers.Location = new Uri(expandedUrl);
                return response;
            }
        }
    }
}