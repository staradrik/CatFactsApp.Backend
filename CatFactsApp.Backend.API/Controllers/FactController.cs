using CatFactsApp.Backend.Core.Dtos.Responses;
using CatFactsApp.Backend.Core.Entities;
using CatFactsApp.Backend.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CatFactsApp.Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactController : ControllerBase
    {
        private readonly ICatFactService _catFactService;
        private readonly IGifService _gifService;
        private readonly ISearchHistoryService _historyService;

        public FactController(
            ICatFactService catFactService,
            IGifService gifService,
            ISearchHistoryService historyService)
        {
            _catFactService = catFactService;
            _gifService = gifService;
            _historyService = historyService;
        }

        /// <summary>
        /// Retorna un dato aleatorio desde catfact.ninja
        /// GET: /api/fact
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<CatFactResponseDto>> GetCatFact()
        {
            var result = await _catFactService.GetRandomCatFactAsync();
            return result.Error.IsError ? BadRequest(result) : Ok(result);
        }

        /// <summary>
        /// Retorna un GIF relacionado con la query proporcionada
        /// GET: /api/fact/gif?query=...
        /// </summary>
        [HttpGet("gif")]
        public async Task<ActionResult<GifResponseDto>> GetGif([FromQuery] string? query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest(new { error = "Query is required." });

            var result = await _gifService.SearchGifAsync(query);
            return result.Error.IsError ? BadRequest(result) : Ok(result);
        }

        /// <summary>
        /// Retorna historial completo de búsquedas guardadas
        /// GET: /api/fact/history
        /// </summary>
        [HttpGet("history")]
        public async Task<ActionResult<SearchHistoryResponseDto>> GetHistory()
        {
            var result = await _historyService.GetAllHistoryAsync();
            return result.Error.IsError ? StatusCode(500, result) : Ok(result);
        }

        /// <summary>
        /// Retorna un fact + gif y guarda el historial
        /// GET: /api/fact/with-gif
        /// </summary>
        [HttpGet("with-gif")]
        public async Task<ActionResult<FactWithGifResponseDto>> GetFactWithGif()
        {
            var result = await _catFactService.GetFactWithGifAsync();
            return result.Error.IsError ? StatusCode(500, result) : Ok(result);
        }
    }

}
