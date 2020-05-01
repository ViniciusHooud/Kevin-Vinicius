using MobileCamoes.Infra;
using MobileCamoes.Infra.API;
using MobileCamoes.Infra.Repository;
using MobileCamoes.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileCamoes.Services
{
    public class SerieService : ISerieService
    {
        readonly ITmdbApi _api;
        readonly ISerieRepository _serieRepository;

        public SerieService(ITmdbApi api, ISerieRepository serieRepository)
        {
            _api = api;
            _serieRepository = serieRepository;
        }

        public async Task<SerieResponse> GetSeriesAsync()
        {
            SerieResponse result = new SerieResponse();

            ////var seriesLocais = _serieRepository.Get();
            //if(seriesLocais.Any())
            //{
            //    result.Series = seriesLocais; 
            //}
            //else
            //{

                #region Exemplo com httpClient
                //HttpClient httpClient = new HttpClient();
                //httpClient.BaseAddress = new System.Uri("https://api.themoviedb.org");
                //using (var response = await httpClient.GetAsync("/3/tv/popular?api_key=165a9354d7170ee97f890c4ada3c5327"))
                //{
                //    if (response.StatusCode == HttpStatusCode.OK)
                //    {
                //        var content = await response.Content.ReadAsStreamAsync();
                //        using (StreamReader reader = new StreamReader(content))
                //        {
                //            var restorno = reader.ReadToEnd();
                //            result = JsonConvert.DeserializeObject<SerieResponse>(restorno);
                //        }

                //    }
                //}
                #endregion

                result = await _api.GetSerieResponseAsync(AppSettings.ApiKey);

                //result?.Series.ToList().ForEach(item => _serieRepository.Add(item));

                //if (result != null)
                //{
                //    foreach (Serie item in result.Series)
                //    {
                //        _serieRepository.Add(item);
                //    }
                //}
            //}

            return result;
        }
    
        public async Task<Genrer> GetGenrerAsync(int id)
        {
            return await _api.GetGenrerAsync(id, AppSettings.ApiKey);
        }
    }
}
