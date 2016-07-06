namespace EmojiHunter
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
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.newGameButton.Location = new System.Drawing.Point(1295, 245);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(214, 92);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = false;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.saveButton.Location = new System.Drawing.Point(457, 272);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(192, 120);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save Game";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Visible = false;
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.loadButton.Location = new System.Drawing.Point(715, 283);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(136, 108);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load Game";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Visible = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.resumeButton.Location = new System.Drawing.Point(1295, 395);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(214, 93);
            this.resumeButton.TabIndex = 3;
            this.resumeButton.Text = "Resume";
            this.resumeButton.UseVisualStyleBackColor = false;
            this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.optionsButton.Location = new System.Drawing.Point(1295, 541);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(214, 97);
            this.optionsButton.TabIndex = 4;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = false;
            this.optionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.exitButton.Location = new System.Drawing.Point(1295, 700);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(214, 91);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.backButton.Location = new System.Drawing.Point(787, 687);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(262, 76);
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
            this.txtOptions.Location = new System.Drawing.Point(749, 430);
            this.txtOptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOptions.Multiline = true;
            this.txtOptions.Name = "txtOptions";
            this.txtOptions.Size = new System.Drawing.Size(321, 226);
            this.txtOptions.TabIndex = 9;
            this.txtOptions.Text = "Controls:  \r\nUp - ↑\r\nDown - ↓\r\nRight - →\r\nLeft  - ←\r\nTeleport - T\r\nShoot - Space," +
    " C, S\r\nTargeting - A, D\r\n\r\n\r\n";
            this.txtOptions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOptions.Visible = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::EmojiHunter.Properties.Resources.MainMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1932, 1092);
            this.ControlBox = false;
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
    }
}