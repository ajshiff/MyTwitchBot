using System;
using System.Net.Http;

namespace MyTwitchBot.TwitchApiClient
{
    public class TwitchApiClient
    {
        private HttpClient _client {get; set;}
        
        // For Accessing Twitch API Unauthenticated
        public TwitchApiClient ()
        {
            InitializeRestServices();
        }

        // For accessing the Twitch API with a BEARER Token
        public TwitchApiClient (string apiToken)
        {
            SetupAuthenHttpClientHandler(apiToken);
            InitializeRestServices();
        }

        private void SetupAuthenHttpClientHandler (string apiToken)
        {
            var handler = new AuthenticatedHttpClientHandler(apiToken);
            _client = new HttpClient(handler);
        }

        private void InitializeRestServices ()
        {

        }

    }
}
