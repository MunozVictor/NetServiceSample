using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WineCorp.Dom.Entities;
using WineCorp.Dto;

namespace WineCorp.Dom
{
    public interface IManagerRepository
    {
        Task<IEnumerable<int>> GetManagersIdsAsync();
        Task<IEnumerable<string>> GetManagersTaxNumbersOrderedByNameAsync(Expression<Func<Manager, object>> orderBy, SortOrder order);
    }
}
