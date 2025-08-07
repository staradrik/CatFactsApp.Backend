using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Core.Dtos.Responses
{
    public class ErrorDto
    {
        public bool IsError { get; set; } = false;
        public string? Message { get; set; }
    }
}
