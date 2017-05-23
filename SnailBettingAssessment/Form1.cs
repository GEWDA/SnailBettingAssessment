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
        private Random RandInt { get; set; } = new Random();
        private System.Timers.Timer SnailTimer =new System.Timers.Timer(){Enabled = false,Interval = 750,AutoReset = true};


        //EVENTS
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;//this is usually a very bad idea
            SnailTimer.Elapsed += MoveASnail;
            Snails = Factory.GenerateSnails(NumberOfSnails);
            Beters = Factory.GenerateBetters(NumberOfBeters);
            Height = (int)(NumberOfSnails+1.4) * 50 + tableLayoutPanel1.Height;
            tableLayoutPanel1.Location=new Point(12,NumberOfSnails*50+6);
            int i = 0;//kinda doing a for loop and a foreach loop at the same time, with only one loop
            foreach (PictureBox picture in Controls.OfType<PictureBox>())
            {
                if (Convert.ToInt16(picture.Name.Substring(10))<=NumberOfSnails)//checks the 'number' of picturebox'number' is not greater than the number that should be loaded
                {
                    picture.Visible = true;
                }
                try
                {
                    Snails[i].Picture = picture;//associates each snail with the correct picture box
                    Snails[i].STARTING_LOCATION = Snails[i].Picture.Location;
                    i++;
                }
                catch//index out of range will be the only cause for this, which can be safely ignored
                {
                    
                }

            }
            i = 0;
            foreach (RadioButton rb in gbBeters.Controls.OfType<RadioButton>())
            {
                var number = Convert.ToInt16(rb.Name.Substring(11));
                if (number <= NumberOfBeters)//checks the 'number' of radiobutton'number' is not greater than the number that should be loaded
                {
                    rb.Visible = true;
                }
                try
                {
                    Beters[i].Radio = rb;//associates each beter with the correct radio button
                    i++;
                }
                catch//index out of range will be the only cause for this, which can be safely ignored
                {

                }
            }
            i = 0;
            foreach (Label lbl in gbBeters.Controls.OfType<Label>())
            {
                if (Convert.ToInt16(lbl.Name.Substring(5)) <= NumberOfBeters)//as the number of visible pictureboxes, radio buttons, and labels changes, I left their names as the default names so this strategy could be easily implemented
                {
                    lbl.Visible = true;
                }
                try
                {
                    Beters[i].Lbl = lbl;//associates each beter with the correct label
                    i++;
                }
                catch//index out of range will be the only cause for this, which can be safely ignored
                {

                }
            }
        }
        private void btnRace_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                c.Enabled = false;
            }
            SnailTimer.Start();
        }
        private void toolActivateDevSpeed_Click(object sender, EventArgs e)
        {
            DevMode.Speed = true;
        }

        /// <summary>
        /// Triggered by timer SnailTimer
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void MoveASnail(Object source, System.Timers.ElapsedEventArgs e)
        {
            int whichSnail = RandInt.Next(0,NumberOfSnails);
            Snails[whichSnail].Picture.Location= new Point(DevMode.Speed? Snails[whichSnail].Picture.Location.X+100 : Snails[whichSnail].Picture.Location.X+20,Snails[whichSnail].Picture.Location.Y);
            if (Snails[whichSnail].Picture.Location.X+Snails[whichSnail].Picture.Width>=Width)//if the right side of the snail is at least touching the right side of the form
            {
                RaceOver(whichSnail);
            }
        }
        //METHODS
        private void RaceOver(int whichSnail)
        {
            SnailTimer.Stop();
            MessageBox.Show("Snail " + whichSnail.ToString() + " has won!");
            foreach (Control c in Controls)
            {
                c.Enabled = true;
            }
            foreach (Beter currentBeter in Beters)
            {
                if (currentBeter.CurrentBet[1]-1==whichSnail)//'list' starting at 1 -1 == array index starting at 0
                {
                    currentBeter.JustWon = true;
                    int winnings = currentBeter.CurrentBet[0] * 2;
                    currentBeter.CurrentBalance += winnings;
                    MessageBox.Show(currentBeter.Name + " has won $" +winnings.ToString() + "!");
                }
                currentBeter.CheckOut();
                //foreach (Snail racer in Snails)
                //{
                //    racer.Picture.Location = racer.STARTING_LOCATION;
                //}
            }            


        }


    }
}
