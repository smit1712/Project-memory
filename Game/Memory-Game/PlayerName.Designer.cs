namespace Memory_Game
{
    partial class playername
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
            this.Playernamesavebutten = new System.Windows.Forms.Button();
            this.NamePlayerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Playernamesavebutten
            // 
            this.Playernamesavebutten.BackColor = System.Drawing.Color.Transparent;
            this.Playernamesavebutten.BackgroundImage = global::Memory_Game.Properties.Resources.ContinueButton;
            this.Playernamesavebutten.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Playernamesavebutten.FlatAppearance.BorderSize = 0;
            this.Playernamesavebutten.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Playernamesavebutten.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Playernamesavebutten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Playernamesavebutten.ForeColor = System.Drawing.Color.Transparent;
            this.Playernamesavebutten.Location = new System.Drawing.Point(849, 392);
            this.Playernamesavebutten.Name = "Playernamesavebutten";
            this.Playernamesavebutten.Size = new System.Drawing.Size(211, 72);
            this.Playernamesavebutten.TabIndex = 1;
            this.Playernamesavebutten.UseVisualStyleBackColor = false;
            this.Playernamesavebutten.Click += new System.EventHandler(this.Playernamesavebutten_Click);
            // 
            // NamePlayerTextBox
            // 
            this.NamePlayerTextBox.BackColor = System.Drawing.Color.Moccasin;
            this.NamePlayerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NamePlayerTextBox.Font = new System.Drawing.Font("Harlow Solid Italic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamePlayerTextBox.Location = new System.Drawing.Point(839, 333);
            this.NamePlayerTextBox.Name = "NamePlayerTextBox";
            this.NamePlayerTextBox.Size = new System.Drawing.Size(231, 34);
            this.NamePlayerTextBox.TabIndex = 2;
            this.NamePlayerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NamePlayerTextBox.Click += new System.EventHandler(this.NamePlayerTextBox_Click);
            // 
            // playername
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory_Game.Properties.Resources.Enter_Name_Screen;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.NamePlayerTextBox);
            this.Controls.Add(this.Playernamesavebutten);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "playername";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PlayerName";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.playername_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Playernamesavebutten;
        private System.Windows.Forms.TextBox NamePlayerTextBox;
    }
}