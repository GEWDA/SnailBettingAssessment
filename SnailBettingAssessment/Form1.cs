using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
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
        private SoundPlayer sound = new SoundPlayer();

        //EVENTS
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;//this is usually a very bad idea
            SnailTimer.Elapsed += MoveASnail;
            Snails = Factory.GenerateSnails(NumberOfSnails);
            Beters = Factory.GenerateBetters(NumberOfBeters);
            nudSnail.Maximum = NumberOfSnails;
            Height = (int)(NumberOfSnails+1.4) * 50 + tableLayoutPanel1.Height;
            tableLayoutPanel1.Location=new Point(12,NumberOfSnails*50+6);
            sound.Stream = SnailBettingAssessment.Properties.Resources.Squish_1_Short;//Original Sound Created By: Mike Koenig , Downloaded From: http://soundbible.com/511-Squish-1.html , Sound Edited.
            sound.Load();
            sound.Play();
            SetupPictures();
            SetupRadioButtons();
            SetupLabels();
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

        private void fakeToolActivateWin_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem theSender = (ToolStripMenuItem) sender;
            DevMode.Win[0] = 1;
            DevMode.Win[1] = Convert.ToInt16(theSender.Text.Substring(6))-1;
        }
        private void btnBet_Click(object sender, EventArgs e)
        {
            foreach (Beter currentBeter in Beters)
            {
                if (currentBeter.Radio.Checked && !currentBeter.IsOut)
                {
                    currentBeter.CurrentBet[0] = Convert.ToInt16(nudBet.Value);
                    currentBeter.CurrentBet[1] = Convert.ToInt16(nudSnail.Value);
                    currentBeter.CurrentBalance -= currentBeter.CurrentBet[0];
                    currentBeter.Lbl.Text += " - Bet $"+currentBeter.CurrentBet[0].ToString()+" on Snail "+currentBeter.CurrentBet[1].ToString();
                    currentBeter.Radio.Enabled = false;
                }
            }
        }

        private void fakeRadioButton_Select(object sender, EventArgs e)
        {
            foreach (Beter b in Beters)
            {
                if (b.Radio == sender)
                {
                    nudBet.Text = "5";
                    nudBet.Maximum = b.CurrentBalance;
                }
            }
        }
        private void resizeFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevMode.Resize = true;
            FormBorderStyle=FormBorderStyle.Sizable;
        }

        /// <summary>
        /// Triggered by timer SnailTimer
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void MoveASnail(Object source, System.Timers.ElapsedEventArgs e)
        {
            int whichSnail = RandInt.Next(0,NumberOfSnails);
            //below line: if it isn't an instant win for this exact snail, if speedup is on, move 200 pixels, otherwise move 20 pixels
            Snails[whichSnail].Picture.Location= new Point(DevMode.Win[0]==0 || DevMode.Win[1]!=whichSnail?DevMode.Speed? Snails[whichSnail].Picture.Location.X+200 : Snails[whichSnail].Picture.Location.X+20:Snails[whichSnail].Picture.Location.X + 9999999, Snails[whichSnail].Picture.Location.Y);
            sound.Play();
            if (Snails[whichSnail].Picture.Location.X+Snails[whichSnail].Picture.Width>=Width)//if the right side of the snail is at least touching the right side of the form
            {
                RaceOver(whichSnail);
            }
        }
        //METHODS
        private void RaceOver(int whichSnail)
        {
            SnailTimer.Stop();
            DevMode.Speed = false;
            DevMode.Win[0] = 0;
            MessageBox.Show("Snail " + (whichSnail+1).ToString() + " has won!");
            foreach (Beter currentBeter in Beters)
            {
                if (currentBeter.CurrentBet[1]==whichSnail+1 && !currentBeter.IsOut)//list starting at 1 == array index starting at 0 +1
                {
                    int winnings = currentBeter.CurrentBet[0] * 2;
                    currentBeter.CurrentBalance += winnings;
                    MessageBox.Show(currentBeter.Name + " has won $" +winnings.ToString() + "!");
                }

                if (!currentBeter.IsOut)
                {
                    currentBeter.Radio.Enabled = true;

                    currentBeter.Lbl.Text= "$" + currentBeter.CurrentBalance.ToString();
                    currentBeter.CheckOut();
                }
            }
            foreach (Snail racer in Snails)
            {
                racer.Picture.Location = racer.STARTING_LOCATION;
            }
            foreach (Control c in Controls)
            {
                c.Enabled = true;
            }
            for (int i = 0; i < NumberOfBeters; i++)
            {
                Beters[i].Radio.PerformClick();
            }

        }

        private void SetupLabels()
        {
            int i = 0;
            foreach (Label lbl in gbBeters.Controls.OfType<Label>())
            {
                if (Convert.ToInt16(lbl.Name.Substring(5)) <= NumberOfBeters
                ) //as the number of visible pictureboxes, radio buttons, and labels changes, I left their names as the default names so this strategy could be easily implemented
                {
                    lbl.Visible = true;
                }
                try
                {
                    Beters[i].Lbl = lbl; //associates each beter with the correct label
                    Beters[i].Lbl.Text = "$" + Beters[i].CurrentBalance.ToString();
                    i++;
                }
                catch //index out of range will be the only cause for this (due to variable number of beters), which can be safely ignored
                {
                }
            }
        }

        private void SetupRadioButtons()
        {
            int i = 0;
            foreach (RadioButton rb in gbBeters.Controls.OfType<RadioButton>())
            {
                var number = Convert.ToInt16(rb.Name.Substring(11));
                if (number <= NumberOfBeters
                ) //checks the 'number' of radiobutton'number' is not greater than the number that should be loaded
                {
                    rb.Visible = true;
                }
                try
                {
                    Beters[i].Radio = rb; //associates each beter with the correct radio button
                    Beters[i].Radio.Text = Beters[i].Name;
                    Thread.Sleep(5); //because my computer is slow...
                    i++;
                }
                catch //index out of range will be the only cause for this, which can be safely ignored
                {
                }
            }
        }

        private void SetupPictures()
        {
            int i = 0; //kinda doing a for loop and a foreach loop at the same time, with only one loop
            foreach (PictureBox picture in Controls.OfType<PictureBox>())
            {
                if (Convert.ToInt16(picture.Name.Substring(10)) <= NumberOfSnails
                ) //checks the 'number' of picturebox'number' is not greater than the number that should be loaded
                {
                    picture.Visible = true;
                }
                try
                {
                    Snails[i].Picture = picture; //associates each snail with the correct picture box
                    Snails[i].STARTING_LOCATION = Snails[i].Picture.Location;
                    i++;
                }
                catch
                {
                } //index out of range will be the only cause for this (due to variable number of snails) , which can be safely ignored
            }
        }


    }
}
