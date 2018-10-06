// Copyright (C) 2016 by Barend Erasmus, David Jeske and donated to the public domain

using SimpleHttpServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpServer.RouteHandlers
{
    public class XMLRouteHandler
    {

        public string BasePath { get; set; }
        public bool ShowDirectories { get; set; }

        public HttpResponse XMLHandle(HttpRequest request)
        {
            string s = request.Content;
            Console.WriteLine(s);
            s = s.Replace("\r", String.Empty);
            Console.WriteLine(string.Format("0x0D index: {0}", s.IndexOf('\r')));
            Console.WriteLine(string.Format("0x0A index: {0}", s.IndexOf('\n')));


            Encoding gbk = Encoding.GetEncoding("GBK");
            string gbks = HttpResponse.utf8ToGBK(s);
            File.WriteAllBytes(@"D:\x.txt", gbk.GetBytes(gbks));


            return new HttpResponse
            {
                StatusCode = "200",
                ReasonPhrase = string.Format("OK"),
                ContentAsUTF8 = s
            };
        }
    }
}
