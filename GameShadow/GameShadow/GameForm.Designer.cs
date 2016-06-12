namespace GameShadow
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
            ((System.ComponentModel.ISupportInitialize)(this.picGameField)).BeginInit();
            this.SuspendLayout();
            // 
            // picGameField
            // 
            this.picGameField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGameField.Location = new System.Drawing.Point(0, 0);
            this.picGameField.Name = "picGameField";
            this.picGameField.Size = new System.Drawing.Size(589, 589);
            this.picGameField.TabIndex = 1;
            this.picGameField.TabStop = false;
            // 
            // label1
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.BackColor = System.Drawing.SystemColors.Control;
            this.lblHealth.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealth.Location = new System.Drawing.Point(26, 36);
            this.lblHealth.Name = "label1";
            this.lblHealth.Size = new System.Drawing.Size(56, 19);
            this.lblHealth.TabIndex = 2;
            this.lblHealth.Text = "Kills:";
            // 
            // label2
            // 
            this.lblKills.AutoSize = true;
            this.lblKills.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKills.Location = new System.Drawing.Point(26, 55);
            this.lblKills.Name = "label2";
            this.lblKills.Size = new System.Drawing.Size(70, 19);
            this.lblKills.TabIndex = 3;
            this.lblKills.Text = "Health:";
            // 
            // lblKills
            // 
            this.lblKillsValue.AutoSize = true;
            this.lblKillsValue.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKillsValue.Location = new System.Drawing.Point(102, 36);
            this.lblKillsValue.Name = "lblKills";
            this.lblKillsValue.Size = new System.Drawing.Size(22, 19);
            this.lblKillsValue.TabIndex = 4;
            this.lblKillsValue.Text = "0";
            // 
            // lblHealth
            // 
            this.lblHealthValue.AutoSize = true;
            this.lblHealthValue.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealthValue.Location = new System.Drawing.Point(102, 55);
            this.lblHealthValue.Name = "lblHealth";
            this.lblHealthValue.Size = new System.Drawing.Size(22, 19);
            this.lblHealthValue.TabIndex = 5;
            this.lblHealthValue.Text = "0";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 589);
            this.ControlBox = false;
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
    }
}

