using AutoMapper;
using CatFactsApp.Backend.Core.Dtos;
using CatFactsApp.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CatFactsApp.Backend.Core.Configurations.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SearchHistoryDto, SearchHistory>().ReverseMap();
        }
    }
}
