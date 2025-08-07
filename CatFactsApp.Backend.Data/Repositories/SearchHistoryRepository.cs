using CatFactsApp.Backend.Core.Entities;
using CatFactsApp.Backend.Core.IRepositories;
using CatFactsApp.Backend.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Data.Repositories
{
    public class SearchHistoryRepository : Repository<SearchHistory>, ISearchHistoryRepository
    {
        public SearchHistoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
