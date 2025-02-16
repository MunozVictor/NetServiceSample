using Microsoft.EntityFrameworkCore;
using WineCorp.Dom;
using WineCorp.Infrastructure.Context;

namespace WineCorp.Infrastructure
{
    public class ParcelsRepository : IParcelsRepository
    {
        private readonly WineCorpDbContext _context;
        public ParcelsRepository(WineCorpDbContext wineCorpDbContext)
        {
            _context = wineCorpDbContext;
        }
        public async Task<Dictionary<string, float>> GetTotalParcelAreaByGrapeAsync()
        {
            return await _context.Parcels
             .Include(p => p.Grape) 
             .GroupBy(p => p.Grape.Name)  
             .Select(g => new { GrapeName = g.Key, TotalArea = g.Sum(p => p.Area) }) 
             .ToDictionaryAsync(g => g.GrapeName, g => (float)g.TotalArea);
        }

        public async Task<Dictionary<string, float>> GetTotalParcelAreaByManagerAsync()
        {
            return await _context.Parcels
             .Include(p => p.Manager)
             .GroupBy(p => p.Manager.Name)
             .Select(g => new { ManagerName = g.Key, TotalArea = g.Sum(p => p.Area) })
             .ToDictionaryAsync(g => g.ManagerName, g => (float)g.TotalArea);
        }

        public async Task<Dictionary<string, List<string>>> GetParcelVineyardsNamesWithManagersAsync()
        {
            return await _context.Parcels
                .Select(p => new { VineyardName = p.Vineyard.Name, ManagerName = p.Manager.Name })
                .Distinct()
                .GroupBy(p => p.VineyardName)
                .Select(g => new
                {
                    VineyardName = g.Key,
                    Managers = g.Select(p => p.ManagerName).Distinct().OrderBy(name => name).ToList()
                })
                .ToDictionaryAsync(g => g.VineyardName, g => g.Managers);
        }
    }
}
