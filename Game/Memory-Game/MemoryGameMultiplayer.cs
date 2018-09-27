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
    /// dit is de multieplayer vorm van ons memory game. 
    /// </summary>
    public partial class MemoryGameMultiplayer : Form
    {
        //variables
        //int score = 0; //De score die je behaald
        Random location = new Random(); // Haal een random locatie van de X en Y list en hierdoor worden de kaarten dus gehusselt;
        List<Point> points = new List<Point>();
        bool again = false; // Wil je op nieuw beginnen
        PictureBox pendingImage1 = null; // Als de kaart geflipt is wordt het deze variabele
        PictureBox pendingImage2 = null; // Same here
        public int player1score = 0;
        public int player2score = 0;
  
        //int scoretimerhardcounter = 600;
        List<string> checkForWinner = new List<string>();
        /// <summary>
        /// Hierin worden alleen de timers gestart voor de score en de curser aangepast.
        /// </summary>
        public MemoryGameMultiplayer()
        {
            InitializeComponent();
            checkForWinner.Clear();
            Cursor cur = new Cursor(Properties.Resources.CursorFang.Handle);
            Cursor = cur;
            checkForWinner.Clear();
            ZeroPoints();
            player1.Text = SavingClass.varplayername;
            //score_Counter.Text = scoretimermediumcounter.ToString();
        }
        /// <summary>
        /// kijkt welke cardpack gebruikt moet worden en gebruikt de bijpassende achterkant.
        /// </summary>
        private void MemoryGame_Load_1(object sender, EventArgs e) // kijkt welke cardpack gebruikt moet worden en gebruikt de bijpassende achterkant.
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
                int next = location.Next(points.Count);// Hier wordt gekijken hoeveel locaties er zijn in de list points en dan wordt er een random locatie aan gegeven. 
                                                       // De .Next is er om ervoor te zorgen dat er niet twee plaatjes op de zelfde locatie komen te staan. 
                Point p = points[next];       // Hier wordt de nieuwe locatie gegeven en deze wordt p genoemd.
                picture.Location = p; // Hier wordt de nieuwe locatie gegeven aan de picturebox.
                points.Remove(p);   // Dit zorgt ervoor dat niet weer de zelfde locatie wordt uitgezocht. 
            }
                       
        }
        /// <summary>
        /// Deze code is het hart van onze memory game.
        /// hier worden de 16 picture boxes gevult met een plaatje en worden ze vergeleken als ze worden aangeklikt.
        /// Dit gebeurt door middel van verschillende click events
        /// </summary>
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
                    pendingImage1 = card1; //Slaat de kaart op in eerste slot als deze leeg is
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card1; //Slaat de kaart op in de tweede slot als eerste vol is en tweede leeg
                }

                if (pendingImage1 != null && pendingImage2 != null) //Als beide slots gevuld zijn
                {
                    if (pendingImage1.Tag == pendingImage2.Tag) //Als de kaarten het zelfde zijn
                    {
                        pendingImage1 = null; //Reset slot
                        pendingImage2 = null; //Reset slot
                        card1.Enabled = false; //Kaart kan niet meer op geklikt worden
                        card1_Dup.Enabled = false; //Kaart kan niet meer op geklikt worden
                        checkForWinner.Add("1true "); //Zorgt dat het word geregristeerd dat hij goed is
                        PlayerScore(); //Runt de method om een punt toe te voegen
                        CheckForWinner(); //Method die kijkt of alle kaarten zijn omgedraaid en wie heeft gewonnen

                    }
                    else //Als de kaarten niet het zelfde zijn draait hij ze weer om
                    {
                        timer1.Start();
                    }
                    SwitchPlayer(); //Runt method die zorgt dat de volgend speler is
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card1_Dup;
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
                        PlayerScore();
                        CheckForWinner();

                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card2;
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
                        PlayerScore();
                        CheckForWinner();

                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card2_Dup;
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
                        PlayerScore();
                        CheckForWinner();

                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card3;
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
                        PlayerScore();
                        CheckForWinner();

                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card3_Dup;
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
                        PlayerScore();
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card4;
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
                        PlayerScore();
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card4_Dup;
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
                        PlayerScore();
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card5;
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
                        PlayerScore();
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card5_Dup;
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
                        PlayerScore();
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card6;
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
                        PlayerScore();
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card6_Dup;
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
                        PlayerScore();
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card7;
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
                        PlayerScore();
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card7_Dup;
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
                        PlayerScore();
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card8;
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
                        PlayerScore();
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                }

                else if (pendingImage1 != null && pendingImage2 == null)
                {
                    pendingImage2 = card8_Dup;
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
                        PlayerScore();
                        CheckForWinner();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    SwitchPlayer();
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
                if (checkForWinner_Array.Length == 8)
                {
                    if (player1score == player2score) // gelijkspel senario
                    {


                        MessageBox.Show("It's a tie! Clicking OK will automatically start a rematch.");
                        Close();
                        MemoryGameMultiplayer newMDIChild = new MemoryGameMultiplayer(); //Start de MemoryGameMultiplayer  op.
                        newMDIChild.MdiParent = Form.ActiveForm;// Set the Parent Form of the Child window                                                               
                        newMDIChild.Show(); // Display the new form. 
                        player1score = 0;
                        player2score = 1;
                        goto Stap1;
                    }


                    if (player1score >= player2score)
                    {

                        string winningplayer = "";

                        string youwon = WhoWon(winningplayer);

                        MessageBox.Show("Congratulations, " + youwon + ", you won with " + player1score + " matches! Click OK to return to main menu.");
                        SavingClass.varNewScoreMP = Convert.ToString(player1score) + "                    " + SavingClass.varplayername + " (win)";
                        SavingClass.SaveleaderboardMP();
                        SavingClass.varNewScoreMP = Convert.ToString(player2score) + "                    " + Player2.Player2Name + " (loss)";
                        SavingClass.SaveleaderboardMP();
                        Close();
                        Menu newMDIChild = new Menu(); //Start de menu  op.
                                                       // Set the Parent Form of the Child window.  
                        newMDIChild.MdiParent = Form.ActiveForm;
                        // Display the new form.  
                        newMDIChild.Show();
                        goto Stap1;
                    }
                    if (player1score <= player2score)
                    {


                        string winningplayer = "";

                        string youwon = WhoWon(winningplayer); //String met de naam van winnende player

                        MessageBox.Show("Congratulations, " + youwon + ", you won with " + player2score + " matches! Click OK to return to main menu.");
                        SavingClass.varNewScoreMP = Convert.ToString(player2score) + "                    " + Player2.Player2Name + " (win)";
                        SavingClass.SaveleaderboardMP();
                        SavingClass.varNewScoreMP = Convert.ToString(player1score) + "                    " + SavingClass.varplayername + " (loss)";
                        SavingClass.SaveleaderboardMP();
                        Close();
                        Menu newMDIChild = new Menu(); //Start de menu  op.
                        newMDIChild.MdiParent = Form.ActiveForm; // Set the Parent Form of the Child window.  
                        newMDIChild.Show(); // Display the new form.  
                        goto Stap1;
                    }
                }
            }


            Stap1:;
           
        }
        /// <summary>
        ///  gebruikt de juiste achterkant van de gekozen cardpack 
        /// </summary>

        private void timer1_Tick(object sender, EventArgs e)// gebruikt de juiste cardpack
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
        /// Back to menu button
        /// </summary>
        private void BackToMenu_Click(object sender, EventArgs e)
        {
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
        public void SaveMemory() // slaat het memory spel op.  Werkt nu niet in mp
        {
            using (TextWriter writer = File.CreateText(SavingClass.path + "savepoints.sav"))
                foreach (Point point in points)
                {
                    writer.WriteLine(point);
                }
            using (TextWriter writer = File.CreateText(SavingClass.path + "savecheck.sav"))
                foreach (string check in checkForWinner)
                {
                    writer.WriteLine(check);
                }
        }
        /// <summary>
        /// laad memory spel en laad de juiste cardback op basis van de gekozen cardback
        /// </summary>
        public void loadMemory() // laad memory spel. werkt nu niet in mp
        {

            List<string> checkForWinner2 = File.ReadLines(SavingClass.path + "savecheck.sav").ToList();
            string[] checkForWinner_Array = checkForWinner.ToArray();
            int count = 0;
            foreach (string check in checkForWinner2)
            {
                string check1 = checkForWinner2[count];
                if (check1 == "1true " || check == "1.1true ")
                {
                    card1.BackgroundImage = Properties.Resources.SW_1;
                    card1_Dup.BackgroundImage = Properties.Resources.SW_1;


                }

                if (check1 == "2true " || check == "2.1true ")
                {
                    card2.BackgroundImage = Properties.Resources.SW_2;
                    card2_Dup.BackgroundImage = Properties.Resources.SW_2;


                }
                if (check1 == "3true " || check == "3.1true ")
                {
                    card3.BackgroundImage = Properties.Resources.SW_3;
                    card3_Dup.BackgroundImage = Properties.Resources.SW_3;


                }
                if (check1 == "4true " || check == "4.1true ")
                {
                    card4.BackgroundImage = Properties.Resources.SW_4;
                    card4_Dup.BackgroundImage = Properties.Resources.SW_4;


                }
                if (check1 == "5true " || check == "5.1true ")
                {
                    card5.BackgroundImage = Properties.Resources.SW_5;
                    card5_Dup.BackgroundImage = Properties.Resources.SW_5;


                }
                if (check1 == "6true " || check == "6.1true ")
                {
                    card6.BackgroundImage = Properties.Resources.SW_6;
                    card6_Dup.BackgroundImage = Properties.Resources.SW_6;


                }
                if (check1 == "7true " || check == "7.1true ")
                {
                    card7.BackgroundImage = Properties.Resources.SW_7;
                    card7_Dup.BackgroundImage = Properties.Resources.SW_7;


                }
                if (check1 == "8true " || check == "8.1true ")
                {
                    card8.BackgroundImage = Properties.Resources.SW_8;
                    card8_Dup.BackgroundImage = Properties.Resources.SW_8;


                }
                count++;
                checkForWinner = checkForWinner2;
            }
            CheckForWinner();

        }

        private void SaveMemoryButton_Click(object sender, EventArgs e)
        {
            SaveMemory();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            loadMemory();
        }

        /// <summary>
        /// Integer die de beurten telt
        /// </summary>

        public int playercount = 0;

        /// <summary>
        /// Method die bij houdt hoeveel beurten er zijn geweest en dus wie nu aan de beurt is
        /// </summary>
        /// <returns></returns>

        private int SwitchPlayer()
        {
            playercount ++; //1 beurt geweest

            if (playercount % 2 == 0) //Als er een even aantal beurten is geweest is Player1
            {
                player1.Text = SavingClass.varplayername;
            }

            if (playercount % 2 != 0) //Als er een oneven aantal beurten is geweest is Player2
            {
                player1.Text = Player2.Player2Name;
            }

            return playercount;
        }

        /// <summary>
        /// Geeft de score teller weer op het scherm bij 0 punten
        /// </summary>

        public void ZeroPoints()
        {
            score_Counter.Text = (SavingClass.varplayername + ": " + player1score + "   " + Environment.NewLine + Player2.Player2Name + ": " + player2score);
        }

        /// <summary>
        /// Method die kijkt wie aan de beurt was en voegt een punt toe bij die speler
        /// </summary>
         
        public void PlayerScore()
        {
            if (playercount % 2 == 0)
            {
                player1score++;
            }

            if (playercount % 2 != 0)
            {
                player2score++;                
            }

            score_Counter.Text = (SavingClass.varplayername+": " + player1score + "   " + Environment.NewLine +Player2.Player2Name+": " + player2score);
        }

        /// <summary>
        /// Method that calculates who won and gives the player name as a parameter
        /// </summary>
        /// <param name="winningplayer"></param>
        /// <returns></returns>

        public string WhoWon(string winningplayer)
        {

            if (player1score > player2score)
            {
                winningplayer = SavingClass.varplayername;
            }

            if (player1score < player2score)
            {
                winningplayer = Player2.Player2Name;
            }

            return winningplayer;            
        }

        private void ResetButtonMP_Click(object sender, EventArgs e)
        {
            Close();
            MemoryGameMultiplayer newMDIChild = new MemoryGameMultiplayer();          //opent het Memory spel in de mdi
            newMDIChild.MdiParent = Form.ActiveForm;               // "MemoryGame" moet veranderd worden naar de uiteindelijke memorygame class
            newMDIChild.Show();
        }
    }
}
