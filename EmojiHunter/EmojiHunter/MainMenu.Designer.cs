﻿namespace EmojiHunter
{
    partial class MainMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.newGameButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOptions = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.HeroSwapLabel = new System.Windows.Forms.Label();
            this.MapSwapLabel = new System.Windows.Forms.Label();
            this.MapSpring = new System.Windows.Forms.Label();
            this.MapCenter = new System.Windows.Forms.Label();
            this.SagittariusHero = new System.Windows.Forms.Label();
            this.AquariusHero = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.newGameButton.Location = new System.Drawing.Point(1297, 148);
            this.newGameButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(213, 92);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = false;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.saveButton.Location = new System.Drawing.Point(315, 386);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(213, 92);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save Game";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Visible = false;
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.loadButton.Location = new System.Drawing.Point(315, 502);
            this.loadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(213, 92);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load Game";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Visible = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.resumeButton.Location = new System.Drawing.Point(1297, 305);
            this.resumeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(213, 92);
            this.resumeButton.TabIndex = 3;
            this.resumeButton.Text = "Resume";
            this.resumeButton.UseVisualStyleBackColor = false;
            this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.optionsButton.Location = new System.Drawing.Point(1297, 483);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(213, 92);
            this.optionsButton.TabIndex = 4;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = false;
            this.optionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.exitButton.Location = new System.Drawing.Point(1301, 638);
            this.exitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(209, 92);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.backButton.Location = new System.Drawing.Point(747, 638);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(209, 77);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Visible = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 7;
            // 
            // txtOptions
            // 
            this.txtOptions.Location = new System.Drawing.Point(731, 404);
            this.txtOptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOptions.Multiline = true;
            this.txtOptions.Name = "txtOptions";
            this.txtOptions.Size = new System.Drawing.Size(251, 180);
            this.txtOptions.TabIndex = 9;
            this.txtOptions.Text = "Controls:  \r\nUp - ↑\r\nDown - ↓\r\nRight - →\r\nLeft  - ←\r\nTeleport - T\r\nShoot - Space," +
    " C, S\r\nTargeting - A, D\r\n\r\n\r\n";
            this.txtOptions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOptions.Visible = false;
            // 
            // HeroSwapLabel
            // 
            this.HeroSwapLabel.AutoSize = true;
            this.HeroSwapLabel.Location = new System.Drawing.Point(1203, 175);
            this.HeroSwapLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeroSwapLabel.Name = "HeroSwapLabel";
            this.HeroSwapLabel.Size = new System.Drawing.Size(87, 17);
            this.HeroSwapLabel.TabIndex = 10;
            this.HeroSwapLabel.Text = "ChooseHero";
            this.HeroSwapLabel.Visible = false;
            this.HeroSwapLabel.Click += new System.EventHandler(this.HeroSwapLabel_Click);
            // 
            // MapSwapLabel
            // 
            this.MapSwapLabel.AutoSize = true;
            this.MapSwapLabel.Location = new System.Drawing.Point(1324, 175);
            this.MapSwapLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MapSwapLabel.Name = "MapSwapLabel";
            this.MapSwapLabel.Size = new System.Drawing.Size(87, 17);
            this.MapSwapLabel.TabIndex = 11;
            this.MapSwapLabel.Text = "Choose Map";
            this.MapSwapLabel.Visible = false;
            // 
            // MapSpring
            // 
            this.MapSpring.AutoSize = true;
            this.MapSpring.Location = new System.Drawing.Point(1348, 213);
            this.MapSpring.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MapSpring.Name = "MapSpring";
            this.MapSpring.Size = new System.Drawing.Size(49, 17);
            this.MapSpring.TabIndex = 12;
            this.MapSpring.Text = "Spring";
            this.MapSpring.Visible = false;
            // 
            // MapCenter
            // 
            this.MapCenter.AutoSize = true;
            this.MapCenter.Location = new System.Drawing.Point(2677, 301);
            this.MapCenter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MapCenter.Name = "MapCenter";
            this.MapCenter.Size = new System.Drawing.Size(50, 17);
            this.MapCenter.TabIndex = 13;
            this.MapCenter.Text = "Center";
            this.MapCenter.Visible = false;
            // 
            // SagittariusHero
            // 
            this.SagittariusHero.AutoSize = true;
            this.SagittariusHero.Location = new System.Drawing.Point(1203, 213);
            this.SagittariusHero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SagittariusHero.Name = "SagittariusHero";
            this.SagittariusHero.Size = new System.Drawing.Size(75, 17);
            this.SagittariusHero.TabIndex = 14;
            this.SagittariusHero.Text = "Sagittarius";
            this.SagittariusHero.Visible = false;
            // 
            // AquariusHero
            // 
            this.AquariusHero.AutoSize = true;
            this.AquariusHero.Location = new System.Drawing.Point(1203, 251);
            this.AquariusHero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AquariusHero.Name = "AquariusHero";
            this.AquariusHero.Size = new System.Drawing.Size(64, 17);
            this.AquariusHero.TabIndex = 15;
            this.AquariusHero.Text = "Aquarius";
            this.AquariusHero.Visible = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::EmojiHunter.Properties.Resources.MainMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1930, 1092);
            this.ControlBox = false;
            this.Controls.Add(this.AquariusHero);
            this.Controls.Add(this.SagittariusHero);
            this.Controls.Add(this.MapCenter);
            this.Controls.Add(this.MapSpring);
            this.Controls.Add(this.MapSwapLabel);
            this.Controls.Add(this.HeroSwapLabel);
            this.Controls.Add(this.txtOptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
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
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOptions;

        private System.Windows.Forms.ToolTip toolTip1;

        private System.Windows.Forms.Label HeroSwapLabel;
        private System.Windows.Forms.Label MapSwapLabel;
        private System.Windows.Forms.Label MapSpring;
        private System.Windows.Forms.Label MapCenter;
        private System.Windows.Forms.Label SagittariusHero;
        private System.Windows.Forms.Label AquariusHero;
    }
}