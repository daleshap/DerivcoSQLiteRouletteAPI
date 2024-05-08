using Microsoft.AspNetCore.Mvc;
using SQLiteRouletteAPI.Interfaces;
using SQLiteRouletteAPI.Models;
using System.Data;
using System.Reflection;

namespace SQLiteRouletteAPI.Helpers
{
    public class BetHelper: IBetHelper
    {

        public BetHelper()
        {
        }


        public List<Bet> MapDataTabletoBets(DataTable dt)
        {
            return dt.AsEnumerable().Select(row =>
                                                new Bet
                                                {
                                                    BetId = row.Field<int>("BetId"),
                                                    UserId = row.Field<int>("UserId"),
                                                    BetOnColorRed = row.Field<double>("BetOnColorRed"),
                                                    BetOnColorBlack = row.Field<double>("BetOnColorBlack"),
                                                    BetOnEven = row.Field<double>("BetOnEven"),
                                                    BetOnOdd = row.Field<double?>("BetOnOdd"),
                                                    BetOnLow = row.Field<double>("BetOnLow"),
                                                    BetOnHigh = row.Field<double>("BetOnHigh"),
                                                    BetOnFirstDozen = row.Field<double>("BetOnFirstDozen"),
                                                    BetOnSecondDozen = row.Field<double>("BetOnSecondDozen"),
                                                    BetOnThirdDozen = row.Field<double>("BetOnThirdDozen"),
                                                    BetOnFirstColumn = row.Field<double>("BetOnFirstColumn"),
                                                    BetOnSecondColumn = row.Field<double>("BetOnSecondColumn"),
                                                    BetOnThirdColumn = row.Field<double>("BetOnThirdColumn"),
                                                    BetOnNumber0 = row.Field<double>("BetOnNumber0"),
                                                    BetOnNumber1 = row.Field<double>("BetOnNumber1"),
                                                    BetOnNumber2 = row.Field<double>("BetOnNumber2"),
                                                    BetOnNumber3 = row.Field<double>("BetOnNumber3"),
                                                    BetOnNumber4 = row.Field<double>("BetOnNumber4"),
                                                    BetOnNumber5 = row.Field<double>("BetOnNumber5"),
                                                    BetOnNumber6 = row.Field<double>("BetOnNumber6"),
                                                    BetOnNumber7 = row.Field<double>("BetOnNumber7"),
                                                    BetOnNumber8 = row.Field<double>("BetOnNumber8"),
                                                    BetOnNumber9 = row.Field<double>("BetOnNumber9"),
                                                    BetOnNumber10 = row.Field<double>("BetOnNumber10"),
                                                    BetOnNumber11 = row.Field<double>("BetOnNumber11"),
                                                    BetOnNumber12 = row.Field<double>("BetOnNumber12"),
                                                    BetOnNumber13 = row.Field<double>("BetOnNumber13"),
                                                    BetOnNumber14 = row.Field<double>("BetOnNumber14"),
                                                    BetOnNumber15 = row.Field<double>("BetOnNumber15"),
                                                    BetOnNumber16 = row.Field<double>("BetOnNumber16"),
                                                    BetOnNumber17 = row.Field<double>("BetOnNumber17"),
                                                    BetOnNumber18 = row.Field<double>("BetOnNumber18"),
                                                    BetOnNumber19 = row.Field<double>("BetOnNumber19"),
                                                    BetOnNumber20 = row.Field<double>("BetOnNumber20"),
                                                    BetOnNumber21 = row.Field<double>("BetOnNumber21"),
                                                    BetOnNumber22 = row.Field<double>("BetOnNumber22"),
                                                    BetOnNumber23 = row.Field<double>("BetOnNumber23"),
                                                    BetOnNumber24 = row.Field<double>("BetOnNumber24"),
                                                    BetOnNumber25 = row.Field<double>("BetOnNumber25"),
                                                    BetOnNumber26 = row.Field<double>("BetOnNumber26"),
                                                    BetOnNumber27 = row.Field<double>("BetOnNumber27"),
                                                    BetOnNumber28 = row.Field<double>("BetOnNumber28"),
                                                    BetOnNumber29 = row.Field<double>("BetOnNumber29"),
                                                    BetOnNumber30 = row.Field<double>("BetOnNumber30"),
                                                    BetOnNumber31 = row.Field<double>("BetOnNumber31"),
                                                    BetOnNumber32 = row.Field<double>("BetOnNumber32"),
                                                    BetOnNumber33 = row.Field<double>("BetOnNumber33"),
                                                    BetOnNumber34 = row.Field<double>("BetOnNumber34"),
                                                    BetOnNumber35 = row.Field<double>("BetOnNumber35"),
                                                    BetOnNumber36 = row.Field<double>("BetOnNumber36"),

                                                }).ToList();

        }
    }
}
