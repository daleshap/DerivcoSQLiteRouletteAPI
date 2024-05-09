using Microsoft.AspNetCore.Mvc;
using SQLiteRouletteAPI.Models;

namespace SQLiteRouletteAPI.Interfaces
{
    public interface IPayoutHelper
    {
        double GetOdds(BetType betType);
        List<BetType> GetWinningBetTypes(int winningNumber);
        Task<JsonResult> CalculatePayoutTotalAsync(int spinIdNumber);
    }

}
