namespace ccu1_illumigyn
{
    partial class Form_serialnumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_serialnumber));
            this.serialnumberscan = new System.Windows.Forms.TextBox();
            this.proceed_butt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cancel_butt = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialnumberscan
            // 
            this.serialnumberscan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialnumberscan.Location = new System.Drawing.Point(7, 74);
            this.serialnumberscan.Multiline = true;
            this.serialnumberscan.Name = "serialnumberscan";
            this.serialnumberscan.Size = new System.Drawing.Size(549, 36);
            this.serialnumberscan.TabIndex = 30;
            this.serialnumberscan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.serialnumberscan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serialnumberscan_KeyDown);
            // 
            // proceed_butt
            // 
            this.proceed_butt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proceed_butt.Location = new System.Drawing.Point(288, 116);
            this.proceed_butt.Name = "proceed_butt";
            this.proceed_butt.Size = new System.Drawing.Size(131, 43);
            this.proceed_butt.TabIndex = 31;
            this.proceed_butt.Text = "PROCEED";
            this.proceed_butt.UseVisualStyleBackColor = true;
            this.proceed_butt.Click += new System.EventHandler(this.proceed_butt_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 64);
            this.panel1.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 62);
            this.label1.TabIndex = 8;
            this.label1.Text = "Enter Serial Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancel_butt
            // 
            this.cancel_butt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_butt.Location = new System.Drawing.Point(425, 116);
            this.cancel_butt.Name = "cancel_butt";
            this.cancel_butt.Size = new System.Drawing.Size(131, 43);
            this.cancel_butt.TabIndex = 33;
            this.cancel_butt.Text = "CANCEL";
            this.cancel_butt.UseVisualStyleBackColor = true;
            this.cancel_butt.Click += new System.EventHandler(this.cancel_butt_Click);
            // 
            // Form_serialnumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 160);
            this.ControlBox = false;
            this.Controls.Add(this.cancel_butt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.proceed_butt);
            this.Controls.Add(this.serialnumberscan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_serialnumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UNIQUE SERIAL NUMBER";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serialnumberscan;
        private System.Windows.Forms.Button proceed_butt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel_butt;
    }
}