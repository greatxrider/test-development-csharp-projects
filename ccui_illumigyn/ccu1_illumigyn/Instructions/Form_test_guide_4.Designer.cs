namespace ccu1_illumigyn.Instructions
{
    partial class Form_test_guide_4
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
            this.test_guide4_textbox = new System.Windows.Forms.TextBox();
            this.test_guide4_cancel_button = new System.Windows.Forms.Button();
            this.test_guide4_ok_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // test_guide4_textbox
            // 
            this.test_guide4_textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(185)))), ((int)(((byte)(233)))));
            this.test_guide4_textbox.Font = new System.Drawing.Font("Verdana", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.test_guide4_textbox.Location = new System.Drawing.Point(12, 12);
            this.test_guide4_textbox.Multiline = true;
            this.test_guide4_textbox.Name = "test_guide4_textbox";
            this.test_guide4_textbox.Size = new System.Drawing.Size(299, 661);
            this.test_guide4_textbox.TabIndex = 6;
            this.test_guide4_textbox.Text = "\r\n\r\n\r\n\r\n\r\n\r\n\r\nSTEP 11 - Ensure that the fixture power supply cable is plugged int" +
    "o the power outlet.\r\n         \r\nSTEP 12 - Turn on the power supply (Switch at th" +
    "e back of the Fixture).";
            // 
            // test_guide4_cancel_button
            // 
            this.test_guide4_cancel_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.test_guide4_cancel_button.Location = new System.Drawing.Point(670, 679);
            this.test_guide4_cancel_button.Name = "test_guide4_cancel_button";
            this.test_guide4_cancel_button.Size = new System.Drawing.Size(235, 36);
            this.test_guide4_cancel_button.TabIndex = 8;
            this.test_guide4_cancel_button.Text = "CANCEL";
            this.test_guide4_cancel_button.UseVisualStyleBackColor = true;
            this.test_guide4_cancel_button.Click += new System.EventHandler(this.test_guide4_cancel_button_Click);
            // 
            // test_guide4_ok_button
            // 
            this.test_guide4_ok_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.test_guide4_ok_button.Location = new System.Drawing.Point(281, 679);
            this.test_guide4_ok_button.Name = "test_guide4_ok_button";
            this.test_guide4_ok_button.Size = new System.Drawing.Size(235, 36);
            this.test_guide4_ok_button.TabIndex = 7;
            this.test_guide4_ok_button.Text = "OK";
            this.test_guide4_ok_button.UseVisualStyleBackColor = true;
            this.test_guide4_ok_button.Click += new System.EventHandler(this.test_guide4_ok_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ccu1_illumigyn.Properties.Resources.Fourth_instruction1;
            this.pictureBox1.Location = new System.Drawing.Point(317, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(819, 661);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form_test_guide_4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(1148, 721);
            this.Controls.Add(this.test_guide4_cancel_button);
            this.Controls.Add(this.test_guide4_ok_button);
            this.Controls.Add(this.test_guide4_textbox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form_test_guide_4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_test_guide_4";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox test_guide4_textbox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button test_guide4_cancel_button;
        private System.Windows.Forms.Button test_guide4_ok_button;
    }
}