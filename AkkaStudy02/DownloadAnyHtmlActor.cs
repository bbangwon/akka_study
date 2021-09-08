using Akka.Actor;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AkkaStudy02
{
    public class DownloadAnyHtmlActor : ReceiveActor
    {
        public DownloadAnyHtmlActor()
        {
            ReceiveAnyAsync(async obj => await GetPageHtmlAsync(obj));
        }

        private async Task GetPageHtmlAsync(object obj)
        {
            if (obj is string || obj is Uri)
            {
                var url = obj.ToString();
                var html = await new WebClient().DownloadStringTaskAsync(url);

                Console.WriteLine("\n=========================");
                Console.WriteLine($"Data for {url}");
                Console.WriteLine(html.Trim().Substring(0, 100));
            }
            else
                throw new ArgumentNullException("Actor doesn't accept this kind of message");
        }
    }
}
