using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AkkaStudy02
{
    public class DownloadHtmlActor : ReceiveActor
    {
        public DownloadHtmlActor()
        {
            ReceiveAsync<string>(async url => await GetPageHtmlAsync(url));
        }

        private async Task GetPageHtmlAsync(string url)
        {
            var html = await new WebClient().DownloadStringTaskAsync(url);
            Console.WriteLine("\n===========================");
            Console.WriteLine($"Data for {url}");
            Console.WriteLine(html.Trim().Substring(0, 100));
        }
    }
}
