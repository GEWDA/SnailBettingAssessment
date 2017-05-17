using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailBettingAssessment
{
    static class Factory
    {
        static private string[] _names = File.ReadAllLines(Directory.GetCurrentDirectory()+@"\..\..\Names.txt");
        static private Random _random = new Random();
        static public Better[] GenerateBetters(int howMany)
        {
            Better[] bettersArray = new Better[howMany];
            for (int i = 0; i < howMany; i++)
            {
                switch (_random.Next(1,3))
                {
                    case 1:
                        bettersArray[i]=new Rich();
                        break;
                    case 2:
                        bettersArray[i] = new Normal();
                        break;
                    default:
                        bettersArray[i] = new Poor();
                        break;
                }
            }
            return bettersArray;
        }





    }
}
