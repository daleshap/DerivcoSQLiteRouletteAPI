using Microsoft.AspNetCore.Mvc;
using SQLiteRouletteAPI.Models;
using System.Data;

namespace SQLiteRouletteAPI.Interfaces
{
    public interface ISpinResultHelper
    {
        SpinResult MapDataTabletoSpinResult(DataTable table);
        int SpinTheWheel();
    }

}
