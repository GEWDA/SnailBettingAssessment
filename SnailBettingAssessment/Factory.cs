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
        static public Beter[] GenerateBetters(int howMany)
        {
            Beter[] bettersArray = new Beter[howMany];
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
                bettersArray[i].Name = _names[_random.Next(0,_names.Length-1)];//select a random name from the list of names
            }
            return bettersArray;
        }

        static public Snail[] GenerateSnails(int howMany)
        {
            Snail[] snailArray = new Snail[howMany];
            for (int i = 0; i < howMany; i++)
            {
                snailArray[i]=new Snail();
            }
            return snailArray;
        }
    }
}
