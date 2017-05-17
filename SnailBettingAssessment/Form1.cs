using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnailBettingAssessment
{
    public partial class Form1 : Form
    {
        //SETUP
        public Form1(int snailsPassed=4,int bettersPassed=3)//defaults for unit testing purposes
        {
            InitializeComponent();
            NumberOfSnails = snailsPassed;
            NumberOfBetters = bettersPassed;
        }
        public int NumberOfSnails { get; set; }
        public int NumberOfBetters { get; set; }


    }
}
