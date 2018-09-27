using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game
{
    /// <summary>
    /// In deze class wordt het hoofdmenu geladen. Hierin zijn vooral de knoppen verzameld om naar de verschillende pagina's te gaan van ons memory spel.
    ///Zoals het spel zelf en de leaderboards
    /// </summary>
    public partial class Menu : Form
    {
        /// <summary>
        /// Hier start hij het hoofdmenu op en selecteerd de juiste background.
        /// </summary>
        public Menu()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            // moeilijkheidgraad();
            NameLabel.Text = SavingClass.varplayername;

            if (SavingClass.varRewardsClaimed == "true")
            {
                this.BackgroundImage = Properties.Resources.MainMenuFinalReward;
            }
        }

        /// <summary>
        /// Dit is de play button, deze brengt de speler naar de juiste gamemode op basis van de geselecteerde radio button
        /// </summary>        
        private void PlayButton_Click(object sender, EventArgs e)
        {
            Close();
            ChooseYourDifficulty newMDIChild = new ChooseYourDifficulty();
            newMDIChild.MdiParent = Form.ActiveForm;
            newMDIChild.Show();              
        }

        /// <summary>
        /// Dit is de to store button
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Store newMDIChild = new Store(); //Start de store op.
            newMDIChild.MdiParent = Form.ActiveForm; // Set the Parent Form of the Child window.
            newMDIChild.Show(); // Display the new form.
        }

        /// <summary>
        /// Hier wordt de custom button geladen
        /// </summary>
        private void Menu_Load(object sender, EventArgs e)
        {
            Cursor cur = new Cursor(Properties.Resources.CursorFang.Handle);
            this.Cursor = cur;
        }

        /// <summary>
        /// Hier wordt het spel mee afgesloten.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            SavingClass.savedata();
            Application.Exit();
        }

        /// <summary>
        /// Deze knop brengt de speler naar de leaderboards.
        /// </summary>
        private void LeaderBoards1Button_Click(object sender, EventArgs e)
        {
            Close();
            LeaderBoards newMDIChild = new LeaderBoards(); //Start de Leaderboards op.  
            newMDIChild.MdiParent = Form.ActiveForm; // Set the Parent Form of the Child window.
            newMDIChild.Show(); // Display the new form.
        }

        /// <summary>
        /// Dit start de Achievements op.
        /// </summary>
        private void TrophyButton_Click(object sender, EventArgs e)
        {
            Close();
            Achievements newMDIChild = new Achievements(); //Start de Achievements op.
            newMDIChild.MdiParent = Form.ActiveForm; // Set the Parent Form of the Child window.  
            newMDIChild.Show(); // Display the new form.
        }

        /// <summary>
        /// Dit start de changename menu op.
        /// </summary>
        private void ChangeNameButton_Click(object sender, EventArgs e)
        {
            Close();
            playername newMDIChild = new playername(); // Start de Playername form op, om vanaf het hoofdmenu de player name te veranderen. 
            newMDIChild.MdiParent = Form.ActiveForm; // Set the Parent Form of the Child window.   
            newMDIChild.Show(); // Display the new form.
        }

        private void CreditsButton_Click(object sender, EventArgs e)
        {
            Close();
            Credits newMDIChild = new Credits(); //Start de Credits op.  
            newMDIChild.MdiParent = Form.ActiveForm; // Set the Parent Form of the Child window.
            newMDIChild.Show(); // Display the new form.
        }
    }
}
