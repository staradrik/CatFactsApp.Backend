using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Core.Entities
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public DateTime SearchDate { get; set; }
        public string? CatFact { get; set; }
        public string? Query { get; set; }
        public string? GifUrl { get; set; }
    }
}
