using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailBettingAssessment
{
    class Snail
    {
        //todo:     Extra Feature: Add different snail types and corresponding odds that effect winnings (make base Snail class abstract)
        public int MaxSpeed { get; set; }
        public int MinSpeed { get; set; }
        public int RemainingTrack { get; set; }
        public Random RandomMovement = new Random();
    }
}
