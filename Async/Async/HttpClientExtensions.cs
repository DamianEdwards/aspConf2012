using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    public static class HttpClientExtensions
    {
        public static async Task<string> GetStringAsync(this HttpClient client, string requestUri, CancellationToken cancellationToken)
        {
            var result = await client.GetAsync(requestUri, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
            return await result.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}