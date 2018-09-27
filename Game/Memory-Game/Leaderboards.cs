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
    public partial class LeaderBoards : Form
    {/// <summary>
    /// Deze class geeft de leaderboard form weer en hide de scores waar geen waarde staat.
    /// </summary>
        public LeaderBoards()
        {
            InitializeComponent();
            Cursor cur = new Cursor(Properties.Resources.CursorFang.Handle);
            Cursor = cur;

            SwitchToSPButton.Visible = false;
            MPLeaderBoardsBanner.Visible = false;
            ToMediumButton.Visible = false;

            // Singleplayer HARD scores, hidden omdat Leaderboards op medium beginnen:
            Score1Hard.Visible = false;
            Score2Hard.Visible = false;
            Score3Hard.Visible = false;
            Score4Hard.Visible = false;
            Score5Hard.Visible = false;
            Score6Hard.Visible = false;
            Score7Hard.Visible = false;
            Score8Hard.Visible = false;
            Score9Hard.Visible = false;
            Score10Hard.Visible = false;

            // Multiplayer scores, hidden omdat Leaderboards op medium SP beginnen:
            Score1MP.Visible = false;
            Score2MP.Visible = false;
            Score3MP.Visible = false;
            Score4MP.Visible = false;
            Score5MP.Visible = false;
            Score6MP.Visible = false;
            Score7MP.Visible = false;
            Score8MP.Visible = false;
            Score9MP.Visible = false;
            Score10MP.Visible = false;

            leaderboard();
            leaderboardHard();
            leaderboardMP();
        }


        /// <summary>
        /// back to menu button
        /// </summary>
        private void BackToMenuLeaderBoards_Click_1(object sender, EventArgs e)
        {
            Close();
            Menu newMDIChild = new Menu(); //Start de LeaderBoards op.
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = Form.ActiveForm;
            // Display the new form.  
            newMDIChild.Show();
        }
        /// <summary>
        /// laad de normal scores vanuit het leaderboard.sav bestand en geeft deze weer
        /// </summary>
        public void leaderboard() 
        {
            SavingClass.LoadLeaderboard();

           
            Score1.Text = SavingClass.varScore1;
       
            Score2.Text = SavingClass.varScore2;
        
            score3.Text = SavingClass.varScore3;
         
            score4.Text = SavingClass.varScore4;
           
            score5.Text = SavingClass.varScore5;
          
            score6.Text = SavingClass.varScore6;
         
            score7.Text = SavingClass.varScore7;
           
            score8.Text = SavingClass.varScore8;
        
            score9.Text = SavingClass.varScore9;
            
            score10.Text = SavingClass.varScore10;

        }
        /// <summary>
        ///laad de hard scores vanuit het leaderboard.sav bestand en geeft deze weer
        /// </summary>
        public void leaderboardHard() 
        {
            SavingClass.LoadLeaderboardHard();

            Score1Hard.Text = SavingClass.varScore1Hard;

            Score2Hard.Text = SavingClass.varScore2Hard;

            Score3Hard.Text = SavingClass.varScore3Hard;

            Score4Hard.Text = SavingClass.varScore4Hard;

            Score5Hard.Text = SavingClass.varScore5Hard;

            Score6Hard.Text = SavingClass.varScore6Hard;

            Score7Hard.Text = SavingClass.varScore7Hard;

            Score8Hard.Text = SavingClass.varScore8Hard;

            Score9Hard.Text = SavingClass.varScore9Hard;

            Score10Hard.Text = SavingClass.varScore10;
        }
        /// <summary>
        ///laad de mp scores vanuit het leaderboard.sav bestand en geeft deze weer
        /// </summary>
        public void leaderboardMP() 
        {
            SavingClass.LoadLeaderboardMP();

            Score1MP.Text = SavingClass.varScore1MP;

            Score2MP.Text = SavingClass.varScore2MP;

            Score3MP.Text = SavingClass.varScore3MP;

            Score4MP.Text = SavingClass.varScore4MP;

            Score5MP.Text = SavingClass.varScore5MP;

            Score6MP.Text = SavingClass.varScore6MP;

            Score7MP.Text = SavingClass.varScore7MP;

            Score8MP.Text = SavingClass.varScore8MP;

            Score9MP.Text = SavingClass.varScore9MP;

            Score10MP.Text = SavingClass.varScore10MP;
        }
        /// <summary>
        /// laat de hard scores zien, ipv de normal scores
        /// </summary>
        private void ToHardButton_Click(object sender, EventArgs e)
        {
            LBHardBanner.Visible = true;
            ToHardButton.Visible = false;
            ToMediumButton.Visible = true;
            LBMediumBanner.Visible = false;

            Score1.Visible = false;
            Score2.Visible = false;
            score3.Visible = false;
            score4.Visible = false;
            score5.Visible = false;
            score6.Visible = false;
            score7.Visible = false;
            score8.Visible = false;
            score9.Visible = false;
            score10.Visible = false;

            // de volgende sectie maakt alle hard scores zichtbaar

            Score1Hard.Visible = true;
            Score2Hard.Visible = true;
            Score3Hard.Visible = true;
            Score4Hard.Visible = true;
            Score5Hard.Visible = true;
            Score6Hard.Visible = true;
            Score7Hard.Visible = true;
            Score8Hard.Visible = true;
            Score9Hard.Visible = true;
            Score10Hard.Visible = true;
        }
        /// <summary>
        /// dit maakt de normale score zichtbaar, ipv de hard
        /// </summary>
        private void ToMediumButton_Click(object sender, EventArgs e)
        {
            LBMediumBanner.Visible = true;
            LBHardBanner.Visible = false;
            ToMediumButton.Visible = false;
            ToHardButton.Visible = true;

            Score1Hard.Visible = false;
            Score2Hard.Visible = false;
            Score3Hard.Visible = false;
            Score4Hard.Visible = false;
            Score5Hard.Visible = false;
            Score6Hard.Visible = false;
            Score7Hard.Visible = false;
            Score8Hard.Visible = false;
            Score9Hard.Visible = false;
            Score10Hard.Visible = false;

            // de volgende sectie maakt alle medium scores zichtbaar
            Score1.Visible = true;
            Score2.Visible = true;
            score3.Visible = true;
            score4.Visible = true;
            score5.Visible = true;
            score6.Visible = true;
            score7.Visible = true;
            score8.Visible = true;
            score9.Visible = true;
            score10.Visible = true;
        }

        /// <summary>
        /// de volgende code is voor de multiplayer leaderboards
        /// </summary>
        
        private void SwitchToMPButton_Click(object sender, EventArgs e)
        {
            SwitchToMPButton.Visible = false;
            SwitchToSPButton.Visible = true;
            LeaderBoardsBanner.Visible = false;
            MPLeaderBoardsBanner.Visible = true;

            LBHardBanner.Visible = false;
            LBMediumBanner.Visible = false;

            ToMediumButton.Visible = false;
            ToHardButton.Visible = false;

            Score1MP.Visible = true;
            Score2MP.Visible = true;
            Score3MP.Visible = true;
            Score4MP.Visible = true;
            Score5MP.Visible = true;
            Score6MP.Visible = true;
            Score7MP.Visible = true;
            Score8MP.Visible = true;
            Score9MP.Visible = true;
            Score10MP.Visible = true;

            Score1.Visible = false;
            Score2.Visible = false;
            score3.Visible = false;
            score4.Visible = false;
            score5.Visible = false;
            score6.Visible = false;
            score7.Visible = false;
            score8.Visible = false;
            score9.Visible = false;
            score10.Visible = false;

            Score1Hard.Visible = false;
            Score2Hard.Visible = false;
            Score3Hard.Visible = false;
            Score4Hard.Visible = false;
            Score5Hard.Visible = false;
            Score6Hard.Visible = false;
            Score7Hard.Visible = false;
            Score8Hard.Visible = false;
            Score9Hard.Visible = false;
            Score10Hard.Visible = false;
        }
        /// <summary>
        /// de volgende code is voor de single leaderboards
        /// </summary>
        private void SwitchToSPButton_Click(object sender, EventArgs e)
        {
            SwitchToMPButton.Visible = true;
            SwitchToSPButton.Visible = false;
            LeaderBoardsBanner.Visible = true;
            MPLeaderBoardsBanner.Visible = false;

            LBHardBanner.Visible = false;
            LBMediumBanner.Visible = true;

            ToHardButton.Visible = true;

            Score1MP.Visible = false;
            Score2MP.Visible = false;
            Score3MP.Visible = false;
            Score4MP.Visible = false;
            Score5MP.Visible = false;
            Score6MP.Visible = false;
            Score7MP.Visible = false;
            Score8MP.Visible = false;
            Score9MP.Visible = false;
            Score10MP.Visible = false;

            Score1.Visible = true;
            Score2.Visible = true;
            score3.Visible = true;
            score4.Visible = true;
            score5.Visible = true;
            score6.Visible = true;
            score7.Visible = true;
            score8.Visible = true;
            score9.Visible = true;
            score10.Visible = true;
        }
    }
}
