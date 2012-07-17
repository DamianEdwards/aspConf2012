using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Async
{
    public class DownloadTheWeb : HttpTaskAsyncHandler
    {
        public async override Task ProcessRequestAsync(HttpContext context)
        {
            using (var client = new HttpClient())
            {
                // Download and write twitter.com to the response
                var twitter = await client.GetStringAsync("http://twitter.com", context.Request.TimedOutToken);
                context.Response.Write(twitter);

                // Start flushing the content buffered so far to the client
                var flushTask = context.Response.FlushAsync();

                // Start download from bing.com
                var bingTask = client.GetStringAsync("http://bing.com", context.Request.TimedOutToken);
                
                // Wait for outstanding async work
                await Task.WhenAll(flushTask, bingTask);

                // Now write out the bing result, ASP.NET will async flush this automatically as it's the last write
                context.Response.Write(bingTask.Result);
            }
        }
    }

    public static class ResponseExtensions
    {
        public static Task FlushAsync(this HttpResponse response)
        {
            if (response.SupportsAsyncFlush)
            {
                return Task.Factory.FromAsync(response.BeginFlush, response.EndFlush, null);
            }
            response.Flush();
            return Task.FromResult(0);
        }
    }
}