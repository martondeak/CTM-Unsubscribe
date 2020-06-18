using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;

namespace AspNetCoreWebApplication.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {            
            ViewData["Message"] = "We've encountered an error :(";

            return View();
        }

        public IActionResult Unsub()
        {
            return View();
        }

        public IActionResult Submit(string id)
        {
            string postData = id;

            WebRequest request = WebRequest.Create("https://whitepapers.theregister.com/leads_admin/dnc/email/?f=json&email=" + postData);
            
            request.Method = "POST"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Credentials = new NetworkCredential("ctm_dnc", "jXG9a5yZV2QExvuJn7N7");
            request.ContentLength = byteArray.Length;
              
            Stream dataStream = request.GetRequestStream();            
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);            
            
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);             
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
             
            reader.Close();
            dataStream.Close();
            response.Close();

            ViewBag.Response = responseFromServer;

            return View();
            
            //curl - svkX POST - d 'f=json&email=foo3@bar.com' - u ctm_dnc: jXG9a5yZV2QExvuJn7N7 https://whitepapers.theregister.com/leads_admin/dnc/email                              
        }
    }
}
