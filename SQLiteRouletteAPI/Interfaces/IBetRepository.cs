using SQLiteRouletteAPI.Models;

namespace SQLiteRouletteAPI.Interfaces
{
    public interface IBetRepository
    {
        Task<string> AddBetAsync(Bet bet);
        Task<List<Bet>> GetBetsForSpinAsync(int spinIdNumber);
        Task<List<Bet>> GetAllBetsAsync();
        Task<List<Bet>> GetBetsForUserAsync(int userId);
        Task<Bet> GetSingleBetAsync(int betId);

    }

}
