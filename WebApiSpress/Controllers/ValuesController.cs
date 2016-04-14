using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApiSpress.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public  HttpResponseMessage Get()
        {
            var userAgent = HttpContext.Current.Request.UserAgent;
            var userBrowser = new HttpBrowserCapabilities { Capabilities = new Hashtable { { string.Empty, userAgent } } };
            System.Web.HttpBrowserCapabilities myBrowserCaps = userBrowser;

            return Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.OK, new string[] { HttpContext.Current.Request.UserHostAddress, ((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice.ToString(), Request.Headers.UserAgent.ToString() });
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var userAgent = HttpContext.Current.Request.UserAgent;
            var userBrowser = new HttpBrowserCapabilities { Capabilities = new Hashtable { { string.Empty, userAgent } } };

            //HttpContext.Current.Request.UserHostAddress

            return Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.OK, new string[] { HttpContext.Current.Request.UserHostAddress });
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]dynamic value)
        {
            return Request.CreateResponse<Int32>(HttpStatusCode.OK, 100);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]dynamic value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}