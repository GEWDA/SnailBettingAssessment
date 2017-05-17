using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailBettingAssessment
{
    class Rich : Better
    {
        public Rich()
        {
            CurrentBalance = 100;
        }
    }

    class Normal : Better
    {
        public Normal()
        {
            CurrentBalance = 75;
        }
        
    }

    class Poor : Better
    {
        public Poor()
        {
            CurrentBalance = 50;
        }
        
    }
}
