using CatFactsApp.Backend.Core.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Core.IServices
{
    public interface IGifService
    {
        Task<GifResponseDto> SearchGifAsync(string query);
    }
}
