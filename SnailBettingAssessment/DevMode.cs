using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailBettingAssessment
{
    static class DevMode
    {
        public static bool Speed { get; set; } = false;
        public static int[] Win { get; set; } = {0,1};//{true(1)/false(0),which snail}
        public static bool Resize { get; set; } = false;
    }
}
