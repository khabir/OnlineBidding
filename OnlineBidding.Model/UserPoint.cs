using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBidding.Model
{
    public class UserPoint
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int TeamID { get; set; }
        public int TotalPoint { get; set; }
        public int NoOfBid { get; set; }
        public int AddedPoint { get; set; }
        public int DeductedPoint { get; set; }
        public string Comments { get; set; }

    }
}
