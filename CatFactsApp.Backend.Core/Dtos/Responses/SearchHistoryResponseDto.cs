using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Core.Dtos.Responses
{
    public class SearchHistoryResponseDto
    {
        public List<SearchHistoryDto> History { get; set; } = new();
        public ErrorDto Error { get; set; } = new();
    }
}
