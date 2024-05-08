using Microsoft.EntityFrameworkCore;
using SQLiteRouletteAPI.Interfaces;
using SQLiteRouletteAPI.Data;
using SQLiteRouletteAPI.Models;

namespace SQLiteRouletteAPI.Repos
{
    public class PayoutRepository : IPayoutRepository
    {
        private readonly RouletteDbContext _dbContext;
        public PayoutRepository(RouletteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPayoutAsync(Payout payout)
        {
            _dbContext.Payouts.Add(payout);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Payout>> GetAllPayoutsAsync()
        {
            return await _dbContext.Payouts.ToListAsync();
        }

        public async Task<Payout> GetPayoutAsync(int payoutId)
        {
            return await _dbContext.Payouts.FindAsync(payoutId);
        }
    }
}
