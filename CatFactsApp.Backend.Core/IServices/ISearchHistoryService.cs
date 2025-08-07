using CatFactsApp.Backend.Core.Dtos.Responses;
using CatFactsApp.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Core.IServices
{
    public interface ISearchHistoryService
    {
        Task<SearchHistoryResponseDto> GetAllHistoryAsync();
        Task AddSearchHistoryAsync(SearchHistory history);
    }
}
