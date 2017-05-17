using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailBettingAssessment
{
    class Rich : Beter
    {
        public Rich()
        {
            CurrentBalance = 100;
        }
    }

    class Normal : Beter
    {
        public Normal()
        {
            CurrentBalance = 75;
        }
        
    }

    class Poor : Beter
    {
        public Poor()
        {
            CurrentBalance = 50;
        }
        
    }
}
