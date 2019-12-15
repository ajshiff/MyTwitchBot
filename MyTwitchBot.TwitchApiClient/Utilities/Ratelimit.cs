using System.Linq;
using System.Net.Http.Headers;

namespace MyTwitchBot.TwitchApiClient
{
    public class Ratelimit
    {
        public float Limit {get; set;} = 30;
        public float Remaining {get; set;} = 30;
        public int Reset {get; set;} = 1000;
        private const string LimitString = "Ratelimit-Limit";
        private const string RemainingString = "Ratelimit-Remaining";
        private const string ResetString = "Ratelimit-Reset";

        // Used to write custom-values. Good for mocking.
        public Ratelimit ()
        {
            
        }

        // Used to abstract the parsing logic behind grabbing values
        public Ratelimit (HttpResponseHeaders headers)
        {
            if (headers.Contains(LimitString))
            {
                float.TryParse(headers.GetValues(LimitString).FirstOrDefault(), out float value);
                Limit = value;
            }
            if (headers.Contains(RemainingString))
            {
                float.TryParse(headers.GetValues(RemainingString).FirstOrDefault(), out float value);
                Remaining = value;
            }
            if (headers.Contains(ResetString))
            {
                int.TryParse(headers.GetValues(ResetString).FirstOrDefault(), out int value);
                Reset = value;
            }
        }
    }
}