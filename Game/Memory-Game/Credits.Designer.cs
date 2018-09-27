namespace Memory_Game
{
    partial class Credits
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BackToMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BackToMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // BackToMenu
            // 
            this.BackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.BackToMenu.BackgroundImage = global::Memory_Game.Properties.Resources.Back_to_menu;
            this.BackToMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BackToMenu.Location = new System.Drawing.Point(1432, 816);
            this.BackToMenu.Name = "BackToMenu";
            this.BackToMenu.Size = new System.Drawing.Size(408, 175);
            this.BackToMenu.TabIndex = 0;
            this.BackToMenu.TabStop = false;
            this.BackToMenu.Click += new System.EventHandler(this.BackToMenu_Click);
            // 
            // Credits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory_Game.Properties.Resources.Credits1;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.BackToMenu);
            this.Name = "Credits";
            this.Text = "Credits";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.BackToMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BackToMenu;
    }
}