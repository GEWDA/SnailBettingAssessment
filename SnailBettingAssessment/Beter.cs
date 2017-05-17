using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailBettingAssessment
{
    abstract class Beter
    {
        public int CurrentBalance { get; set; }
        public int[] CurrentBet { get; set; } = {5, 1};
        public string Name { get; set; }


    }
}
