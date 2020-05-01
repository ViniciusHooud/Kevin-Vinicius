using Refit;
using System.Threading.Tasks;
using MobileCamoes.Model;

namespace MobileCamoes.Infra.API
{
    [Headers("Content-Type: application/json")]
    public interface ITmdbApi
    {
        [Get("/tv/popular?api_key={apiKey}")]
        Task<SerieResponse> GetSerieResponseAsync(string apiKey);

        //https://api.themoviedb.org/3/genre/878?api_key=165a9354d7170ee97f890c4ada3c5327
        [Get("/genre/{genrerId}?api_key={apiKey}")]
        Task<Genrer> GetGenrerAsync(int genrerId, string apikey);
    }
}
