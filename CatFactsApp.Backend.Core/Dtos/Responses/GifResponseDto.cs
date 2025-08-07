using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Core.Dtos.Responses
{
    public class GifResponseDto
    {
        public string? GifUrl { get; set; }
        public ErrorDto Error { get; set; } = new();
    }
}
