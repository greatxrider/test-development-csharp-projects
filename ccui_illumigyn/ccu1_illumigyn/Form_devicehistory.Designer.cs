namespace ccu1_illumigyn
{
    partial class Form_devicehistory
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

        private void IntializeComponent()
        {
            
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_devicehistory));
            this.GroupBox_Summary = new System.Windows.Forms.GroupBox();
            this.dgv_Summary = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_Details_Serial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.abortedButton = new System.Windows.Forms.RadioButton();
            this.bothradioButton3 = new System.Windows.Forms.RadioButton();
            this.failedradioButton2 = new System.Windows.Forms.RadioButton();
            this.passedradioButton1 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Single = new System.Windows.Forms.TabPage();
            this.singlebox = new System.Windows.Forms.GroupBox();
            this.printcsv = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.abortedOveralltextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.totalOveralltextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.failedOveralltextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.passedOveralltextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SEARCH_button = new System.Windows.Forms.Button();
            this.GroupBox_Summary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Summary)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Single.SuspendLayout();
            this.singlebox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox_Summary
            // 
            this.GroupBox_Summary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.GroupBox_Summary.Controls.Add(this.dgv_Summary);
            this.GroupBox_Summary.Location = new System.Drawing.Point(2, 340);
            this.GroupBox_Summary.Name = "GroupBox_Summary";
            this.GroupBox_Summary.Size = new System.Drawing.Size(332, 201);
            this.GroupBox_Summary.TabIndex = 145;
            this.GroupBox_Summary.TabStop = false;
            this.GroupBox_Summary.Text = "Summary";
            // 
            // dgv_Summary
            // 
            this.dgv_Summary.AllowUserToAddRows = false;
            this.dgv_Summary.AllowUserToDeleteRows = false;
            this.dgv_Summary.AllowUserToResizeRows = false;
            this.dgv_Summary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Summary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Summary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Summary.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Summary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Summary.Location = new System.Drawing.Point(3, 16);
            this.dgv_Summary.Name = "dgv_Summary";
            this.dgv_Summary.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Summary.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Summary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Summary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Summary.Size = new System.Drawing.Size(326, 182);
            this.dgv_Summary.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 64);
            this.panel1.TabIndex = 146;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1278, 62);
            this.label1.TabIndex = 6;
            this.label1.Text = "CCU1 Test Device History";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.groupBox1.Controls.Add(this.tb_Details_Serial);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(326, 60);
            this.groupBox1.TabIndex = 147;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "By Serial Number";
            // 
            // tb_Details_Serial
            // 
            this.tb_Details_Serial.Location = new System.Drawing.Point(102, 20);
            this.tb_Details_Serial.Name = "tb_Details_Serial";
            this.tb_Details_Serial.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tb_Details_Serial.Size = new System.Drawing.Size(218, 21);
            this.tb_Details_Serial.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Serial Number:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker3);
            this.groupBox2.Controls.Add(this.dateTimePicker4);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(326, 89);
            this.groupBox2.TabIndex = 148;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "By Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Start Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "hh:mm:ss tt";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(214, 20);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(101, 21);
            this.dateTimePicker2.TabIndex = 14;
            this.dateTimePicker2.Value = new System.DateTime(2023, 5, 31, 13, 9, 8, 0);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "hh:mm:ss tt";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(214, 47);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker3.ShowUpDown = true;
            this.dateTimePicker3.Size = new System.Drawing.Size(101, 21);
            this.dateTimePicker3.TabIndex = 13;
            this.dateTimePicker3.Value = new System.DateTime(2023, 5, 31, 13, 8, 58, 0);
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker4.Location = new System.Drawing.Point(89, 47);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker4.Size = new System.Drawing.Size(119, 21);
            this.dateTimePicker4.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker1.Size = new System.Drawing.Size(119, 21);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.Value = new System.DateTime(2023, 5, 3, 13, 51, 0, 0);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.groupBox3.Controls.Add(this.abortedButton);
            this.groupBox3.Controls.Add(this.bothradioButton3);
            this.groupBox3.Controls.Add(this.failedradioButton2);
            this.groupBox3.Controls.Add(this.passedradioButton1);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 231);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(326, 60);
            this.groupBox3.TabIndex = 149;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Overall";
            // 
            // abortedButton
            // 
            this.abortedButton.AutoSize = true;
            this.abortedButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abortedButton.Location = new System.Drawing.Point(171, 20);
            this.abortedButton.Name = "abortedButton";
            this.abortedButton.Size = new System.Drawing.Size(81, 17);
            this.abortedButton.TabIndex = 19;
            this.abortedButton.Text = "ABORTED";
            this.abortedButton.UseVisualStyleBackColor = true;
            // 
            // bothradioButton3
            // 
            this.bothradioButton3.AutoSize = true;
            this.bothradioButton3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bothradioButton3.Location = new System.Drawing.Point(258, 20);
            this.bothradioButton3.Name = "bothradioButton3";
            this.bothradioButton3.Size = new System.Drawing.Size(45, 17);
            this.bothradioButton3.TabIndex = 9;
            this.bothradioButton3.Text = "ALL";
            this.bothradioButton3.UseVisualStyleBackColor = true;
            // 
            // failedradioButton2
            // 
            this.failedradioButton2.AutoSize = true;
            this.failedradioButton2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.failedradioButton2.Location = new System.Drawing.Point(100, 20);
            this.failedradioButton2.Name = "failedradioButton2";
            this.failedradioButton2.Size = new System.Drawing.Size(65, 17);
            this.failedradioButton2.TabIndex = 8;
            this.failedradioButton2.Text = "FAILED";
            this.failedradioButton2.UseVisualStyleBackColor = true;
            // 
            // passedradioButton1
            // 
            this.passedradioButton1.AutoSize = true;
            this.passedradioButton1.Checked = true;
            this.passedradioButton1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passedradioButton1.Location = new System.Drawing.Point(18, 20);
            this.passedradioButton1.Name = "passedradioButton1";
            this.passedradioButton1.Size = new System.Drawing.Size(76, 17);
            this.passedradioButton1.TabIndex = 7;
            this.passedradioButton1.TabStop = true;
            this.passedradioButton1.Text = "PASSED ";
            this.passedradioButton1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Single);
            this.tabControl1.Location = new System.Drawing.Point(337, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(941, 619);
            this.tabControl1.TabIndex = 151;
            // 
            // Single
            // 
            this.Single.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(185)))), ((int)(((byte)(233)))));
            this.Single.Controls.Add(this.singlebox);
            this.Single.Location = new System.Drawing.Point(4, 22);
            this.Single.Name = "Single";
            this.Single.Padding = new System.Windows.Forms.Padding(3);
            this.Single.Size = new System.Drawing.Size(933, 593);
            this.Single.TabIndex = 3;
            this.Single.Text = "Single";
            // 
            // singlebox
            // 
            this.singlebox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.singlebox.Controls.Add(this.printcsv);
            this.singlebox.Controls.Add(this.dataGridView1);
            this.singlebox.Location = new System.Drawing.Point(6, 6);
            this.singlebox.Name = "singlebox";
            this.singlebox.Size = new System.Drawing.Size(921, 584);
            this.singlebox.TabIndex = 116;
            this.singlebox.TabStop = false;
            this.singlebox.Text = "Single View";
            // 
            // printcsv
            // 
            this.printcsv.BackgroundImage = global::ccu1_illumigyn.Properties.Resources.csv1;
            this.printcsv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.printcsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printcsv.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.printcsv.Location = new System.Drawing.Point(398, 550);
            this.printcsv.Name = "printcsv";
            this.printcsv.Size = new System.Drawing.Size(154, 28);
            this.printcsv.TabIndex = 1;
            this.printcsv.Text = "Export to CSV";
            this.printcsv.UseVisualStyleBackColor = true;
            this.printcsv.Click += new System.EventHandler(this.printcsv_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(908, 530);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.groupBox4.Controls.Add(this.abortedOveralltextBox);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.totalOveralltextBox);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.failedOveralltextBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.passedOveralltextBox);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(2, 544);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox4.Size = new System.Drawing.Size(332, 142);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Overall Results";
            // 
            // abortedOveralltextBox
            // 
            this.abortedOveralltextBox.Location = new System.Drawing.Point(142, 74);
            this.abortedOveralltextBox.Name = "abortedOveralltextBox";
            this.abortedOveralltextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.abortedOveralltextBox.Size = new System.Drawing.Size(139, 21);
            this.abortedOveralltextBox.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(59, 77);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "ABORTED:";
            // 
            // totalOveralltextBox
            // 
            this.totalOveralltextBox.Location = new System.Drawing.Point(142, 101);
            this.totalOveralltextBox.Name = "totalOveralltextBox";
            this.totalOveralltextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.totalOveralltextBox.Size = new System.Drawing.Size(139, 21);
            this.totalOveralltextBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(79, 104);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "TOTAL:";
            // 
            // failedOveralltextBox
            // 
            this.failedOveralltextBox.Location = new System.Drawing.Point(142, 47);
            this.failedOveralltextBox.Name = "failedOveralltextBox";
            this.failedOveralltextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.failedOveralltextBox.Size = new System.Drawing.Size(139, 21);
            this.failedOveralltextBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(75, 50);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "FAILED:";
            // 
            // passedOveralltextBox
            // 
            this.passedOveralltextBox.Location = new System.Drawing.Point(142, 20);
            this.passedOveralltextBox.Name = "passedOveralltextBox";
            this.passedOveralltextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passedOveralltextBox.Size = new System.Drawing.Size(139, 21);
            this.passedOveralltextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 23);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "PASSED:";
            // 
            // SEARCH_button
            // 
            this.SEARCH_button.BackgroundImage = global::ccu1_illumigyn.Properties.Resources.searSTART;
            this.SEARCH_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SEARCH_button.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEARCH_button.Location = new System.Drawing.Point(8, 297);
            this.SEARCH_button.Name = "SEARCH_button";
            this.SEARCH_button.Size = new System.Drawing.Size(326, 37);
            this.SEARCH_button.TabIndex = 150;
            this.SEARCH_button.Text = "SEARCH";
            this.SEARCH_button.UseVisualStyleBackColor = true;
            this.SEARCH_button.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // Form_devicehistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(185)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1280, 691);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.SEARCH_button);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GroupBox_Summary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_devicehistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEVICE HISTORY";
            this.GroupBox_Summary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Summary)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Single.ResumeLayout(false);
            this.singlebox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog1;
        internal System.Windows.Forms.GroupBox GroupBox_Summary;
        internal System.Windows.Forms.DataGridView dgv_Summary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Details_Serial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton bothradioButton3;
        private System.Windows.Forms.RadioButton failedradioButton2;
        private System.Windows.Forms.RadioButton passedradioButton1;
        private System.Windows.Forms.Button SEARCH_button;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Single;
        internal System.Windows.Forms.GroupBox singlebox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button printcsv;
        private System.Windows.Forms.RadioButton abortedButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox totalOveralltextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox failedOveralltextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox passedOveralltextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox abortedOveralltextBox;
        private System.Windows.Forms.Label label8;
    }
}