using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WineCorp.Dom;
using WineCorp.Dom.Entities;
using WineCorp.Dto;
using WineCorp.Infrastructure.Context;

namespace WineCorp.Infrastructure.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly WineCorpDbContext _context;
        public ManagerRepository(WineCorpDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<IEnumerable<int>> GetManagersIdsAsync()
        {
            
            return await _context.Managers
                .OrderBy(m => m.Id) 
                .Select(m => m.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetManagersTaxNumbersOrderedByNameAsync(Expression<Func<Manager, object>> orderBy, SortOrder order)
        {
            IQueryable<Manager> query = _context.Managers;

            if(order != SortOrder.None)
            {
                query = order == SortOrder.Ascending
                ? query.OrderBy(orderBy)
                : query.OrderByDescending(orderBy);
            }
            return await query
                .Select(m => m.TaxNumber)
                .ToListAsync();


        }
    }
}
