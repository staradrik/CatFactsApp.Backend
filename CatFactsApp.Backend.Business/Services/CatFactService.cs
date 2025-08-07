using CatFactsApp.Backend.Core.Dtos.Responses;
using CatFactsApp.Backend.Core.Entities;
using CatFactsApp.Backend.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Business.Services
{
    public class CatFactService(IHttpClientFactory httpClientFactory, IGifService gifService, ISearchHistoryService historyService)
    : ICatFactService
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly IGifService _gifService = gifService;
        private readonly ISearchHistoryService _historyService = historyService;

        public async Task<CatFactResponseDto> GetRandomCatFactAsync()
        {
            var response = new CatFactResponseDto();

            try
            {
                var client = _httpClientFactory.CreateClient();
                var result = await client.GetFromJsonAsync<CatFactApiResponse>("https://catfact.ninja/fact");

                response.Fact = result?.Fact;
            }
            catch (Exception ex)
            {
                response.Error.IsError = true;
                response.Error.Message = ex.Message;
            }

            return response;
        }

        public async Task<FactWithGifResponseDto> GetFactWithGifAsync()
        {
            var result = new FactWithGifResponseDto();

            try
            {
                var factResult = await GetRandomCatFactAsync();
                if (factResult.Error.IsError || string.IsNullOrWhiteSpace(factResult.Fact))
                    return new FactWithGifResponseDto { Error = factResult.Error };

                result.Fact = factResult.Fact;

                var query = string.Join(' ', factResult.Fact.Split(' ', StringSplitOptions.RemoveEmptyEntries).Take(3));
                result.Query = query;

                var gifResult = await _gifService.SearchGifAsync(query);
                if (gifResult.Error.IsError || string.IsNullOrWhiteSpace(gifResult.GifUrl))
                    return new FactWithGifResponseDto { Error = gifResult.Error };

                result.GifUrl = gifResult.GifUrl;

                await _historyService.AddSearchHistoryAsync(new SearchHistory
                {
                    CatFact = result.Fact,
                    GifUrl = result.GifUrl,
                    Query = result.Query,
                    SearchDate = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                result.Error.IsError = true;
                result.Error.Message = ex.Message;
            }

            return result;
        }
    }

    public class CatFactApiResponse
    {
        public string? Fact { get; set; }
        public int Length { get; set; }
    }
}
