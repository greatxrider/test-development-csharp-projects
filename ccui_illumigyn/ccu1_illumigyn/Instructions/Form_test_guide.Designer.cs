﻿namespace ccu1_illumigyn
{
    partial class Form_test_guide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_test_guide));
            this.test_guide_ok_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.test_guide_cancel_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // test_guide_ok_button
            // 
            this.test_guide_ok_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.test_guide_ok_button.Location = new System.Drawing.Point(283, 679);
            this.test_guide_ok_button.Name = "test_guide_ok_button";
            this.test_guide_ok_button.Size = new System.Drawing.Size(235, 36);
            this.test_guide_ok_button.TabIndex = 1;
            this.test_guide_ok_button.Text = "OK";
            this.test_guide_ok_button.UseVisualStyleBackColor = true;
            this.test_guide_ok_button.Click += new System.EventHandler(this.test_guide_ok_button_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(185)))), ((int)(((byte)(233)))));
            this.textBox1.Font = new System.Drawing.Font("Verdana", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(299, 661);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // test_guide_cancel_button
            // 
            this.test_guide_cancel_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.test_guide_cancel_button.Location = new System.Drawing.Point(672, 679);
            this.test_guide_cancel_button.Name = "test_guide_cancel_button";
            this.test_guide_cancel_button.Size = new System.Drawing.Size(235, 36);
            this.test_guide_cancel_button.TabIndex = 3;
            this.test_guide_cancel_button.Text = "CANCEL";
            this.test_guide_cancel_button.UseVisualStyleBackColor = true;
            this.test_guide_cancel_button.Click += new System.EventHandler(this.test_guide_cancel_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ccu1_illumigyn.Properties.Resources.First_instruction1;
            this.pictureBox1.Location = new System.Drawing.Point(317, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(819, 661);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form_test_guide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(1148, 721);
            this.ControlBox = false;
            this.Controls.Add(this.test_guide_cancel_button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.test_guide_ok_button);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form_test_guide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TEST INSTRUCTION";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button test_guide_ok_button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button test_guide_cancel_button;
    }
}