using CatFactsApp.Backend.Core;
using CatFactsApp.Backend.Core.IRepositories;
using CatFactsApp.Backend.Data.Context;
using CatFactsApp.Backend.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Data
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context = context;

        private ISearchHistoryRepository? _searchHistoryRepository;

        public ISearchHistoryRepository SearchHistory =>
           _searchHistoryRepository ??= new SearchHistoryRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this); // Suppression of the finalizer.
        }
    }
}
