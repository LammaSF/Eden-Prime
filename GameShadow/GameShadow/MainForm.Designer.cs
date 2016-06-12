namespace GameShadow
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.optionsButton = new System.Windows.Forms.Button();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.HighScoreButton = new System.Windows.Forms.Button();
            this.creditsButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // optionsButton
            // 
            this.optionsButton.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsButton.Location = new System.Drawing.Point(177, 266);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(111, 42);
            this.optionsButton.TabIndex = 0;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadGameButton.Location = new System.Drawing.Point(306, 266);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(111, 42);
            this.LoadGameButton.TabIndex = 1;
            this.LoadGameButton.Text = "Load Game";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            // 
            // HighScoreButton
            // 
            this.HighScoreButton.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighScoreButton.Location = new System.Drawing.Point(53, 327);
            this.HighScoreButton.Name = "HighScoreButton";
            this.HighScoreButton.Size = new System.Drawing.Size(111, 42);
            this.HighScoreButton.TabIndex = 3;
            this.HighScoreButton.Text = "High Scores";
            this.HighScoreButton.UseVisualStyleBackColor = true;
            // 
            // creditsButton
            // 
            this.creditsButton.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditsButton.Location = new System.Drawing.Point(177, 327);
            this.creditsButton.Name = "creditsButton";
            this.creditsButton.Size = new System.Drawing.Size(111, 42);
            this.creditsButton.TabIndex = 4;
            this.creditsButton.Text = "Credits";
            this.creditsButton.UseVisualStyleBackColor = true;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Snap ITC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(146, 76);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(154, 30);
            this.Title.TabIndex = 5;
            this.Title.Text = "Emoji Hunter";
            this.Title.UseCompatibleTextRendering = true;
            // 
            // newGameButton
            // 
            this.newGameButton.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameButton.Location = new System.Drawing.Point(53, 266);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(111, 42);
            this.newGameButton.TabIndex = 6;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(306, 327);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(111, 42);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(450, 418);
            this.ControlBox = false;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.creditsButton);
            this.Controls.Add(this.HighScoreButton);
            this.Controls.Add(this.LoadGameButton);
            this.Controls.Add(this.optionsButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.Button HighScoreButton;
        private System.Windows.Forms.Button creditsButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button exitButton;
    }
}

