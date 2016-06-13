﻿namespace GameShadow
{
    public partial class GameForm
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
            this.picGameField = new System.Windows.Forms.PictureBox();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblKills = new System.Windows.Forms.Label();
            this.lblKillsValue = new System.Windows.Forms.Label();
            this.lblHealthValue = new System.Windows.Forms.Label();
            this.lblEmoji = new System.Windows.Forms.Label();
            this.lblEmojiValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGameField)).BeginInit();
            this.SuspendLayout();
            // 
            // picGameField
            // 
            this.picGameField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGameField.Location = new System.Drawing.Point(0, 0);
            this.picGameField.Name = "picGameField";
            this.picGameField.Size = new System.Drawing.Size(600, 600);
            this.picGameField.TabIndex = 1;
            this.picGameField.TabStop = false;
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.BackColor = System.Drawing.SystemColors.Control;
            this.lblHealth.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealth.Location = new System.Drawing.Point(15, 36);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(56, 19);
            this.lblHealth.TabIndex = 2;
            this.lblHealth.Text = "Kills:";
            // 
            // lblKills
            // 
            this.lblKills.AutoSize = true;
            this.lblKills.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKills.Location = new System.Drawing.Point(1, 55);
            this.lblKills.Name = "lblKills";
            this.lblKills.Size = new System.Drawing.Size(70, 19);
            this.lblKills.TabIndex = 3;
            this.lblKills.Text = "Health:";
            // 
            // lblKillsValue
            // 
            this.lblKillsValue.AutoSize = true;
            this.lblKillsValue.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKillsValue.Location = new System.Drawing.Point(77, 36);
            this.lblKillsValue.Name = "lblKillsValue";
            this.lblKillsValue.Size = new System.Drawing.Size(22, 19);
            this.lblKillsValue.TabIndex = 4;
            this.lblKillsValue.Text = "0";
            // 
            // lblHealthValue
            // 
            this.lblHealthValue.AutoSize = true;
            this.lblHealthValue.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealthValue.Location = new System.Drawing.Point(77, 55);
            this.lblHealthValue.Name = "lblHealthValue";
            this.lblHealthValue.Size = new System.Drawing.Size(22, 19);
            this.lblHealthValue.TabIndex = 5;
            this.lblHealthValue.Text = "0";
            // 
            // lblEmoji
            // 
            this.lblEmoji.AutoSize = true;
            this.lblEmoji.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmoji.Location = new System.Drawing.Point(10, 74);
            this.lblEmoji.Name = "lblEmoji";
            this.lblEmoji.Size = new System.Drawing.Size(61, 19);
            this.lblEmoji.TabIndex = 6;
            this.lblEmoji.Text = "Emoji:";
            // 
            // lblEmojiValue
            // 
            this.lblEmojiValue.AutoSize = true;
            this.lblEmojiValue.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmojiValue.Location = new System.Drawing.Point(77, 74);
            this.lblEmojiValue.Name = "lblEmojiValue";
            this.lblEmojiValue.Size = new System.Drawing.Size(22, 19);
            this.lblEmojiValue.TabIndex = 7;
            this.lblEmojiValue.Text = "0";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.ControlBox = false;
            this.Controls.Add(this.lblEmojiValue);
            this.Controls.Add(this.lblEmoji);
            this.Controls.Add(this.lblHealthValue);
            this.Controls.Add(this.lblKillsValue);
            this.Controls.Add(this.lblKills);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.picGameField);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picGameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGameField;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblKills;
        public System.Windows.Forms.Label lblKillsValue;
        private System.Windows.Forms.Label lblHealthValue;
        private System.Windows.Forms.Label lblEmoji;
        private System.Windows.Forms.Label lblEmojiValue;
    }
}

