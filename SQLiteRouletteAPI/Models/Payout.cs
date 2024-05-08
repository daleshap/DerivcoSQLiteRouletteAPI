using System;
using System.Collections.Generic;

namespace SQLiteRouletteAPI.Models
{
    public partial class Payout
    {
        public long PayoutId { get; set; }
        public long? BetId { get; set; }
        public long? SpinIdNumber { get; set; }
        public double? PayoutAmount { get; set; }
    }
}
