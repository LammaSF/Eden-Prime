namespace EmojiHunter
{
    public partial class MainMenu
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            this.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.newGameButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.heroLabel = new System.Windows.Forms.Label();
            this.mapLabel = new System.Windows.Forms.Label();
            this.mapSpringLabel = new System.Windows.Forms.Label();
            this.sagittariusHeroLabel = new System.Windows.Forms.Label();
            this.aquariusHeroLabel = new System.Windows.Forms.Label();
            this.mapCenterLabel = new System.Windows.Forms.Label();
            this.highscoreButton = new System.Windows.Forms.Button();
            this.controlsLabel = new System.Windows.Forms.Label();
            this.highscoresLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.newGameButton.Font = new System.Drawing.Font("Snap ITC", 11.25F);
            this.newGameButton.Location = new System.Drawing.Point(34, 184);
            this.newGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(160, 75);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = false;
            this.newGameButton.Click += new System.EventHandler(this.OnNewGameButtonClick);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Snap ITC", 11.25F);
            this.saveButton.Location = new System.Drawing.Point(34, 263);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(160, 75);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save Game";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.loadButton.Enabled = false;
            this.loadButton.Font = new System.Drawing.Font("Snap ITC", 11.25F);
            this.loadButton.Location = new System.Drawing.Point(34, 342);
            this.loadButton.Margin = new System.Windows.Forms.Padding(2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(160, 75);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load Game";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.OnLoadButtonClick);
            // 
            // resumeButton
            // 
            this.resumeButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.resumeButton.Enabled = false;
            this.resumeButton.Font = new System.Drawing.Font("Snap ITC", 11.25F);
            this.resumeButton.Location = new System.Drawing.Point(34, 105);
            this.resumeButton.Margin = new System.Windows.Forms.Padding(2);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(160, 75);
            this.resumeButton.TabIndex = 3;
            this.resumeButton.Text = "Resume";
            this.resumeButton.UseVisualStyleBackColor = false;
            this.resumeButton.Click += new System.EventHandler(this.OnResumeButtonClick);
            // 
            // optionsButton
            // 
            this.optionsButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.optionsButton.Font = new System.Drawing.Font("Snap ITC", 11.25F);
            this.optionsButton.Location = new System.Drawing.Point(34, 421);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(2);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(160, 75);
            this.optionsButton.TabIndex = 4;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = false;
            this.optionsButton.Click += new System.EventHandler(this.OnOptionsButtonClick);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.exitButton.Font = new System.Drawing.Font("Snap ITC", 11.25F);
            this.exitButton.Location = new System.Drawing.Point(34, 579);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(160, 75);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.OnExitButtonClick);
            // 
            // heroLabel
            // 
            this.heroLabel.AutoSize = true;
            this.heroLabel.BackColor = System.Drawing.Color.Transparent;
            this.heroLabel.Font = new System.Drawing.Font("Snap ITC", 11.25F);
            this.heroLabel.Location = new System.Drawing.Point(571, 556);
            this.heroLabel.Name = "heroLabel";
            this.heroLabel.Size = new System.Drawing.Size(119, 19);
            this.heroLabel.TabIndex = 10;
            this.heroLabel.Text = "Choose Hero:";
            this.heroLabel.UseMnemonic = false;
            this.heroLabel.Visible = false;
            // 
            // mapLabel
            // 
            this.mapLabel.AutoSize = true;
            this.mapLabel.BackColor = System.Drawing.Color.Transparent;
            this.mapLabel.Font = new System.Drawing.Font("Snap ITC", 11.25F);
            this.mapLabel.Location = new System.Drawing.Point(574, 429);
            this.mapLabel.Name = "mapLabel";
            this.mapLabel.Size = new System.Drawing.Size(113, 19);
            this.mapLabel.TabIndex = 11;
            this.mapLabel.Text = "Choose Map:";
            this.mapLabel.UseMnemonic = false;
            this.mapLabel.Visible = false;
            // 
            // mapSpringLabel
            // 
            this.mapSpringLabel.AutoSize = true;
            this.mapSpringLabel.BackColor = System.Drawing.Color.Transparent;
            this.mapSpringLabel.Font = new System.Drawing.Font("Snap ITC", 10.25F);
            this.mapSpringLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.mapSpringLabel.Location = new System.Drawing.Point(600, 492);
            this.mapSpringLabel.Name = "mapSpringLabel";
            this.mapSpringLabel.Size = new System.Drawing.Size(61, 18);
            this.mapSpringLabel.TabIndex = 12;
            this.mapSpringLabel.Text = "Spring";
            this.mapSpringLabel.UseMnemonic = false;
            this.mapSpringLabel.Visible = false;
            this.mapSpringLabel.Click += new System.EventHandler(this.OnMapSpringLabelClick);
            // 
            // sagittariusHeroLabel
            // 
            this.sagittariusHeroLabel.AutoSize = true;
            this.sagittariusHeroLabel.BackColor = System.Drawing.Color.Transparent;
            this.sagittariusHeroLabel.Font = new System.Drawing.Font("Snap ITC", 10.25F);
            this.sagittariusHeroLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.sagittariusHeroLabel.Location = new System.Drawing.Point(579, 619);
            this.sagittariusHeroLabel.Name = "sagittariusHeroLabel";
            this.sagittariusHeroLabel.Size = new System.Drawing.Size(103, 18);
            this.sagittariusHeroLabel.TabIndex = 14;
            this.sagittariusHeroLabel.Text = "Sagittarius";
            this.sagittariusHeroLabel.UseMnemonic = false;
            this.sagittariusHeroLabel.Visible = false;
            this.sagittariusHeroLabel.Click += new System.EventHandler(this.OnSagittariusHeroLabelClick);
            // 
            // aquariusHeroLabel
            // 
            this.aquariusHeroLabel.AutoSize = true;
            this.aquariusHeroLabel.BackColor = System.Drawing.Color.Transparent;
            this.aquariusHeroLabel.Font = new System.Drawing.Font("Snap ITC", 10.25F);
            this.aquariusHeroLabel.Location = new System.Drawing.Point(591, 588);
            this.aquariusHeroLabel.Name = "aquariusHeroLabel";
            this.aquariusHeroLabel.Size = new System.Drawing.Size(78, 18);
            this.aquariusHeroLabel.TabIndex = 15;
            this.aquariusHeroLabel.Text = "Aquarius";
            this.aquariusHeroLabel.UseMnemonic = false;
            this.aquariusHeroLabel.Visible = false;
            this.aquariusHeroLabel.Click += new System.EventHandler(this.OnAquariusHeroLabelClick);
            // 
            // mapCenterLabel
            // 
            this.mapCenterLabel.AutoSize = true;
            this.mapCenterLabel.BackColor = System.Drawing.Color.Transparent;
            this.mapCenterLabel.Font = new System.Drawing.Font("Snap ITC", 10.25F);
            this.mapCenterLabel.ForeColor = System.Drawing.Color.Black;
            this.mapCenterLabel.Location = new System.Drawing.Point(599, 461);
            this.mapCenterLabel.Name = "mapCenterLabel";
            this.mapCenterLabel.Size = new System.Drawing.Size(63, 18);
            this.mapCenterLabel.TabIndex = 16;
            this.mapCenterLabel.Text = "Center";
            this.mapCenterLabel.UseMnemonic = false;
            this.mapCenterLabel.Visible = false;
            this.mapCenterLabel.Click += new System.EventHandler(this.OnMapCenterLabelClick);
            // 
            // highscoreButton
            // 
            this.highscoreButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.highscoreButton.Font = new System.Drawing.Font("Snap ITC", 11.25F);
            this.highscoreButton.Location = new System.Drawing.Point(34, 500);
            this.highscoreButton.Margin = new System.Windows.Forms.Padding(2);
            this.highscoreButton.Name = "highscoreButton";
            this.highscoreButton.Size = new System.Drawing.Size(160, 75);
            this.highscoreButton.TabIndex = 17;
            this.highscoreButton.Text = "High Scores";
            this.highscoreButton.UseVisualStyleBackColor = false;
            this.highscoreButton.Click += new System.EventHandler(this.OnHighscoreButtonClick);
            // 
            // controlsLabel
            // 
            this.controlsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlsLabel.AutoSize = true;
            this.controlsLabel.BackColor = System.Drawing.Color.Transparent;
            this.controlsLabel.Font = new System.Drawing.Font("Snap ITC", 11.25F);
            this.controlsLabel.Location = new System.Drawing.Point(806, 442);
            this.controlsLabel.Name = "controlsLabel";
            this.controlsLabel.Size = new System.Drawing.Size(181, 190);
            this.controlsLabel.TabIndex = 18;
            this.controlsLabel.Text = "Controls:\r\n\r\nUp -  ↑\r\nDown -  ↓\r\nRight -  →\r\nLeft  -  ←\r\nTeleport -  T\r\nShoot -  " +
    "S\r\nTargeting -  A, D\r\nRun / Walk - RShift";
            this.controlsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.controlsLabel.UseMnemonic = false;
            this.controlsLabel.Visible = false;
            // 
            // highscoresLabel
            // 
            this.highscoresLabel.AutoSize = true;
            this.highscoresLabel.BackColor = System.Drawing.Color.Transparent;
            this.highscoresLabel.Font = new System.Drawing.Font("Snap ITC", 11.25F);
            this.highscoresLabel.Location = new System.Drawing.Point(733, 429);
            this.highscoresLabel.Name = "highscoresLabel";
            this.highscoresLabel.Size = new System.Drawing.Size(118, 19);
            this.highscoresLabel.TabIndex = 19;
            this.highscoresLabel.Text = "High Scores:";
            this.highscoresLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.highscoresLabel.Visible = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(180)))), ((int)(((byte)(70)))));
            this.BackgroundImage = global::EmojiHunter.Properties.Resources.MainMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1215, 748);
            this.ControlBox = false;
            this.Controls.Add(this.highscoresLabel);
            this.Controls.Add(this.controlsLabel);
            this.Controls.Add(this.highscoreButton);
            this.Controls.Add(this.mapCenterLabel);
            this.Controls.Add(this.aquariusHeroLabel);
            this.Controls.Add(this.sagittariusHeroLabel);
            this.Controls.Add(this.mapSpringLabel);
            this.Controls.Add(this.mapLabel);
            this.Controls.Add(this.heroLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button exitButton;

        private System.Windows.Forms.Label heroLabel;
        private System.Windows.Forms.Label mapLabel;
        private System.Windows.Forms.Label mapSpringLabel;
        private System.Windows.Forms.Label sagittariusHeroLabel;
        private System.Windows.Forms.Label aquariusHeroLabel;
        private System.Windows.Forms.Label mapCenterLabel;
        private System.Windows.Forms.Button highscoreButton;
        private System.Windows.Forms.Label controlsLabel;
        private System.Windows.Forms.Label highscoresLabel;
    }
}