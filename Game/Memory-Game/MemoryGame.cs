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
    /// dit is de meest basic vorm van ons memory game. Hierop zijn de andere game modes gebaseerd.
    /// </summary>


    public partial class MemoryGame : Form
    {   //variables
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
        int scoretimermediumcounter = 300;
        List<string> checkForWinner = new List<string>();
        
        /// <summary>
        /// Hierin worden alleen de timers gestart voor de score en de curser aangepast.
        /// </summary>
        public MemoryGame()
        {
            InitializeComponent();

            Cursor cur = new Cursor(Properties.Resources.CursorFang.Handle);
            Cursor = cur;
            scoretimermedium = new Timer();
            scoretimermedium.Tick += new EventHandler(Timer2_Tick);
            scoretimermedium.Interval = 1000; // 1 second
            scoretimermedium.Start();
            score_Counter.Text = scoretimermediumcounter.ToString();
        }

        /// <summary>
        /// Timercounter Medium
        /// </summary>
        private void Timer2_Tick(object sender, EventArgs e) //de score counter die van 300 naar beneden gaat
        {
            scoretimermediumcounter--; 
            if (scoretimermediumcounter == 0)
            {
                scoretimermedium.Stop();
            }
            score_Counter.Text = scoretimermediumcounter.ToString();
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
                
                points.Add(picture.Location); 
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
      /// hier worden de 16 picture boxes gevult met een plaatje en worden ze vergeleken als ze worden aangeklikt.
      /// Dit gebeurt door middel van verschillende click events
      /// </summary>
        #region
        private void card1_Click(object sender, EventArgs e) //Dit gebeurt er wanneer je een kaartje aan klikt 
        {
            if (timer1.Enabled != true) // Als de timer aan staat kan je het kaartje niet aanklikken. Dit voorkomt een veel voorkomende bug 
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
                #endregion  // Deze code kijkt welke card pack je hebt aangeklikt 

                if (pendingImage1 == null) // pendingImage1 wordt gebruikt voor de eerste klik 
                {
                    pendingImage1 = card1; // pendingImage1 wordt hetzelfde als card1
                    pendingImage1.Enabled = false; // Dit zorgt ervoor dat je niet twee keer op het zelfde kaartje kan klikken
                }

                else if (pendingImage1 != null && pendingImage2 == null) // als de pendimImage1 (dus je eerste klik) al hebt en pendingImage2 (tweede klik) nog niet hebt, wordt deze code uitgevoerd.
                {
                    pendingImage2 = card1; // pendingImage2 is hetzelfde als card1
                    pendingImage2.Enabled = false; // Dit zorgt ervoor dat je niet twee keer op het zelfde kaartje kan klikken

                }

                if (pendingImage1 != null && pendingImage2 != null) // als pendingImage1 en pendingImage2 data hebben, wordt deze code uitgevoerd. 
                {
                    if (pendingImage1.Tag == pendingImage2.Tag) // Elk Picturebox heeft een tag en als de twee pictureboxs dezelfde tag hebben wordt deze code uitgevoerd. 
                    {
                        pendingImage1 = null; // De data van pendingImage1 wordt verwijdert
                        pendingImage2 = null; // De data van pendingImage2 wordt verwijdert 
                        card1.Enabled = false; // Card1 kan niet meer hierna worden aangeklikt
                        card1_Dup.Enabled = false; // Het zelfde kaartje dus card1_Dup kan je dan ook niet meer aanklikken 
                        checkForWinner.Add("1true "); // Hier worden de gegevens 1true toegevoegd aan de list checkForWinner 
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

                        CheckForWinner(); // Hier wordt de methode CheckForWinner aangeroepen en in deze methode wordt gekeken of dit de laatste twee kaartjes zijn
                    }
                    else // Als pendingImage1 en 2 niet gelijk zijn wordt dit uitgevoerd 
                    {

                        timer1.Start(); // Hier wordt de timer uitgevoerd en de timer laat de kaartjes 750 miliseconden zien en dan draaien de kaartjes weer om 
                        pendingImage1.Enabled = true; // De pendingImage1 dus card1 kan weer worden aangeklikt 
                        pendingImage2.Enabled = true; // De pendingImage2 dus card1 kan weer worden aangeklikt 
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
            if (timer1.Enabled!= true)
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
                        card8_Dup.Enabled = false;
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
        #endregion
        /// <summary>
        /// Deze method controleerd of het spel gewonnen is.
        /// Indien dit het geval is dan wordt het spel beeindigt en de score opgeslagen.
        /// </summary>
        public void CheckForWinner()
        {
            foreach (string control in checkForWinner)
            {
                string[] checkForWinner_Array = checkForWinner.ToArray();
                if (checkForWinner_Array.Length == 8) //win senario dit slaat de scores en de naam op. hiernaast werkt hij 1 achievement bij
                {
                    scoretimermedium.Stop();
                    SavingClass.varCurrency += scoretimermediumcounter;
                    SavingClass.varAchievement1Have = "true";
                    SavingClass.savedata();
                    MessageBox.Show("You matched all the pictures, well done! " + scoretimermediumcounter + " points were added to your currency. Click OK to return to main menu.");
                    SavingClass.varNewScore = Convert.ToString(scoretimermediumcounter);
                    SavingClass.varNewname = SavingClass.varplayername;
                    if (SavingClass.varNewScore.Length != 3)
                    {
                        SavingClass.varNewScore = ("0" + SavingClass.varNewScore + "                    " + SavingClass.varplayername);
                        MessageBox.Show(SavingClass.varNewScore);
                    }
                    else
                    {
                        SavingClass.varNewScore = Convert.ToString(scoretimermediumcounter) + "                    " + SavingClass.varplayername;
                    }
                    SavingClass.Saveleaderboard();
                    if (File.Exists(SavingClass.path + "savecheckm" + SavingClass.varplayername + ".sav"))
                        {
                        File.Delete(SavingClass.path + "savecheckm" + SavingClass.varplayername + ".sav");
                        }

                    Close();
                    Menu newMDIChild = new Menu(); //Start de menu  op.
                    newMDIChild.MdiParent = Form.ActiveForm; // Set the Parent Form of the Child window. 
                    newMDIChild.Show(); // Display the new form. 
                    goto Stap1;

                }
            }
            Stap1:;

        }
        /// <summary>
        ///  gebruikt de juiste achterkant van de gekozen cardpack 
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e) 
        {
            timer1.Stop(); // De timer stopt 

            if (Store.invoer == "") // kiest de juiste achterkant en zorgt ervoor dat na de timer dus de kaartjes omdraaien 
            {
                pendingImage1.BackgroundImage = Properties.Resources.D_Cover;
                pendingImage2.BackgroundImage = Properties.Resources.D_Cover;
            }

            if (SavingClass.varCardBack == "SW" )
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

            pendingImage1 = null; // pendimage1 wordt niks meer
            pendingImage2 = null; // pendimage2 wordt niks meer
        }
        
       
           


        /// <summary>
        /// Back to menu button
        /// </summary>
        private void BackToMenu_Click(object sender, EventArgs e)
        {
            SavingClass.savedata();
            Close();
            Menu newMDIChild = new Menu(); //Start de menu  op.
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = Form.ActiveForm;
            // Display the new form.  
            newMDIChild.Show();
        }
        /// <summary>
        /// slaat het memory spel op
        /// </summary>
        public void SaveMemory() 
        {

            using (TextWriter writer = File.CreateText(SavingClass.path+ "savepoints" + SavingClass.varplayername + ".sav"))
                foreach (Point point in points_UpToDate)
                {
                    Convert.ToString(point);
                    writer.WriteLine(point);
                }
            using (TextWriter writer = File.CreateText(SavingClass.path + "savecheckm" + SavingClass.varplayername + ".sav"))
                foreach (string check in checkForWinner)
                {
                    writer.WriteLine(check);
                }
            using (TextWriter writer = File.CreateText(SavingClass.path + "timerm" + SavingClass.varplayername + ".sav"))
            {
                writer.WriteLine(scoretimermediumcounter);
            }
        }
        /// <summary>
        /// laad memory spel en laad de juiste cardback op basis van de gekozen cardback
        /// </summary>
        public void loadMemory()
        {
            if (File.Exists(SavingClass.path + "savecheckm" + SavingClass.varplayername + ".sav"))
            {

                scoretimermediumcounter = Convert.ToInt32((File.ReadAllText(SavingClass.path + "timerm" + SavingClass.varplayername + ".sav").ToString()));

                List<string> checkForWinner2 = File.ReadLines(SavingClass.path + "savecheckm" + SavingClass.varplayername + ".sav").ToList();
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
                    count++;
                    checkForWinner = checkForWinner2;
                }
            }
            else
            {
                MessageBox.Show("you have no save file");
            }
            ///Deze code is voor de locatie op te slaan van de kaartjes. Dit is echter niet gelukt.
            ///Ik heb de code er in laten staan zodat als er tijd over is we er opnieuw naar kunnen kijken.
            //    List<string> pointsString = File.ReadLines(SavingClass.path + "Savepoints.sav").ToList();

            //      string[] lines = File.ReadAllLines(SavingClass.path + "Savepoints.sav");
            //      Point pointResult = new Point();

            //      PointConverter pConverter = new PointConverter();

            //      foreach (string line in lines) //for everyone line/point
            //      {
            //        string Sline= line.Substring(4, 7);
            //         string sline2 = line.Substring(10, 12);
            //        string sline3 = Sline + sline2;
            //       pointResult = (Point)pConverter.ConvertFromString(sline3);
            //      points_UpToDate.Add(pointResult);
            // }


            //CheckForWinner();


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
        private void Resetbutton_Click(object sender, EventArgs e)
        {
            Close();
            MemoryGame newMDIChild = new MemoryGame();          //opent het Memory spel in de mdi
            newMDIChild.MdiParent = Form.ActiveForm;               // "MemoryGame" moet veranderd worden naar de uiteindelijke memorygame class
            newMDIChild.Show();
        }
    }
}
