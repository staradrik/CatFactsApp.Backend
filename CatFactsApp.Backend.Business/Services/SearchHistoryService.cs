using AutoMapper;
using CatFactsApp.Backend.Core;
using CatFactsApp.Backend.Core.Dtos;
using CatFactsApp.Backend.Core.Dtos.Responses;
using CatFactsApp.Backend.Core.Entities;
using CatFactsApp.Backend.Core.IRepositories;
using CatFactsApp.Backend.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Business.Services
{
    public class SearchHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
    : ISearchHistoryService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<SearchHistoryResponseDto> GetAllHistoryAsync()
        {
            var response = new SearchHistoryResponseDto();

            try
            {
                var histories = await _unitOfWork.SearchHistory.GetAllAsync();
                response.History = _mapper.Map<List<SearchHistoryDto>>(histories);
            }
            catch (Exception ex)
            {
                response.Error.IsError = true;
                response.Error.Message = ex.Message;
            }

            return response;
        }

        public async Task AddSearchHistoryAsync(SearchHistory history)
        {
            await _unitOfWork.SearchHistory.AddAsync(history);
            await _unitOfWork.SearchHistory.SaveChangesAsync();
        }
    }

}
