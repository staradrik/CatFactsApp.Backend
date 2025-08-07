using CatFactsApp.Backend.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ISearchHistoryRepository SearchHistory { get; }
    }
}
