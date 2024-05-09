using SQLiteRouletteAPI.Models;

namespace SQLiteRouletteAPI.Interfaces
{
    public interface ISpinResultRepository
    {
        Task<long> AddSpinResultAsync(int result);
        Task<List<SpinResult>> GetAllSpinResultsAsync();
        Task<SpinResult> GetSpinResultAsync(long spinIdNumber);
        Task<SpinResult> GetLatestSpinResultAsync();
    }
}
