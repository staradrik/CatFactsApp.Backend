using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Core.Dtos.Responses
{
    public class FactWithGifResponseDto
    {
        public string? Fact { get; set; }
        public string? GifUrl { get; set; }
        public string? Query { get; set; }
        public ErrorDto Error { get; set; } = new();
    }
}
