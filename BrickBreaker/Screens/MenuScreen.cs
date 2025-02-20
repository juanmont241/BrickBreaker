﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.Media;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        //----Juan------//
        public static List<Rectangle> SquareList = new List<Rectangle>(); //Made List for squares 
        public static List<SoundPlayer> soundList = new List<SoundPlayer>(); //List to store all sounds
        Random randGen = new Random();
        Size screenSize;
        int angle;
        //--------------//

        public MenuScreen()
        {
               JuanMethod_Sounds(); //Declares sound method
            soundList[9].Play(); //Plays the main theme of Among Us
            JuanMethod_FlyingSquares(); //Declares the new square method
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            JuanMethod_MovingSquares(); //Declares the moving method
        }


        private void MenuScreen_Paint(object sender, PaintEventArgs e)
        {
            JuanMethod_PaintingSquares(); //Declares the Paint method
        }


        public void JuanMethod_Sounds() //Method meant to store sounds (Commented out due to Project Manager) (Resources in the google drive folder)
        {

            SoundPlayer AlarmStartUp = new SoundPlayer(Properties.Resources.AlarmWav);
            SoundPlayer ClickPlay = new SoundPlayer(Properties.Resources.Correct);
            SoundPlayer ClickHowToPlay = new SoundPlayer(Properties.Resources.Blip_Select31);
            SoundPlayer PauseSound = new SoundPlayer(Properties.Resources.Super_Mario_64_Pause_Sound);
            SoundPlayer CreditSound = new SoundPlayer(Properties.Resources.nunu);
            SoundPlayer BallMiss = new SoundPlayer(Properties.Resources.Beewoop);
            SoundPlayer BallBounce = new SoundPlayer(Properties.Resources.Ball_Bounce);
            SoundPlayer EnterVent = new SoundPlayer(Properties.Resources.Vent);
            SoundPlayer BrickBroken = new SoundPlayer(Properties.Resources.Brick_Broken);


            //----------------Long Sounds----------------//
            SoundPlayer AmongUsMT = new SoundPlayer(Properties.Resources.Main_Theme);
            SoundPlayer CreditsMT = new SoundPlayer(Properties.Resources.cams_ambience);
            SoundPlayer HowToPlayMT = new SoundPlayer(Properties.Resources.HowToPlay_Theme);
            SoundPlayer DefeatMT = new SoundPlayer(Properties.Resources.Defeat1);
            SoundPlayer VictoryMT = new SoundPlayer(Properties.Resources.Victory1);

            //-------------------------------------------//


            soundList.Add(AlarmStartUp); //0
            soundList.Add(ClickPlay);    //1
            soundList.Add(ClickHowToPlay); //2
            soundList.Add(PauseSound); //3
            soundList.Add(CreditSound); //4
            soundList.Add(BallMiss); //5
            soundList.Add(BallBounce); //6
            soundList.Add(EnterVent); //7
            soundList.Add(BrickBroken); //8
            soundList.Add(AmongUsMT); //9
            soundList.Add(CreditsMT); //10
            soundList.Add(HowToPlayMT); //11
            soundList.Add(DefeatMT); //12
            soundList.Add(VictoryMT); //13


        }

        public void JuanMethod_FlyingSquares()  //Method meant for creating and putting the squares into a list (JUAN)
        {
            for (int i = 0; i < 5; i++) { //for loop to create the limit of square 
                
            screenSize = new Size(this.Width, this.Height);

            int y = randGen.Next(70, screenSize.Height - 70);

            Rectangle AmongOne = new Rectangle(0, y, 30, 30);
            SquareList.Add(AmongOne);
    
        }

        }

        public void JuanMethod_PaintingSquares() //Method meant for painting and rotating the squares (JUAN)
        {
            int randColour = randGen.Next(1, 5); //Random colours

            //This is to make the square more in a curve
            Graphics g = this.CreateGraphics();
            //the central point of the rotation
            g.TranslateTransform(0, 0);
            //rotation procedure
            g.RotateTransform(5.0F);

            //For each square per second change the colour (Has a rainbow effect on the squares)
            for (int i = 0; i < SquareList.Count; i++)
            {

                if (randColour == 1)
                {
                    g.DrawRectangle(Pens.Red, SquareList[i].X, SquareList[i].Y, SquareList[i].Width, SquareList[i].Height);
                }

                else if (randColour == 2)
                {
                    g.DrawRectangle(Pens.Blue, SquareList[i].X, SquareList[i].Y, SquareList[i].Width, SquareList[i].Height);
                }

                else if (randColour == 3)
                {
                    g.DrawRectangle(Pens.Yellow, SquareList[i].X, SquareList[i].Y, SquareList[i].Width, SquareList[i].Height);
                }

                else if (randColour == 4)
                {
                    g.DrawRectangle(Pens.Pink, SquareList[i].X, SquareList[i].Y, SquareList[i].Width, SquareList[i].Height);
                }

                else if (randColour == 5)
                {
                    g.DrawRectangle(Pens.Orange, SquareList[i].X, SquareList[i].Y, SquareList[i].Width, SquareList[i].Height);
                }
            }
        }

        public void JuanMethod_MovingSquares() //Method meant for moving each square to the left then telport back to the beginning
        {
            int xspeed = 35; //What is the speed of the sqaure
            int whichAngle = randGen.Next(1, 2); //Decides which angle the squares go to
            int randHeight = randGen.Next(200, 450); //Creates the limit of height between 200 to 450


            for (int i = 0; i < SquareList.Count; i++) //For each square, make them go right 
            {
                int x = SquareList[i].X + xspeed;
                int y = SquareList[i].Y;
                SquareList[i] = new Rectangle(x, SquareList[i].Y, SquareList[i].Width, SquareList[i].Height);

                if (SquareList[i].X >= 1067) //If the square reaches the end, make a new SINGLE square back from the start
                {
                    x = 0;
                    y = randHeight;
                    SquareList[i] = new Rectangle(x, y, SquareList[i].Width, SquareList[i].Height);

                }
                if (whichAngle == 1) //Angle One
                {
                    angle--;

                }

                else if (whichAngle == 2) //Angle Two
                {
                    angle++;
                }

            }
            Refresh(); //Refresh the screen

        }


        private void playButton_Click(object sender, EventArgs e)
        {
            // Goes to the game screen
            soundList[1].Play(); //Plays a camera ding
            GameScreen gs = new GameScreen();
            Form form = this.FindForm();

            form.Controls.Add(gs);
            form.Controls.Remove(this);
            soundList[0].Play(); //Plays an alarm sound from Among Us

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void howToButton_Click(object sender, EventArgs e)
        {
            soundList[2].Play(); //Plays a camera select sound
            HowToPlay htp = new HowToPlay();
            Form form = this.FindForm();

            form.Controls.Add(htp);
            form.Controls.Remove(this);
            soundList[11].Play(); //Plays the extras theme

            htp.Location = new Point((form.Width - htp.Width) / 2, (form.Height - htp.Height) / 2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            soundList[4].Play(); //Plays an error sound
            
            CreditScreen cs  = new CreditScreen();
            Form form = this.FindForm();

            form.Controls.Add(cs);
            form.Controls.Remove(this);
            soundList[10].Play(); //Plays camera static

            cs.Location = new Point((form.Width - cs.Width) / 2, (form.Height - cs.Height) / 2);
        }
    }
}
