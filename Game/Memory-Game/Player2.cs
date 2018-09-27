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
{/// <summary>
/// Hier wordt het menu opgestart voor de naam van de 2e speler bij de multieplayer
/// </summary>
    public partial class Player2 : Form
    {
        /// <summary>
        /// Dit laat de textbox met de naam van de 2e speler
        /// </summary>
        public Player2()
        {
            InitializeComponent();
            Cursor cur = new Cursor(Properties.Resources.CursorFang.Handle);
            this.Cursor = cur;
            NamePlayer2TextBox.Text = Player2Name;
            
        }/// <summary>
        /// De string die wordt gebruikt voor de naam van de 2e speler
        /// </summary>
        public static string Player2Name;

        /// <summary>
        /// Dit maakt de textbox eerst leeg als je er op clickt
        /// </summary>
        private void NamePlayer2TextBox_Click(object sender, EventArgs e)
        {
            NamePlayer2TextBox.Text = " ";

        }
        /// <summary>
        /// Nadat de naam ingevuld is kan de speler door gaan naar het memory spel, Dit wordt hier opgestart wanneer er op de knop gedrukt wordt.
        /// </summary>
        private void ContinueToMPButton_Click(object sender, EventArgs e)
        {
            Player2Name = NamePlayer2TextBox.Text;
            Close();
            MemoryGameMultiplayer newMDIChild = new MemoryGameMultiplayer();
            newMDIChild.MdiParent = Form.ActiveForm;
            newMDIChild.Show();
        }
    }
}
