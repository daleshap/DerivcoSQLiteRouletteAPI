using SQLiteRouletteAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLiteRouletteAPI.Interfaces
{
    public interface ISpinResultRepository
    {
        Task<long> AddSpinResultAsync(int result);
        Task<List<SpinResult>> GetAllSpinResultsAsync();
        Task<SpinResult> GetSpinResultAsync(int spinResultId);
    }
}
