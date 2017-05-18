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
        public Form1(int snailsPassed=4,int betersPassed=3)//defaults for unit testing purposes
        {
            InitializeComponent();
            NumberOfSnails = snailsPassed;
            NumberOfBeters = betersPassed;

        }
        public int NumberOfSnails { get; set; }
        public int NumberOfBeters { get; set; }
        Snail[] Snails { get; set; }
        private Beter[] Beters { get; set; }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            Snails = Factory.GenerateSnails(NumberOfSnails);
            Beters = Factory.GenerateBetters(NumberOfBeters);
            Height = (int)(NumberOfSnails+1.4) * 50 + tableLayoutPanel1.Height;
            tableLayoutPanel1.Location=new Point(12,NumberOfSnails*50+6);
            foreach (PictureBox picture in Controls.OfType<PictureBox>())
            {
                if (Convert.ToInt16(picture.Name.Substring(10))<=NumberOfSnails)//checks the 'number' of picturebox'number' is not greater than the number that should be loaded
                {
                    picture.Visible = true;
                }
            }
            foreach (RadioButton rb in gbBeters.Controls.OfType<RadioButton>())
            {
                var number = Convert.ToInt16(rb.Name.Substring(11));
                if (number <= NumberOfBeters)//checks the 'number' of radiobutton'number' is not greater than the number that should be loaded
                {
                    rb.Visible = true;
                }
            }
            foreach (Label lbl in gbBeters.Controls.OfType<Label>())
            {
                if (Convert.ToInt16(lbl.Name.Substring(5)) <= NumberOfBeters)//as the number of visible pictureboxes, radio buttons, and labels changes, I left their names the default names so this strategy could be easily implemented
                {
                    lbl.Visible = true;
                }
            }
        }
    }
}
