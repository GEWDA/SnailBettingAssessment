using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnailBettingAssessment
{
    abstract class Beter
    {
        public int CurrentBalance { get; set; }
        public int[] CurrentBet { get; set; } = {5, 1};//{ammount:,on snail:}
        public bool JustWon { get; set; } = false;
        public string Name { get; set; }
        public Label Lbl { get; set; }
        public RadioButton Radio { get; set; }

        public void CheckOut()
        {
            if (CurrentBalance <= 0)
            {
                Lbl.Visible = false;
                Radio.Enabled = false;
                MessageBox.Show(Name + " has run out of money!");
            }
        }
    }
}
