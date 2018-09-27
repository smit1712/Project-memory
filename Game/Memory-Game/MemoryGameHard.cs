using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Memory_Game
{
    /// <summary>
    /// dit is de hardmode van ons memory game. gebaseerd op de basic memorygame.
    /// </summary>
    public partial class MemoryGameHard : Form // doet het zelfde als memorygame maar dan op een groter/moeilijker speel veld
    {
        //variables
        //int score = 0; //De score die je behaald
        Random location = new Random(); // Haal een random locatie van de X en Y list en hierdoor worden de kaarten dus gehusselt;
        List<Point> points = new List<Point>();
        List<Point> points_UpToDate = new List<Point>();
        bool again = false; // Wil je op nieuw beginnen
        PictureBox pendingImage1 = null; // Als de kaart geflipt is wordt het deze variabele
        PictureBox pendingImage2 = null; // Same here

        int tries = 0;
        int CountAchievement3Matches = 0;
        Timer scoretimermedium = new Timer();
        Timer scoretimerhard = new Timer();

        int scoretimerhardcounter = 600;
        List<string> checkForWinner = new List<string>();

        /// <summary>
        /// Hierin worden alleen de timers gestart voor de score en de curser aangepast.
        /// </summary>
        public MemoryGameHard()
        {
            InitializeComponent();

            Cursor cur = new Cursor(Properties.Resources.CursorFang.Handle);
            Cursor = cur;

            scoretimerhard = new Timer();
            scoretimerhard.Tick += new EventHandler(Timer2_Tick);
            scoretimerhard.Interval = 600;
            scoretimerhard.Start();
            score_Counter.Text = scoretimerhardcounter.ToString();
        }

        /// <summary>
        /// Timercounter Hard
        /// </summary>
        private void Timer2_Tick(object sender, EventArgs e)
        {
            scoretimerhardcounter --;
            if (scoretimerhardcounter == 0)
            {
                timer1.Stop();
            }
            score_Counter.Text = scoretimerhardcounter.ToString();
        }
        /// <summary>
        /// kijkt welke cardpack gebruikt moet worden en gebruikt de bijpassende achterkant.
        /// </summary>
        private void MemoryGame_Load_1(object sender, EventArgs e)
        {
            foreach (PictureBox picture in cardspanel.Controls)
            {
                if (Store.invoer == "")
                {
                    picture.BackgroundImage = Properties.Resources.D_Cover;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    picture.BackgroundImage = Properties.Resources.SW_Cover;
                }

                if (SavingClass.varCardBack == "D")
                {
                    picture.BackgroundImage = Properties.Resources.D_Cover;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    picture.BackgroundImage = Properties.Resources.OW_Cover;
                }

            }

            foreach (PictureBox picture in cardspanel.Controls)
            {

                points.Add(picture.Location);// alle locaties van elke picturebox in cardspanel worden in de list point gezet 
            }

            foreach (PictureBox picture in cardspanel.Controls)
            {
                int next = location.Next(points.Count); // Hier wordt gekijken hoeveel locaties er zijn in de list points en dan wordt er een random locatie aan gegeven. 
                                                        // De .Next is er om ervoor te zorgen dat er niet twee plaatjes op de zelfde locatie komen te staan. 
                Point p = points[next];                 // Hier wordt de nieuwe locatie gegeven en deze wordt p genoemd.
                //points_UpToDate.Add(p);                   
                picture.Location = p;                   // Hier wordt de nieuwe locatie gegeven aan de picturebox.
                points.Remove(p);                       // Dit zorgt ervoor dat niet weer de zelfde locatie wordt uitgezocht. 
            }

        }
        /// <summary>
        /// Deze code is het hart van onze memory game.
        /// hier worden de 24 picture boxes gevult met een plaatje en worden ze vergeleken als ze worden aangeklikt.
        /// Dit gebeurt door middel van verschillende click events
        /// </summary>
        //cards region
        #region
        private void card1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region

                if (Store.invoer == "")
                {
                    card1.BackgroundImage = Properties.Resources.D_1;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card1.BackgroundImage = Properties.Resources.SW_1;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card1.BackgroundImage = Properties.Resources.D_1;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card1.BackgroundImage = Properties.Resources.OW_1;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card1;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card1;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card1.Enabled = false;
                        card1_Dup.Enabled = false;
                        checkForWinner.Add("1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card1_Dup_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {


                #region
                if (Store.invoer == "")
                {
                    card1_Dup.BackgroundImage = Properties.Resources.D_1;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card1_Dup.BackgroundImage = Properties.Resources.SW_1;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card1_Dup.BackgroundImage = Properties.Resources.D_1;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card1_Dup.BackgroundImage = Properties.Resources.OW_1;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card1_Dup;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card1_Dup;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card1.Enabled = false;
                        card1_Dup.Enabled = false;
                        checkForWinner.Add("1.1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {


                #region
                if (Store.invoer == "")
                {
                    card2.BackgroundImage = Properties.Resources.D_2;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card2.BackgroundImage = Properties.Resources.SW_2;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card2.BackgroundImage = Properties.Resources.D_2;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card2.BackgroundImage = Properties.Resources.OW_2;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card2;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card2;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card2.Enabled = false;
                        card2_Dup.Enabled = false;
                        checkForWinner.Add("2true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card2_Dup_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card2_Dup.BackgroundImage = Properties.Resources.D_2;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card2_Dup.BackgroundImage = Properties.Resources.SW_2;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card2_Dup.BackgroundImage = Properties.Resources.D_2;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card2_Dup.BackgroundImage = Properties.Resources.OW_2;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card2_Dup;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card2_Dup;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card2.Enabled = false;
                        card2_Dup.Enabled = false;
                        checkForWinner.Add("2.1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;

                    }
                }
            }
        }

        private void card3_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card3.BackgroundImage = Properties.Resources.D_3;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card3.BackgroundImage = Properties.Resources.SW_3;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card3.BackgroundImage = Properties.Resources.D_3;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card3.BackgroundImage = Properties.Resources.OW_3;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card3;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card3;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card3.Enabled = false;
                        card3_Dup.Enabled = false;
                        checkForWinner.Add("3true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card3_Dup_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {


                #region
                if (Store.invoer == "")
                {
                    card3_Dup.BackgroundImage = Properties.Resources.D_3;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card3_Dup.BackgroundImage = Properties.Resources.SW_3;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card3_Dup.BackgroundImage = Properties.Resources.D_3;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card3_Dup.BackgroundImage = Properties.Resources.OW_3;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card3_Dup;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card3_Dup;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card3.Enabled = false;
                        card3_Dup.Enabled = false;
                        checkForWinner.Add("3.1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card4_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card4.BackgroundImage = Properties.Resources.D_4;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card4.BackgroundImage = Properties.Resources.SW_4;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card4.BackgroundImage = Properties.Resources.D_4;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card4.BackgroundImage = Properties.Resources.OW_4;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card4;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card4;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card4.Enabled = false;
                        card4_Dup.Enabled = false;
                        checkForWinner.Add("4true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card4_Dup_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card4_Dup.BackgroundImage = Properties.Resources.D_4;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card4_Dup.BackgroundImage = Properties.Resources.SW_4;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card4_Dup.BackgroundImage = Properties.Resources.D_4;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card4_Dup.BackgroundImage = Properties.Resources.OW_4;
                }
                #endregion
                if (pendingImage1 == null)
                {
                    pendingImage1 = card4_Dup;
                    pendingImage1.Enabled = false;
                }


                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card4_Dup;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card4.Enabled = false;
                        card4_Dup.Enabled = false;
                        checkForWinner.Add("4.1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card5_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card5.BackgroundImage = Properties.Resources.D_5;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card5.BackgroundImage = Properties.Resources.SW_5;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card5.BackgroundImage = Properties.Resources.D_5;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card5.BackgroundImage = Properties.Resources.OW_5;
                }
                #endregion
                if (pendingImage1 == null)
                {
                    pendingImage1 = card5;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card5;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card5.Enabled = false;
                        card5_Dup.Enabled = false;
                        checkForWinner.Add("5true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card5_Dup_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card5_Dup.BackgroundImage = Properties.Resources.D_5;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card5_Dup.BackgroundImage = Properties.Resources.SW_5;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card5_Dup.BackgroundImage = Properties.Resources.D_5;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card5_Dup.BackgroundImage = Properties.Resources.OW_5;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card5_Dup;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card5_Dup;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card5.Enabled = false;
                        card5_Dup.Enabled = false;
                        checkForWinner.Add("5.1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card6_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card6.BackgroundImage = Properties.Resources.D_6;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card6.BackgroundImage = Properties.Resources.SW_6;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card6.BackgroundImage = Properties.Resources.D_6;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card6.BackgroundImage = Properties.Resources.OW_6;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card6;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card6;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card6.Enabled = false;
                        card6_Dup.Enabled = false;
                        checkForWinner.Add("6true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card6_Dup_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card6_Dup.BackgroundImage = Properties.Resources.D_6;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card6_Dup.BackgroundImage = Properties.Resources.SW_6;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card6_Dup.BackgroundImage = Properties.Resources.D_6;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card6_Dup.BackgroundImage = Properties.Resources.OW_6;
                }
                #endregion
                if (pendingImage1 == null)
                {
                    pendingImage1 = card6_Dup;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card6_Dup;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card6.Enabled = false;
                        card6_Dup.Enabled = false;
                        checkForWinner.Add("6.1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card7_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card7.BackgroundImage = Properties.Resources.D_7;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card7.BackgroundImage = Properties.Resources.SW_7;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card7.BackgroundImage = Properties.Resources.D_7;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card7.BackgroundImage = Properties.Resources.OW_7;
                }
                #endregion
                if (pendingImage1 == null)
                {
                    pendingImage1 = card7;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card7;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card7.Enabled = false;
                        card7_Dup.Enabled = false;
                        checkForWinner.Add("7true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card7_Dup_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card7_Dup.BackgroundImage = Properties.Resources.D_7;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card7_Dup.BackgroundImage = Properties.Resources.SW_7;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card7_Dup.BackgroundImage = Properties.Resources.D_7;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card7_Dup.BackgroundImage = Properties.Resources.OW_7;
                }
                #endregion
                if (pendingImage1 == null)
                {
                    pendingImage1 = card7_Dup;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card7_Dup;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card7.Enabled = false;
                        card7_Dup.Enabled = false;
                        checkForWinner.Add("7.1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card8_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card8.BackgroundImage = Properties.Resources.D_8;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card8.BackgroundImage = Properties.Resources.SW_8;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card8.BackgroundImage = Properties.Resources.D_8;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card8.BackgroundImage = Properties.Resources.OW_8;
                }
                #endregion
                if (pendingImage1 == null)
                {
                    pendingImage1 = card8;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card8;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card8.Enabled = false;
                        card7_Dup.Enabled = false;
                        checkForWinner.Add("8true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card8_Dup_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card8_Dup.BackgroundImage = Properties.Resources.D_8;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card8_Dup.BackgroundImage = Properties.Resources.SW_8;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card8_Dup.BackgroundImage = Properties.Resources.D_8;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card8_Dup.BackgroundImage = Properties.Resources.OW_8;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card8_Dup;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card8_Dup;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card8.Enabled = false;
                        card8_Dup.Enabled = false;
                        checkForWinner.Add("8.1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card9_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card9.BackgroundImage = Properties.Resources.D_9;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card9.BackgroundImage = Properties.Resources.SW_9;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card9.BackgroundImage = Properties.Resources.D_9;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card9.BackgroundImage = Properties.Resources.OW_9;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card9;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card9;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card9.Enabled = false;
                        card9_Dup.Enabled = false;
                        checkForWinner.Add("9true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card9_Dup_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card9_Dup.BackgroundImage = Properties.Resources.D_9;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card9_Dup.BackgroundImage = Properties.Resources.SW_9;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card9_Dup.BackgroundImage = Properties.Resources.D_9;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card9_Dup.BackgroundImage = Properties.Resources.OW_9;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card9_Dup;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card9_Dup;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card9.Enabled = false;
                        card9_Dup.Enabled = false;
                        checkForWinner.Add("9.1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card10_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card10.BackgroundImage = Properties.Resources.D_10;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card10.BackgroundImage = Properties.Resources.SW_10;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card10.BackgroundImage = Properties.Resources.D_10;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card10.BackgroundImage = Properties.Resources.OW_10;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card10;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card10;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card10.Enabled = false;
                        card10_Dup.Enabled = false;
                        checkForWinner.Add("10true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card10_Dup_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card10_Dup.BackgroundImage = Properties.Resources.D_10;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card10_Dup.BackgroundImage = Properties.Resources.SW_10;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card10_Dup.BackgroundImage = Properties.Resources.D_10;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card10_Dup.BackgroundImage = Properties.Resources.OW_10;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card10_Dup;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card10_Dup;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card10.Enabled = false;
                        card10_Dup.Enabled = false;
                        checkForWinner.Add("10.1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card11_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card11.BackgroundImage = Properties.Resources.D_11;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card11.BackgroundImage = Properties.Resources.SW_11;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card11.BackgroundImage = Properties.Resources.D_11;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card11.BackgroundImage = Properties.Resources.OW_11;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card11;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card11;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card11.Enabled = false;
                        card11_Dup.Enabled = false;
                        checkForWinner.Add("11true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card11_Dup_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card11_Dup.BackgroundImage = Properties.Resources.D_11;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card11_Dup.BackgroundImage = Properties.Resources.SW_11;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card11_Dup.BackgroundImage = Properties.Resources.D_11;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card11_Dup.BackgroundImage = Properties.Resources.OW_11;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card11_Dup;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card11_Dup;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card11.Enabled = false;
                        card11_Dup.Enabled = false;
                        checkForWinner.Add("11.1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card12_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card12.BackgroundImage = Properties.Resources.D_12;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card12.BackgroundImage = Properties.Resources.SW_12;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card12.BackgroundImage = Properties.Resources.D_12;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card12.BackgroundImage = Properties.Resources.OW_12;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card12;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card12;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card12.Enabled = false;
                        card12_Dup.Enabled = false;
                        checkForWinner.Add("12true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }

        private void card12_Dup_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true)
            {
                #region
                if (Store.invoer == "")
                {
                    card12_Dup.BackgroundImage = Properties.Resources.D_12;
                }

                if (SavingClass.varCardBack == "SW")
                {
                    card12_Dup.BackgroundImage = Properties.Resources.SW_12;
                }

                if (SavingClass.varCardBack == "D")
                {
                    card12_Dup.BackgroundImage = Properties.Resources.D_12;
                }

                if (SavingClass.varCardBack == "OW")
                {
                    card12_Dup.BackgroundImage = Properties.Resources.OW_12;
                }
                #endregion

                if (pendingImage1 == null)
                {
                    pendingImage1 = card12_Dup;
                    pendingImage1.Enabled = false;
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card12_Dup;
                    pendingImage2.Enabled = false;
                }

                if (pendingImage1 != null && pendingImage2 != null)
                {
                    if (pendingImage1.Tag == pendingImage2.Tag)
                    {
                        pendingImage1 = null;
                        pendingImage2 = null;
                        card12.Enabled = false;
                        card12_Dup.Enabled = false;
                        checkForWinner.Add("12.1true ");
                        CountAchievement3Matches += 1;
                        tries += 1;
                        if (CountAchievement3Matches == 3)
                        {
                            SavingClass.varAchievement2Have = "true";
                        }
                        if (tries == 1)
                        {
                            SavingClass.varAchievement3Have = "true";
                        }
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                        pendingImage1.Enabled = true;
                        pendingImage2.Enabled = true;
                        CountAchievement3Matches = 0;
                        tries += 1;
                    }
                }
            }
        }
        #endregion

        public void CheckForWinner()//win senario dit slaat de scores etc op
        {
            foreach (string control in checkForWinner)
            {
                string[] checkForWinner_Array = checkForWinner.ToArray();
                if (checkForWinner_Array.Length == 12)
                {
                    scoretimerhard.Stop();
                    SavingClass.varCurrency += scoretimerhardcounter;
                    SavingClass.varAchievement1Have = "true";
                    SavingClass.savedata();
                    MessageBox.Show("You matched all the pictures, well done! " + scoretimerhardcounter + " points were added to your currency. Click OK to return to main menu.");
         //           MessageBox.Show("You matched all the pictures, well done! " + scoretimerhardcounter + " points were added to your currency.");
                    SavingClass.varNewScoreHard = Convert.ToString(scoretimerhardcounter);
                    SavingClass.varNewname = SavingClass.varplayername;
                    if (SavingClass.varNewScoreHard.Length != 3)
                    {
                        SavingClass.varNewScoreHard = ("0" + SavingClass.varNewScoreHard + "                    " + SavingClass.varplayername);
                        MessageBox.Show(SavingClass.varNewScoreHard);
                    }
                    else
                    {
                        SavingClass.varNewScoreHard = Convert.ToString(scoretimerhardcounter) + "                    " + SavingClass.varplayername;
                    }
                    SavingClass.SaveleaderboardHard();
                    if (File.Exists(SavingClass.path + "savecheckh" + SavingClass.varplayername + ".sav"))
                    {
                        File.Delete(SavingClass.path + "savecheckh" + SavingClass.varplayername + ".sav");
                    }
                    Close();
                    Menu newMDIChild = new Menu(); //Start de menu  op.
                    newMDIChild.MdiParent = Form.ActiveForm; // Set the Parent Form of the Child window.  
                    newMDIChild.Show();  // Display the new form.
                    goto Stap1;
                }
            }
            Stap1:;
        }

        /// <summary>
        ///  gebruikt de juiste achterkant van de gekozen cardpack 
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)  // gebruikt de juiste cardpack
        {
            timer1.Stop();
            if (Store.invoer == "")
            {
                pendingImage1.BackgroundImage = Properties.Resources.D_Cover;
                pendingImage2.BackgroundImage = Properties.Resources.D_Cover;
            }

            if (SavingClass.varCardBack == "SW")
            {
                pendingImage1.BackgroundImage = Properties.Resources.SW_Cover;
                pendingImage2.BackgroundImage = Properties.Resources.SW_Cover;
            }

            if (SavingClass.varCardBack == "D")
            {
                pendingImage1.BackgroundImage = Properties.Resources.D_Cover;
                pendingImage2.BackgroundImage = Properties.Resources.D_Cover;
            }

            if (SavingClass.varCardBack == "OW")
            {
                pendingImage1.BackgroundImage = Properties.Resources.OW_Cover;
                pendingImage2.BackgroundImage = Properties.Resources.OW_Cover;
            }

            pendingImage1 = null;
            pendingImage2 = null;
        }
        /// <summary>
        /// slaat het memory spel op
        /// </summary>
        public void SaveMemory()// slaat het memory spel op
        {
            
            using (TextWriter writer = File.CreateText(SavingClass.path + "savepoints"+SavingClass.varplayername + ".sav"))
                foreach (Point point in points)
                {
                    writer.WriteLine(point);
                }
            using (TextWriter writer = File.CreateText(SavingClass.path + "savecheckh"+SavingClass.varplayername + ".sav"))
                foreach (string check in checkForWinner)
                {
                    writer.WriteLine(check);
                }
            using (TextWriter writer = File.CreateText(SavingClass.path + "timerh" + SavingClass.varplayername + ".sav"))
            {
                writer.WriteLine(scoretimerhardcounter);
            }
        }
        /// <summary>
        /// laad memory spel en laad de juiste cardback op basis van de gekozen cardback
        /// </summary>
        public void loadMemory()// laad memory spel
        {
            if (File.Exists(SavingClass.path + "savecheckh" + SavingClass.varplayername + ".sav"))
            {
                scoretimerhardcounter = Convert.ToInt32((File.ReadAllText(SavingClass.path + "timerh" + SavingClass.varplayername + ".sav").ToString()));

                List<string> checkForWinner2 = File.ReadLines(SavingClass.path + "savecheckh" + SavingClass.varplayername + ".sav").ToList();
                string[] checkForWinner_Array = checkForWinner.ToArray();
                int count = 0;
                foreach (string check in checkForWinner2)
                {
                    string check1 = checkForWinner2[count];
                    if (check1 == "1true " || check == "1.1true ")
                    {
                        if (SavingClass.varCardBack == "SW")
                        {
                            card1.BackgroundImage = Properties.Resources.SW_1;
                            card1_Dup.BackgroundImage = Properties.Resources.SW_1;
                        }
                        if (SavingClass.varCardBack == "OW")
                        {
                            card1.BackgroundImage = Properties.Resources.OW_1;
                            card1_Dup.BackgroundImage = Properties.Resources.OW_1;
                        }
                        if (SavingClass.varCardBack == "D")
                        {
                            card1.BackgroundImage = Properties.Resources.D_1;
                            card1_Dup.BackgroundImage = Properties.Resources.D_1;
                        }
                        card1.Enabled = false;
                        card1_Dup.Enabled = false;

                    }

                    if (check1 == "2true " || check == "2.1true ")
                    {
                        if (SavingClass.varCardBack == "SW")
                        {
                            card2.BackgroundImage = Properties.Resources.SW_2;
                            card2_Dup.BackgroundImage = Properties.Resources.SW_2;
                        }
                        if (SavingClass.varCardBack == "OW")
                        {
                            card2.BackgroundImage = Properties.Resources.OW_2;
                            card2_Dup.BackgroundImage = Properties.Resources.OW_2;
                        }
                        if (SavingClass.varCardBack == "D")
                        {
                            card2.BackgroundImage = Properties.Resources.D_2;
                            card2_Dup.BackgroundImage = Properties.Resources.D_2;
                        }
                        card2.Enabled = false;
                        card2_Dup.Enabled = false;
                    }
                    if (check1 == "3true " || check == "3.1true ")
                    {
                        if (SavingClass.varCardBack == "SW")
                        {
                            card3.BackgroundImage = Properties.Resources.SW_3;
                            card3_Dup.BackgroundImage = Properties.Resources.SW_3;
                        }
                        if (SavingClass.varCardBack == "OW")
                        {
                            card3.BackgroundImage = Properties.Resources.OW_3;
                            card3_Dup.BackgroundImage = Properties.Resources.OW_3;
                        }
                        if (SavingClass.varCardBack == "D")
                        {
                            card3.BackgroundImage = Properties.Resources.D_3;
                            card3_Dup.BackgroundImage = Properties.Resources.D_3;
                        }
                        card3.Enabled = false;
                        card3_Dup.Enabled = false;
                    }
                    if (check1 == "4true " || check == "4.1true ")
                    {
                        if (SavingClass.varCardBack == "SW")
                        {
                            card4.BackgroundImage = Properties.Resources.SW_4;
                            card4_Dup.BackgroundImage = Properties.Resources.SW_4;
                        }
                        if (SavingClass.varCardBack == "OW")
                        {
                            card4.BackgroundImage = Properties.Resources.OW_4;
                            card4_Dup.BackgroundImage = Properties.Resources.OW_4;
                        }
                        if (SavingClass.varCardBack == "D")
                        {
                            card4.BackgroundImage = Properties.Resources.D_4;
                            card4_Dup.BackgroundImage = Properties.Resources.D_4;
                        }
                        card4.Enabled = false;
                        card4_Dup.Enabled = false;
                    }
                    if (check1 == "5true " || check == "5.1true ")
                    {
                        if (SavingClass.varCardBack == "SW")
                        {
                            card5.BackgroundImage = Properties.Resources.SW_5;
                            card5_Dup.BackgroundImage = Properties.Resources.SW_5;
                        }
                        if (SavingClass.varCardBack == "OW")
                        {
                            card5.BackgroundImage = Properties.Resources.OW_5;
                            card5_Dup.BackgroundImage = Properties.Resources.OW_5;
                        }
                        if (SavingClass.varCardBack == "D")
                        {
                            card5.BackgroundImage = Properties.Resources.D_5;
                            card5_Dup.BackgroundImage = Properties.Resources.D_5;
                        }
                        card5.Enabled = false;
                        card5_Dup.Enabled = false;
                    }
                    if (check1 == "6true " || check == "6.1true ")
                    {
                        if (SavingClass.varCardBack == "SW")
                        {
                            card6.BackgroundImage = Properties.Resources.SW_6;
                            card6_Dup.BackgroundImage = Properties.Resources.SW_6;
                        }
                        if (SavingClass.varCardBack == "OW")
                        {
                            card6.BackgroundImage = Properties.Resources.OW_6;
                            card6_Dup.BackgroundImage = Properties.Resources.OW_6;
                        }
                        if (SavingClass.varCardBack == "D")
                        {
                            card6.BackgroundImage = Properties.Resources.D_6;
                            card6_Dup.BackgroundImage = Properties.Resources.D_6;
                        }
                        card6.Enabled = false;
                        card6_Dup.Enabled = false;
                    }
                    if (check1 == "7true " || check == "7.1true ")
                    {
                        if (SavingClass.varCardBack == "SW")
                        {
                            card7.BackgroundImage = Properties.Resources.SW_7;
                            card7_Dup.BackgroundImage = Properties.Resources.SW_7;
                        }
                        if (SavingClass.varCardBack == "OW")
                        {
                            card7.BackgroundImage = Properties.Resources.OW_7;
                            card7_Dup.BackgroundImage = Properties.Resources.OW_7;
                        }
                        if (SavingClass.varCardBack == "D")
                        {
                            card7.BackgroundImage = Properties.Resources.D_7;
                            card7_Dup.BackgroundImage = Properties.Resources.D_7;
                        }
                        card7.Enabled = false;
                        card7_Dup.Enabled = false;
                    }
                    if (check1 == "8true " || check == "8.1true ")
                    {
                        if (SavingClass.varCardBack == "SW")
                        {
                            card8.BackgroundImage = Properties.Resources.SW_8;
                            card8_Dup.BackgroundImage = Properties.Resources.SW_8;
                        }
                        if (SavingClass.varCardBack == "OW")
                        {
                            card8.BackgroundImage = Properties.Resources.OW_8;
                            card8_Dup.BackgroundImage = Properties.Resources.OW_8;
                        }
                        if (SavingClass.varCardBack == "D")
                        {
                            card8.BackgroundImage = Properties.Resources.D_8;
                            card8_Dup.BackgroundImage = Properties.Resources.D_8;
                        }
                        card8.Enabled = false;
                        card8_Dup.Enabled = false;
                    }

                    if (check1 == "9true " || check == "9.1true ")
                    {
                        if (SavingClass.varCardBack == "SW")
                        {
                            card9.BackgroundImage = Properties.Resources.SW_9;
                            card9_Dup.BackgroundImage = Properties.Resources.SW_9;
                        }
                        if (SavingClass.varCardBack == "OW")
                        {
                            card9.BackgroundImage = Properties.Resources.OW_9;
                            card9_Dup.BackgroundImage = Properties.Resources.OW_9;
                        }
                        if (SavingClass.varCardBack == "D")
                        {
                            card9.BackgroundImage = Properties.Resources.D_9;
                            card9_Dup.BackgroundImage = Properties.Resources.D_9;
                        }
                        card9.Enabled = false;
                        card9_Dup.Enabled = false;
                    }

                    if (check1 == "10true " || check == "10.1true ")
                    {
                        if (SavingClass.varCardBack == "SW")
                        {
                            card10.BackgroundImage = Properties.Resources.SW_10;
                            card10_Dup.BackgroundImage = Properties.Resources.SW_10;
                        }
                        if (SavingClass.varCardBack == "OW")
                        {
                            card10.BackgroundImage = Properties.Resources.OW_10;
                            card10_Dup.BackgroundImage = Properties.Resources.OW_10;
                        }
                        if (SavingClass.varCardBack == "D")
                        {
                            card10.BackgroundImage = Properties.Resources.D_10;
                            card10_Dup.BackgroundImage = Properties.Resources.D_10;
                        }
                        card10.Enabled = false;
                        card10_Dup.Enabled = false;
                    }
                    if (check1 == "11true " || check == "11.1true ")
                    {
                        if (SavingClass.varCardBack == "SW")
                        {
                            card11.BackgroundImage = Properties.Resources.SW_11;
                            card11_Dup.BackgroundImage = Properties.Resources.SW_11;
                        }
                        if (SavingClass.varCardBack == "OW")
                        {
                            card11.BackgroundImage = Properties.Resources.OW_11;
                            card11_Dup.BackgroundImage = Properties.Resources.OW_11;
                        }
                        if (SavingClass.varCardBack == "D")
                        {
                            card11.BackgroundImage = Properties.Resources.D_11;
                            card11_Dup.BackgroundImage = Properties.Resources.D_11;
                        }
                        card11.Enabled = false;
                        card11_Dup.Enabled = false;
                    }
                    if (check1 == "12true " || check == "12.1true ")
                    {
                        if (SavingClass.varCardBack == "SW")
                        {
                            card12.BackgroundImage = Properties.Resources.SW_12;
                            card12_Dup.BackgroundImage = Properties.Resources.SW_12;
                        }
                        if (SavingClass.varCardBack == "OW")
                        {
                            card12.BackgroundImage = Properties.Resources.OW_12;
                            card12_Dup.BackgroundImage = Properties.Resources.OW_12;
                        }
                        if (SavingClass.varCardBack == "D")
                        {
                            card12.BackgroundImage = Properties.Resources.D_12;
                            card12_Dup.BackgroundImage = Properties.Resources.D_12;
                        }
                        card12.Enabled = false;
                        card12_Dup.Enabled = false;
                    }

                    count++;
                    checkForWinner = checkForWinner2;
                }
                CheckForWinner();
            }
            else
            {
                MessageBox.Show("you have no save file");
            }

        }

        /// <summary>
        /// savememory butten event
        /// </summary>
        private void SaveMemoryButton_Click(object sender, EventArgs e)
        {
            SaveMemory();
        }

        /// <summary>
        /// loadmemory butten event
        /// </summary>
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            loadMemory();
        }

        /// <summary>
        /// reset butten event
        /// </summary>
        private void BackToMenu_Click_1(object sender, EventArgs e)
        {
            Close();
            Menu newMDIChild = new Menu(); //Start de menu  op.
                                               // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = Form.ActiveForm;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void ResetButtonHard_Click(object sender, EventArgs e)
        {
            Close();
            MemoryGameHard newMDIChild = new MemoryGameHard();
            newMDIChild.MdiParent = Form.ActiveForm;
            newMDIChild.Show();
        }
    }
} 
