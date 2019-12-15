using Refit;
using System.Threading.Tasks;

namespace MyTwitchBot.TwitchApiClient.TwitchApiEndpoints
{
    public interface IStreamsApi
    {
        [Get("/helix/streams")]
        Task<object> GetStreams();
    }   
}