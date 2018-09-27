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
    public partial class Store : Form
    {
        /// <summary>
        /// Dit zorgt er voor dat als er geen andere card pack is geselecteerd na eerste opstart, de game standaard Disney gebruikt in MemoryGame.cs.
        /// </summary>
        public static string invoer = "";

        /// <summary>
        /// Dit initialiseert de standaard variables in de store, zoals de custom cursor en pictureboxes die default op onzichtbaar staan.
        /// </summary>
        public Store()
        {
            InitializeComponent();

            Cursor cur = new Cursor(Properties.Resources.CursorFang.Handle); // Dit maakt een nieuwe cursor aan en geeft aan welke file in de Resources gebruikt wordt.
            Cursor = cur; // Dit activeert de cursor.

            ZeroCurrency.Visible = false;
            NotEnoughCurrency.Visible = false;
            OWPackBought.Visible = false;
            

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            savestringcurrency();
            selectcardback();
            OWBought();
        }

        /// <summary>
        /// Kijkt in de Save File of de OverWatch card pack gekocht is, om vervolgens definitief de "Buy" knop onzichtbaar te maken.
        /// </summary>
        public void OWBought()
        {
            if (SavingClass.varOWbought == "true")
            {
                OWBuyButton.Visible = false;                
            }
        }

        /// <summary>
        /// Dit kijkt in de Save File welke card pack er geselecteerd is, om vervolgens bij opstarten de juiste "Selected" knop weer te geven, door middel van bepaalde Pictureboxes uit te zetten.
        /// </summary>
        public void selectcardback()
        {
            if (SavingClass.varCardBack == "D")
            {
                SelectDisney.Visible = false;
                SelectStarwars.Visible = true;
                SelectOverWatch.Visible = true;
            } else
            if (SavingClass.varCardBack == "SW")
            {
                SelectDisney.Visible = true;
                SelectOverWatch.Visible = true;
                SelectStarwars.Visible = false;
            }else
            if (SavingClass.varCardBack == "OW")
            {
                SelectOverWatch.Visible = false;
                SelectDisney.Visible = true;
                SelectStarwars.Visible = true;
            }
            else
            if (SavingClass.varCardBack == "")
            {
                SelectOverWatch.Visible = true;
                SelectDisney.Visible = true;
                SelectStarwars.Visible = true;
            }
        }

        /// <summary>
        /// Dit stuurt de waarde van varCurrency die in de Save File staat, naar de in deze form aanwezige Textbox genaamd CurrentCurrency.
        /// </summary>
        public void savestringcurrency()
        {
            CurrentCurrency.Text = Convert.ToString(SavingClass.varCurrency);
        }

        /// <summary>
        /// Dit wordt gedaan als button1_click wordt aangeklikt (Back to Menu button)
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (OWPackBought.Visible == false && ZeroCurrency.Visible == false && NotEnoughCurrency.Visible == false) // Dit zorgt er voor dat de button1_click alleen werkt als de 3 pictureboxes (waar timers onder zitten) weg zijn, om een bug te voorkomen.
            {
                SavingClass.savedata();
                Close();
                Menu newMDIChild = new Menu(); // Start het Menu form op. 
                newMDIChild.MdiParent = Form.ActiveForm;  // Geeft aan wat de parent form is en de child form.
                newMDIChild.Show();  // Geeft het nieuwe form weer.
            }
        }

        /// <summary>
        /// Dit wordt gedaan als de Disney knop in de store wordt aangeklikt.
        /// </summary>
        public void SelectDisney_Click(object sender, EventArgs e)
        {
            SelectDisney.Visible = false; // Dit maakt de "Select" knop onder Disney onzichtbaar, zodat de "Selected" knop over blijft, zodat de user door heeft dat Disney geselecteerd is.
            SavingClass.varCardBack = "D"; // Dit schrijft de geselecteerde Card Pack naar een regel in de Save File.
            SelectOverWatch.Visible = true; // Dit maakt de "Select" knoppen van de andere 2 cardpacks weer zichtbaar.
            SelectStarwars.Visible = true; //^
            SavingClass.savedata(); // Dit zorgt er voor dat de Save File daadwerkelijk wordt opgeslagen.
            invoer = "D";

        }

        /// <summary>
        /// Dit wordt gedaan als de Star Wars knop in de store wordt aangeklikt.
        /// </summary>
        public void SelectStarwars_Click(object sender, EventArgs e)
        {
            SelectStarwars.Visible = false; // Dit maakt de "Select" knop onder Star Wars onzichtbaar, zodat de "Selected" knop over blijft, zodat de user door heeft dat Star Wars geselecteerd is.
            SavingClass.varCardBack = "SW"; // Dit schrijft de geselecteerde Card Pack naar een regel in de Save File.
            SelectDisney.Visible = true; // Dit maakt de "Select" knoppen van de andere 2 cardpacks weer zichtbaar.
            SelectOverWatch.Visible = true; //^
            SavingClass.savedata(); // Dit zorgt er voor dat de Save File daadwerkelijk wordt opgeslagen.
            invoer = "SW";
        }

        /// <summary>
        /// Dit wordt gedaan als de OverWatch knop in de store wordt aangeklikt.
        /// </summary>
        public void SelectOverWatch_Click(object sender, EventArgs e)
        {
            SelectOverWatch.Visible = false; // Dit maakt de "Select" knop onder OverWatch onzichtbaar, zodat de "Selected" knop over blijft, zodat de user door heeft dat OverWatch geselecteerd is.
            SavingClass.varCardBack = "OW"; // Dit schrijft de geselecteerde Card Pack naar een regel in de Save File.
            SelectDisney.Visible = true; // Dit maakt de "Select" knoppen van de andere 2 cardpacks weer zichtbaar.
            SelectStarwars.Visible = true; //^
            SavingClass.savedata(); // Dit zorgt er voor dat de Save File daadwerkelijk wordt opgeslagen.
            invoer = "OW";
        }

        /// <summary>
        /// Deze Public wordt aangeroepen als er op de Buy Button in de store geklikt wordt. Wat er daarna gebeurt is afhankelijk van het huidige aantal currency, 
        /// en wordt hieronder uitgelegd.
        /// </summary>
        public void OWBuyButton_Click(object sender, EventArgs e) // Dit is het stuk code wat er gebeurt als je op de Buy knop klikt om de Overwatch Card Pack te kopen.
        {
            int CurrentMoney = SavingClass.varCurrency;
            int Newmoney;

            if (CurrentMoney == 0) // Dit kijkt of je precies 0 currency hebt, en geeft dan aan dat je eerst wat games moet gaan spelen, door middel van een PictureBox en een Timer.
            {
                Timer timerzerocurrency = new Timer(); // Deze timer wordt gebruikt als je 0 currency hebt, en maakt de Picturebox ZeroCurrency tijdelijk visible.
                ZeroCurrency.Visible = true;
                Task.Run(() =>
                {
                    System.Threading.Thread.Sleep(2000);
                    Invoke(new Action(() =>
                    {
                        ZeroCurrency.Visible = false;
                        
                    }));
                });
            }

            if (CurrentMoney >= 2500) // Dit kijkt of je meer dan 2500 currency hebt, zodat je de OverWatch Card Pack kan kopen.
            {
                OWBuyButton.Visible = false; // Dit maakt de "Buy" knop onzichtbaar, omdat je succesvol de OverWatch Card Pack hebt gekocht
                
                Timer timerpackbought = new Timer(); // Deze timer wordt gebruikt als je MEER dan 2500 currency hebt, en maakt de Picturebox OWPackBought tijdelijk visible.
                OWPackBought.Visible = true;
                Task.Run(() =>
                {
                    System.Threading.Thread.Sleep(2000);
                    Invoke(new Action(() =>
                    {
                        OWPackBought.Visible = false;
                    }));
                });
                Newmoney = CurrentMoney - 2500;  // Dit haalt 2500 van je huidige currency af, omdat je succesvol de OverWatch card pack hebt gekocht.
                SavingClass.varOWbought = "true"; // Dit noteert in de Save File dat de OverWatch Card Pack is gekocht.
                SavingClass.varCurrency = Newmoney; 
                CurrentCurrency.Text = Convert.ToString(Newmoney);
            }

            else // Deze code kijkt naar alle andere opties, oftewel 1 tot en met 2499, en geeft dan aan dat je niet genoeg currency hebt.
            {
                Timer timernotenough = new Timer(); // Deze timer wordt gebruikt als je MINDER dan 2500 currency hebt, en maakt de Picturebox NotEnoughCurrency tijdelijk visible.
                NotEnoughCurrency.Visible = true;
                Task.Run(() =>
                {
                    System.Threading.Thread.Sleep(2000);
                    Invoke(new Action(() =>
                    {
                        NotEnoughCurrency.Visible = false;
                    }));
                });
            }
            SavingClass.savedata(); // Dit slaat alles op wat er gebeurd is, nadat de Buy knop is ingedrukt.
        }
    }
}
