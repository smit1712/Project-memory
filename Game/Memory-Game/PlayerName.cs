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
{/// <summary>
/// Deze class wordt gebruikt om de naam van de speler te vragen en opteslaan.
/// Als het programma voor de eerste keer wordt opgestart dan komt dit scherm ook in beeld
/// </summary>
    public partial class playername : Form
    {
        /// <summary>
        /// Hier wordt de cursor aangepast en de form geladen
        /// </summary>
        public playername()
        {
            InitializeComponent();
            Cursor cur = new Cursor(Properties.Resources.CursorFang.Handle);
            Cursor = cur;
            
        }


        /// <summary>
        /// Hier worden de naam van de speler opgeslagen en als het programma nog niet eerder opgestart is dan worden de noodzakelijke variable gemaakt en opgeslagen.
        /// Nadat dit gedaan is gaat hij door naar het hoofdmenu
        /// </summary>
        private void Playernamesavebutten_Click(object sender, EventArgs e)
        {
            string nameplayer = NamePlayerTextBox.Text;
            SavingClass.varplayername = nameplayer;
         

            string currency;
            int Icurrency;
            if (File.Exists(SavingClass.path + "memory" + SavingClass.varplayername + ".sav"))
            {


                string[] lines = System.IO.File.ReadAllLines(SavingClass.path + "memory" + SavingClass.varplayername + ".sav");
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
                //SavingClass.savedata();

            }
            
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(SavingClass.path);
                SavingClass.varCardBack = "D";
                SavingClass.varCurrency = 0;
                SavingClass.varHardmode = "false";
                SavingClass.varOWbought = "false";
                SavingClass.varAchievement1Have = "false";
                SavingClass.savedata();
            }


            Close();
            MdiParent = MainMenu.ActiveForm;
            Menu newMDIChild = new Menu(); //Start het menu spel op.
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = ActiveForm;
            // Display the new form.  
            newMDIChild.Show();
        }
        /// <summary>
        /// Hier wordt de naam van de speler geladen in de juiste variable
        /// </summary>
        private void playername_Load(object sender, EventArgs e)
        {
            NamePlayerTextBox.Text = SavingClass.varplayername;
        }
        /// <summary>
        /// wanneer er op de textbox geclickt wordt wordt hij leeg gemaakt.
        /// </summary>
        private void NamePlayerTextBox_Click(object sender, EventArgs e)
        {
            NamePlayerTextBox.Text = "";
        }
    }
}