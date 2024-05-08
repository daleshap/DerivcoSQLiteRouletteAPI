using Microsoft.AspNetCore.Mvc;
using SQLiteRouletteAPI.Models;
using System.Data;

namespace SQLiteRouletteAPI.Interfaces
{
    public interface IBetHelper
    {
        List<Bet> MapDataTabletoBets(DataTable table);
    }

}
