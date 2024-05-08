using Microsoft.EntityFrameworkCore;
using SQLiteRouletteAPI.Data;
using SQLiteRouletteAPI.Interfaces;
using SQLiteRouletteAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLiteRouletteAPI.Repos
{
    public class SpinResultRepository : ISpinResultRepository
    {
        private readonly RouletteDbContext _dbContext;

        public SpinResultRepository(RouletteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> AddSpinResultAsync(int result)
        {
            var spinResult = new SpinResult { Result = result };
            _dbContext.SpinResults.Add(spinResult);
            await _dbContext.SaveChangesAsync();
            return spinResult.SpinIdNumber;
        }

        public async Task<List<SpinResult>> GetAllSpinResultsAsync()
        {
            return await _dbContext.SpinResults.ToListAsync();
        }

        public async Task<SpinResult> GetSpinResultAsync(int spinResultId)
        {
            return await _dbContext.SpinResults.FindAsync(spinResultId);
        }
    }
}
