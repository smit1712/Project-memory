namespace Memory_Game
{
    partial class Store
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Store));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.SelectDisney = new System.Windows.Forms.Button();
            this.SelectStarwars = new System.Windows.Forms.Button();
            this.SelectOverWatch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SelectedDisney = new System.Windows.Forms.PictureBox();
            this.SelectedSW = new System.Windows.Forms.PictureBox();
            this.SelectedOW = new System.Windows.Forms.PictureBox();
            this.OWBuyButton = new System.Windows.Forms.PictureBox();
            this.OWPackBought = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.CurrentCurrency = new System.Windows.Forms.TextBox();
            this.NotEnoughCurrency = new System.Windows.Forms.PictureBox();
            this.ZeroCurrency = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedDisney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedSW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedOW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OWBuyButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OWPackBought)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotEnoughCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZeroCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Memory_Game.Properties.Resources.DisneyLogoShadowStore;
            this.pictureBox1.Location = new System.Drawing.Point(527, 360);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 197);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Memory_Game.Properties.Resources.StarWarsLogoShadowStore;
            this.pictureBox2.Location = new System.Drawing.Point(864, 360);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(210, 201);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::Memory_Game.Properties.Resources.StoreBannerShadow;
            this.pictureBox3.Location = new System.Drawing.Point(698, 131);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(549, 137);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Memory_Game.Properties.Resources.OverwatchLogoShadowStore;
            this.pictureBox4.Location = new System.Drawing.Point(1203, 360);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(213, 199);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // SelectDisney
            // 
            this.SelectDisney.BackColor = System.Drawing.Color.Transparent;
            this.SelectDisney.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SelectDisney.BackgroundImage")));
            this.SelectDisney.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SelectDisney.FlatAppearance.BorderSize = 0;
            this.SelectDisney.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SelectDisney.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SelectDisney.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectDisney.Location = new System.Drawing.Point(539, 565);
            this.SelectDisney.Name = "SelectDisney";
            this.SelectDisney.Size = new System.Drawing.Size(184, 76);
            this.SelectDisney.TabIndex = 4;
            this.SelectDisney.UseVisualStyleBackColor = false;
            this.SelectDisney.Click += new System.EventHandler(this.SelectDisney_Click);
            // 
            // SelectStarwars
            // 
            this.SelectStarwars.BackColor = System.Drawing.Color.Transparent;
            this.SelectStarwars.BackgroundImage = global::Memory_Game.Properties.Resources.Select_minibutton;
            this.SelectStarwars.FlatAppearance.BorderSize = 0;
            this.SelectStarwars.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SelectStarwars.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SelectStarwars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectStarwars.Location = new System.Drawing.Point(878, 567);
            this.SelectStarwars.Name = "SelectStarwars";
            this.SelectStarwars.Size = new System.Drawing.Size(180, 76);
            this.SelectStarwars.TabIndex = 5;
            this.SelectStarwars.UseVisualStyleBackColor = false;
            this.SelectStarwars.Click += new System.EventHandler(this.SelectStarwars_Click);
            // 
            // SelectOverWatch
            // 
            this.SelectOverWatch.BackColor = System.Drawing.Color.Transparent;
            this.SelectOverWatch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SelectOverWatch.BackgroundImage")));
            this.SelectOverWatch.FlatAppearance.BorderSize = 0;
            this.SelectOverWatch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SelectOverWatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SelectOverWatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectOverWatch.Location = new System.Drawing.Point(1214, 567);
            this.SelectOverWatch.Name = "SelectOverWatch";
            this.SelectOverWatch.Size = new System.Drawing.Size(180, 74);
            this.SelectOverWatch.TabIndex = 6;
            this.SelectOverWatch.UseVisualStyleBackColor = false;
            this.SelectOverWatch.Click += new System.EventHandler(this.SelectOverWatch_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Memory_Game.Properties.Resources.Back_to_menu_button;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1445, 828);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(379, 146);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectedDisney
            // 
            this.SelectedDisney.BackColor = System.Drawing.Color.Transparent;
            this.SelectedDisney.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SelectedDisney.BackgroundImage")));
            this.SelectedDisney.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SelectedDisney.Location = new System.Drawing.Point(539, 565);
            this.SelectedDisney.Name = "SelectedDisney";
            this.SelectedDisney.Size = new System.Drawing.Size(167, 64);
            this.SelectedDisney.TabIndex = 8;
            this.SelectedDisney.TabStop = false;
            // 
            // SelectedSW
            // 
            this.SelectedSW.BackColor = System.Drawing.Color.Transparent;
            this.SelectedSW.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SelectedSW.BackgroundImage")));
            this.SelectedSW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SelectedSW.Location = new System.Drawing.Point(878, 567);
            this.SelectedSW.Name = "SelectedSW";
            this.SelectedSW.Size = new System.Drawing.Size(167, 64);
            this.SelectedSW.TabIndex = 9;
            this.SelectedSW.TabStop = false;
            // 
            // SelectedOW
            // 
            this.SelectedOW.BackColor = System.Drawing.Color.Transparent;
            this.SelectedOW.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SelectedOW.BackgroundImage")));
            this.SelectedOW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SelectedOW.Location = new System.Drawing.Point(1214, 567);
            this.SelectedOW.Name = "SelectedOW";
            this.SelectedOW.Size = new System.Drawing.Size(167, 64);
            this.SelectedOW.TabIndex = 10;
            this.SelectedOW.TabStop = false;
            // 
            // OWBuyButton
            // 
            this.OWBuyButton.BackColor = System.Drawing.Color.Transparent;
            this.OWBuyButton.BackgroundImage = global::Memory_Game.Properties.Resources._2500bitcoin;
            this.OWBuyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OWBuyButton.Location = new System.Drawing.Point(1211, 563);
            this.OWBuyButton.Name = "OWBuyButton";
            this.OWBuyButton.Size = new System.Drawing.Size(188, 84);
            this.OWBuyButton.TabIndex = 11;
            this.OWBuyButton.TabStop = false;
            this.OWBuyButton.Click += new System.EventHandler(this.OWBuyButton_Click);
            // 
            // OWPackBought
            // 
            this.OWPackBought.BackColor = System.Drawing.Color.Transparent;
            this.OWPackBought.BackgroundImage = global::Memory_Game.Properties.Resources.CardPackBoughtFinal;
            this.OWPackBought.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OWPackBought.Location = new System.Drawing.Point(617, 654);
            this.OWPackBought.Name = "OWPackBought";
            this.OWPackBought.Size = new System.Drawing.Size(714, 273);
            this.OWPackBought.TabIndex = 12;
            this.OWPackBought.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = global::Memory_Game.Properties.Resources.CurrentBitsIcon;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox5.Location = new System.Drawing.Point(1432, 78);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(415, 162);
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // CurrentCurrency
            // 
            this.CurrentCurrency.BackColor = System.Drawing.Color.Gold;
            this.CurrentCurrency.Font = new System.Drawing.Font("Harlow Solid Italic", 24.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentCurrency.Location = new System.Drawing.Point(1576, 145);
            this.CurrentCurrency.Name = "CurrentCurrency";
            this.CurrentCurrency.Size = new System.Drawing.Size(116, 49);
            this.CurrentCurrency.TabIndex = 14;
            this.CurrentCurrency.Text = "520";
            this.CurrentCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NotEnoughCurrency
            // 
            this.NotEnoughCurrency.BackColor = System.Drawing.Color.Transparent;
            this.NotEnoughCurrency.BackgroundImage = global::Memory_Game.Properties.Resources.NotEnoughCurrencyFinal;
            this.NotEnoughCurrency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NotEnoughCurrency.Location = new System.Drawing.Point(617, 654);
            this.NotEnoughCurrency.Name = "NotEnoughCurrency";
            this.NotEnoughCurrency.Size = new System.Drawing.Size(714, 273);
            this.NotEnoughCurrency.TabIndex = 15;
            this.NotEnoughCurrency.TabStop = false;
            // 
            // ZeroCurrency
            // 
            this.ZeroCurrency.BackColor = System.Drawing.Color.Transparent;
            this.ZeroCurrency.BackgroundImage = global::Memory_Game.Properties.Resources.ZeroCurrencyFinal;
            this.ZeroCurrency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ZeroCurrency.Location = new System.Drawing.Point(617, 654);
            this.ZeroCurrency.Name = "ZeroCurrency";
            this.ZeroCurrency.Size = new System.Drawing.Size(714, 273);
            this.ZeroCurrency.TabIndex = 16;
            this.ZeroCurrency.TabStop = false;
            // 
            // Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory_Game.Properties.Resources.Background_no_buttons;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.CurrentCurrency);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.OWBuyButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SelectOverWatch);
            this.Controls.Add(this.SelectStarwars);
            this.Controls.Add(this.SelectDisney);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SelectedDisney);
            this.Controls.Add(this.SelectedSW);
            this.Controls.Add(this.SelectedOW);
            this.Controls.Add(this.ZeroCurrency);
            this.Controls.Add(this.NotEnoughCurrency);
            this.Controls.Add(this.OWPackBought);
            this.DoubleBuffered = true;
            this.Name = "Store";
            this.Text = "Store";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedDisney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedSW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedOW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OWBuyButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OWPackBought)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotEnoughCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZeroCurrency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button SelectDisney;
        private System.Windows.Forms.Button SelectStarwars;
        private System.Windows.Forms.Button SelectOverWatch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox SelectedDisney;
        private System.Windows.Forms.PictureBox SelectedSW;
        private System.Windows.Forms.PictureBox SelectedOW;
        private System.Windows.Forms.PictureBox OWBuyButton;
        private System.Windows.Forms.PictureBox OWPackBought;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox CurrentCurrency;
        private System.Windows.Forms.PictureBox NotEnoughCurrency;
        private System.Windows.Forms.PictureBox ZeroCurrency;
    }
}