namespace Memory_Game
{
    partial class ChooseYourDifficulty
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
            this.NormalButton = new System.Windows.Forms.PictureBox();
            this.HardButton = new System.Windows.Forms.PictureBox();
            this.MPPlayButton = new System.Windows.Forms.PictureBox();
            this.BackToMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NormalButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MPPlayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackToMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // NormalButton
            // 
            this.NormalButton.BackColor = System.Drawing.Color.Transparent;
            this.NormalButton.BackgroundImage = global::Memory_Game.Properties.Resources.Normal;
            this.NormalButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NormalButton.Location = new System.Drawing.Point(379, 426);
            this.NormalButton.Name = "NormalButton";
            this.NormalButton.Size = new System.Drawing.Size(435, 136);
            this.NormalButton.TabIndex = 0;
            this.NormalButton.TabStop = false;
            this.NormalButton.Click += new System.EventHandler(this.NormalButton_Click);
            // 
            // HardButton
            // 
            this.HardButton.BackColor = System.Drawing.Color.Transparent;
            this.HardButton.BackgroundImage = global::Memory_Game.Properties.Resources.Hard;
            this.HardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.HardButton.Location = new System.Drawing.Point(379, 566);
            this.HardButton.Name = "HardButton";
            this.HardButton.Size = new System.Drawing.Size(434, 136);
            this.HardButton.TabIndex = 1;
            this.HardButton.TabStop = false;
            this.HardButton.Click += new System.EventHandler(this.HardButton_Click);
            // 
            // MPPlayButton
            // 
            this.MPPlayButton.BackColor = System.Drawing.Color.Transparent;
            this.MPPlayButton.BackgroundImage = global::Memory_Game.Properties.Resources.MPPlay;
            this.MPPlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MPPlayButton.Location = new System.Drawing.Point(1134, 426);
            this.MPPlayButton.Name = "MPPlayButton";
            this.MPPlayButton.Size = new System.Drawing.Size(413, 137);
            this.MPPlayButton.TabIndex = 2;
            this.MPPlayButton.TabStop = false;
            this.MPPlayButton.Click += new System.EventHandler(this.MPPlayButton_Click);
            // 
            // BackToMenu
            // 
            this.BackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.BackToMenu.BackgroundImage = global::Memory_Game.Properties.Resources.Back_to_menu;
            this.BackToMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BackToMenu.Location = new System.Drawing.Point(1433, 815);
            this.BackToMenu.Name = "BackToMenu";
            this.BackToMenu.Size = new System.Drawing.Size(406, 178);
            this.BackToMenu.TabIndex = 3;
            this.BackToMenu.TabStop = false;
            this.BackToMenu.Click += new System.EventHandler(this.BackToMenu_Click);
            // 
            // ChooseYourDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory_Game.Properties.Resources.ChooseDifficultyScreen2;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.BackToMenu);
            this.Controls.Add(this.MPPlayButton);
            this.Controls.Add(this.HardButton);
            this.Controls.Add(this.NormalButton);
            this.Name = "ChooseYourDifficulty";
            this.Text = "ChooseYourDifficulty";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.NormalButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MPPlayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackToMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox NormalButton;
        private System.Windows.Forms.PictureBox HardButton;
        private System.Windows.Forms.PictureBox MPPlayButton;
        private System.Windows.Forms.PictureBox BackToMenu;
    }
}