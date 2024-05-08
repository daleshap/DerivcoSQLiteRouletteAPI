using SQLiteRouletteAPI.Models;

namespace SQLiteRouletteAPI.Interfaces
{
    public interface IPayoutRepository
    {
        Task AddPayoutAsync(Payout payout);
        Task<List<Payout>> GetAllPayoutsAsync();
        Task<Payout> GetPayoutAsync(int payoutId);
    }
}
