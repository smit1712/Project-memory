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
    public partial class ChooseYourDifficulty : Form
    {
        public ChooseYourDifficulty()
        {
            InitializeComponent();
            Cursor cur = new Cursor(Properties.Resources.CursorFang.Handle);
            this.Cursor = cur;
        }

        private void NormalButton_Click(object sender, EventArgs e)
        {
            Close();
            MemoryGame newMDIChild = new MemoryGame();          //opent het Memory spel in de mdi
            newMDIChild.MdiParent = Form.ActiveForm;
            newMDIChild.Show();
        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            Close();
            MemoryGameHard newMDIChild = new MemoryGameHard();  //opent het Memory spel hard in de mdi
            newMDIChild.MdiParent = Form.ActiveForm;
            newMDIChild.Show();
        }

        private void MPPlayButton_Click(object sender, EventArgs e)
        {
            Close();
            Player2 newMDIChild = new Player2();                //opent het form voor player 2's naam invullen
            newMDIChild.MdiParent = Form.ActiveForm;
            newMDIChild.Show();
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            Close();
            Menu newMDIChild = new Menu(); // Start het Menu form op. 
            newMDIChild.MdiParent = Form.ActiveForm;  // Geeft aan wat de parent form is en de child form.
            newMDIChild.Show();  // Geeft het nieuwe form weer.
        }
    }
}
