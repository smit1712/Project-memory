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
/// Deze class is voor de MDI parent van ons memory spel. in het kader wat deze class maakt komen de andere forms.
/// Hier worden dus de belangerijkste data geladen en het hoofdmenu als mdi child opgestart.
/// </summary>
    public partial class MainMenu : Form
    {
        System.Media.SoundPlayer menumusic = new System.Media.SoundPlayer();        // Maakt audioplayer aan genaamd menumusic
        public MainMenu()
        {
            InitializeComponent();
            menumusic.Stream = Properties.Resources.GoT1;           //  Vertelt welke audiofile de audioplayer genaamd menumusic moet afspelen.
            menumusic.PlayLooping();                                   // Speelt de audiofile af, in een loop
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }
        /// <summary>
        /// Dit gebeurd on load. dit is gedeeldelijk een stuk history wat omgebouwt is.
        /// </summary>
        private void leaderboardToolStripMenuItem_Click(object sender, EventArgs e)//event voor het laden van het menu
        {
        
            LoadMainMenu();
        }

        /// <summary>
        /// maaakt alle variable die nodig zijn voor de speler, indien dit er al is gaat hij door naar het menu en worden deze geladen.
        /// </summary>
        private void LoadMainMenu()
        {
            string currency;
            int Icurrency;
            if (Directory.Exists(SavingClass.path))
            {
                string[] name = System.IO.File.ReadAllLines(SavingClass.path + "PlayerName.sav");
                SavingClass.varplayername = name[0];

                string[] lines = System.IO.File.ReadAllLines(SavingClass.path + "memory"+SavingClass.varplayername+ ".sav");
                currency = lines[1];
                Icurrency = Convert.ToInt32(currency);
                SavingClass.varCurrency = Icurrency;
                SavingClass.varCardBack = lines[2];
                SavingClass.varHardmode = lines[3];
                SavingClass.varOWbought = lines[6];
                SavingClass.varAchievement1Have = lines[7];
                SavingClass.varAchievement2Have = lines[8];
                SavingClass.varAchievement3Have = lines[9];
                SavingClass.varRewardsClaimed = lines[10];

                Store.invoer = SavingClass.varCardBack;
           
                
                Menu newMDIChild = new Menu(); //Start het menu spel op.
                // Set the Parent Form of the Child window.  
                newMDIChild.MdiParent = ActiveForm;
                // Display the new form.  
                newMDIChild.Show();
            }
           else
            {

                playername newMDIChild = new playername(); //Start de playername  op.
                newMDIChild.MdiParent = ActiveForm;
                // Set the Parent Form of the Child window.  
                newMDIChild.MdiParent = Form.ActiveForm;
                // Display the new form.  
                newMDIChild.Show();


            }

        }
    }
}
