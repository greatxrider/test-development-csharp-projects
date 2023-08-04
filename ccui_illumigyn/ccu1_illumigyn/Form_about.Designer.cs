namespace ccu1_illumigyn
{
    partial class Form_about
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_about));
            this.PictureBox_IonicsLogoPic = new System.Windows.Forms.PictureBox();
            this.about_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.software_versionlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_IonicsLogoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox_IonicsLogoPic
            // 
            this.PictureBox_IonicsLogoPic.BackgroundImage = global::ccu1_illumigyn.Properties.Resources.jobscloud;
            this.PictureBox_IonicsLogoPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox_IonicsLogoPic.Dock = System.Windows.Forms.DockStyle.Top;
            this.PictureBox_IonicsLogoPic.Location = new System.Drawing.Point(0, 0);
            this.PictureBox_IonicsLogoPic.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.PictureBox_IonicsLogoPic.Name = "PictureBox_IonicsLogoPic";
            this.PictureBox_IonicsLogoPic.Size = new System.Drawing.Size(377, 158);
            this.PictureBox_IonicsLogoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox_IonicsLogoPic.TabIndex = 5;
            this.PictureBox_IonicsLogoPic.TabStop = false;
            // 
            // about_textBox
            // 
            this.about_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(185)))), ((int)(((byte)(233)))));
            this.about_textBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.about_textBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.about_textBox.Location = new System.Drawing.Point(0, 216);
            this.about_textBox.Multiline = true;
            this.about_textBox.Name = "about_textBox";
            this.about_textBox.ReadOnly = true;
            this.about_textBox.Size = new System.Drawing.Size(377, 268);
            this.about_textBox.TabIndex = 8;
            this.about_textBox.Text = "1.0.0 - Jeph Mari Daligdig - March 13, 2023\r\n[Description: Initial Release]\r\n\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "ILLUMIGYN CCU1 TESTER";
            // 
            // software_versionlabel
            // 
            this.software_versionlabel.AutoSize = true;
            this.software_versionlabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.software_versionlabel.ForeColor = System.Drawing.Color.White;
            this.software_versionlabel.Location = new System.Drawing.Point(130, 190);
            this.software_versionlabel.Name = "software_versionlabel";
            this.software_versionlabel.Size = new System.Drawing.Size(107, 23);
            this.software_versionlabel.TabIndex = 10;
            this.software_versionlabel.Text = "ATM 1.0.0";
            // 
            // Form_about
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(377, 484);
            this.Controls.Add(this.software_versionlabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.about_textBox);
            this.Controls.Add(this.PictureBox_IonicsLogoPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_about";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABOUT";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_IonicsLogoPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox_IonicsLogoPic;
        private System.Windows.Forms.TextBox about_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label software_versionlabel;
    }
}