namespace Memory_Game
{
    partial class Player2
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
            this.NamePlayer2TextBox = new System.Windows.Forms.TextBox();
            this.ContinueToMPButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NamePlayer2TextBox
            // 
            this.NamePlayer2TextBox.BackColor = System.Drawing.Color.Moccasin;
            this.NamePlayer2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NamePlayer2TextBox.Font = new System.Drawing.Font("Harlow Solid Italic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamePlayer2TextBox.Location = new System.Drawing.Point(838, 333);
            this.NamePlayer2TextBox.Name = "NamePlayer2TextBox";
            this.NamePlayer2TextBox.Size = new System.Drawing.Size(231, 34);
            this.NamePlayer2TextBox.TabIndex = 3;
            this.NamePlayer2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NamePlayer2TextBox.Click += new System.EventHandler(this.NamePlayer2TextBox_Click);
            // 
            // ContinueToMPButton
            // 
            this.ContinueToMPButton.BackColor = System.Drawing.Color.Transparent;
            this.ContinueToMPButton.FlatAppearance.BorderSize = 0;
            this.ContinueToMPButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ContinueToMPButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ContinueToMPButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContinueToMPButton.Location = new System.Drawing.Point(838, 387);
            this.ContinueToMPButton.Name = "ContinueToMPButton";
            this.ContinueToMPButton.Size = new System.Drawing.Size(231, 81);
            this.ContinueToMPButton.TabIndex = 4;
            this.ContinueToMPButton.UseVisualStyleBackColor = false;
            this.ContinueToMPButton.Click += new System.EventHandler(this.ContinueToMPButton_Click);
            // 
            // Player2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory_Game.Properties.Resources.EnterPlayer2Name;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.ContinueToMPButton);
            this.Controls.Add(this.NamePlayer2TextBox);
            this.Name = "Player2";
            this.Text = "Player2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NamePlayer2TextBox;
        private System.Windows.Forms.Button ContinueToMPButton;
    }
}