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
    /// Met deze class word de Achievements form weer gegeven.
    /// Hier kan de speler kijken welke Achievements hij behaald heeft en welke niet.
    /// </summary>
    public partial class Achievements : Form

    {/// <summary>
    /// Hier wordt alle methodes voor de Achievemts gestart.
    /// </summary>
        public Achievements()
        {
            InitializeComponent();
            Cursor cur = new Cursor(Properties.Resources.CursorFang.Handle);
            this.Cursor = cur;
            ClaimRewardButton.Visible = false;
            RewardsClaimedBanner.Visible = false;
            Achievement1Have();
            Achievement2Have();
            Achievement3Have();
            RewardClaim();
            
        }
        /// <summary>
        /// Dit is de back to menu knop
        /// </summary>
        private void AchievementsBackToMenu_Click(object sender, EventArgs e)
        {
            if (RewardsClaimedBanner.Visible == false)
            {
                Close();
                Menu newMDIChild = new Menu(); //Start de LeaderBoards op.
                newMDIChild.MdiParent = Form.ActiveForm; // Set the Parent Form of the Child window.    
                newMDIChild.Show();  // Display the new form.
            }

        }
        /// <summary>
        /// Hier wordt gecontroleerd of de speler Achievement 1 heeft.
        /// </summary>
        public void Achievement1Have()
        {
            if (SavingClass.varAchievement1Have == "true")
            {
                FinishedFirstGameHAVE2.Visible = false;
            }
        }
        /// <summary>
        /// Hier wordt gecontroleerd of de speler Achievement 2 heeft.
        /// </summary>
        public void Achievement2Have()
        {
            if (SavingClass.varAchievement2Have == "true")
            {
                MatchesInARowHAVE.Visible = false;
            }
        }
        /// <summary>
        /// Hier wordt gecontroleerd of de speler Achievement 3 heeft.
        /// </summary>
        public void Achievement3Have()
        {
            if (SavingClass.varAchievement3Have == "true")
            {
                MatchFirstTryHAVE.Visible = false;
            }
        }
        /// <summary>
        /// Hier wordt gecontroleerd of de speler de reward geclaimed heeft
        /// </summary>
        public void RewardClaim()
        {
            if (SavingClass.varRewardsClaimed == "false")
            {
                if (SavingClass.varAchievement1Have == "true" && SavingClass.varAchievement2Have == "true" && SavingClass.varAchievement3Have == "true")
                {
                    ClaimRewardButton.Visible = true;
                    TipBanner.Visible = false;
                }
            }
            
            if (SavingClass.varRewardsClaimed == "true") // Zorgt er voor dat de Tip Banner (die je ziet als je nog niet alle achievements hebt) niet meer zichtbaar is, nadat je de reward hebt geclaimed.
            {
                TipBanner.Visible = false;
            }
        }
        /// <summary>
        /// hiermee claimd de speler de reward
        /// </summary>
        private void ClaimRewardButton_Click(object sender, EventArgs e)
        {
            SavingClass.varRewardsClaimed = "true";
            ClaimRewardButton.Visible = false;
            Timer timerzerocurrency = new Timer();
            RewardsClaimedBanner.Visible = true;
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(3500);
                Invoke(new Action(() =>
                {
                    RewardsClaimedBanner.Visible = false;

                }));
            });
            SavingClass.varCurrency += 1000;
            SavingClass.savedata();
        }
    }
}
