using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http.Headers;

namespace MyTwitchBot.TwitchApiClient
{
    public class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        public Ratelimit Ratelimit {get; set;} = new Ratelimit();
        private string ApiToken {get; set;}

        // For Unauthenticated Requests to Twitch
        public AuthenticatedHttpClientHandler () {}

        // For Authenticated Requests to Twitch
        public AuthenticatedHttpClientHandler (string apiToken)
        {
            ApiToken = apiToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync (HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (ApiToken != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ApiToken);
            return await SendRequestAsync(request, cancellationToken);
        }

        private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Throttle requests if less than half points remaining
            if (Ratelimit.Remaining / Ratelimit.Limit < 0.5)
                await Task.Delay(Ratelimit.Reset);
            var response = await base.SendAsync(request, cancellationToken);
            lock (Ratelimit)
            {
                Ratelimit = new Ratelimit(response.Headers);
            }
            return response;
        }


        
    }
}
