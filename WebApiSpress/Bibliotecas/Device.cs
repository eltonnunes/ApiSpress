using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApiSpress.Bibliotecas
{
    public class Device
    {
        public static Boolean IsMobile()
        {
            var userAgent = HttpContext.Current.Request.UserAgent;
            if (userAgent == null)
                return false;

            if (userAgent.Contains("Mobile"))
                return true;
            else
                return false;



            /*//Console.WriteLine(HttpContext.Current.Request.UserHostAddress);
            var userBrowser = new HttpBrowserCapabilities { Capabilities = new Hashtable { { string.Empty, userAgent } } };
            //var factory = new BrowserCapabilitiesFactory();
            //factory.ConfigureBrowserCapabilities(new NameValueCollection(), userBrowser);

            System.Web.HttpBrowserCapabilities myBrowserCaps = userBrowser;
            if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
                return true;
            else
                return false;*/
        }

        public static object Info()
        {
            object dados = new object();
            var Request = HttpContext.Current.Request;

            dados = new
            {
                UserAgente = Request.UserAgent,
                Plataforma = Request.Browser.Platform,
                Browser = Request.Browser.Browser,
                Versao = Request.Browser.Version,
                MobileDeviceModel = Request.Browser.MobileDeviceModel,
                MobileDeviceManufacturer = Request.Browser.MobileDeviceManufacturer,
                IsMobileDevice = Request.Browser.IsMobileDevice

            };


            return JsonConvert.SerializeObject(dados);
        }
    }
}