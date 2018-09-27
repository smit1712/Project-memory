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
    public partial class Credits : Form
    {
        public Credits()
        {
            InitializeComponent();
            Cursor cur = new Cursor(Properties.Resources.CursorFang.Handle);
            this.Cursor = cur;
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            Close();
            Menu newMDIChild = new Menu(); //Start de LeaderBoards op.
            newMDIChild.MdiParent = Form.ActiveForm; // Set the Parent Form of the Child window.    
            newMDIChild.Show();  // Display the new form.
        }
    }
}
