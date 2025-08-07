using CatFactsApp.Backend.Core.Dtos.Responses;
using CatFactsApp.Backend.Core.IServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace CatFactsApp.Backend.Business.Services
{
    public class GifService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    : IGifService
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly IConfiguration _configuration = configuration;

        public async Task<GifResponseDto> SearchGifAsync(string query)
        {
            var response = new GifResponseDto();

            try
            {
                string apiKey = _configuration["Giphy:ApiKey"] ?? "voaNIOg1u7ONPbckzWK71C48YqCOkhVP";
                string url = $"https://api.giphy.com/v1/gifs/search?api_key={apiKey}&q={Uri.EscapeDataString(query)}&limit=1";

                var client = _httpClientFactory.CreateClient();
                var result = await client.GetFromJsonAsync<GiphyApiResponse>(url);

                response.GifUrl = result?.Data?.FirstOrDefault()?.Images?.Original?.Url;
            }
            catch (Exception ex)
            {
                response.Error.IsError = true;
                response.Error.Message = ex.Message;
            }

            return response;
        }
    }

    public class GiphyApiResponse
    {
        public List<GifData>? Data { get; set; }
    }

    public class GifData
    {
        public GifImages? Images { get; set; }
    }

    public class GifImages
    {
        public GifOriginal? Original { get; set; }
    }

    public class GifOriginal
    {
        public string? Url { get; set; }
    }

}
