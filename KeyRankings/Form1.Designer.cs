namespace KeySpecificRankings {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.numericUpDownKeymode = new System.Windows.Forms.NumericUpDown();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.labelKeymode = new System.Windows.Forms.Label();
            this.labelTag = new System.Windows.Forms.Label();
            this.textBoxCountryTag = new System.Windows.Forms.TextBox();
            this.labelHint = new System.Windows.Forms.Label();
            this.progressBarUser = new System.Windows.Forms.ProgressBar();
            this.progressBarTotal = new System.Windows.Forms.ProgressBar();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKeymode)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxKey
            // 
            this.textBoxKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKey.Location = new System.Drawing.Point(0, 0);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(195, 20);
            this.textBoxKey.TabIndex = 1;
            this.textBoxKey.Text = "insert api key here";
            this.textBoxKey.Enter += new System.EventHandler(this.textBoxKey_Enter);
            // 
            // numericUpDownKeymode
            // 
            this.numericUpDownKeymode.Location = new System.Drawing.Point(58, 41);
            this.numericUpDownKeymode.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownKeymode.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownKeymode.Name = "numericUpDownKeymode";
            this.numericUpDownKeymode.Size = new System.Drawing.Size(27, 20);
            this.numericUpDownKeymode.TabIndex = 1;
            this.numericUpDownKeymode.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.Location = new System.Drawing.Point(0, 101);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(195, 196);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "name";
            this.columnHeader1.Width = 79;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "pp";
            this.columnHeader2.Width = 87;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelKeymode
            // 
            this.labelKeymode.AutoSize = true;
            this.labelKeymode.Location = new System.Drawing.Point(0, 44);
            this.labelKeymode.Name = "labelKeymode";
            this.labelKeymode.Size = new System.Drawing.Size(53, 13);
            this.labelKeymode.TabIndex = 7;
            this.labelKeymode.Text = "keymode:";
            // 
            // labelTag
            // 
            this.labelTag.AutoSize = true;
            this.labelTag.Location = new System.Drawing.Point(-2, 23);
            this.labelTag.Name = "labelTag";
            this.labelTag.Size = new System.Drawing.Size(63, 13);
            this.labelTag.TabIndex = 9;
            this.labelTag.Text = "country tag:";
            // 
            // textBoxCountryTag
            // 
            this.textBoxCountryTag.Location = new System.Drawing.Point(58, 20);
            this.textBoxCountryTag.Name = "textBoxCountryTag";
            this.textBoxCountryTag.Size = new System.Drawing.Size(27, 20);
            this.textBoxCountryTag.TabIndex = 10;
            this.textBoxCountryTag.Text = "DE";
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.Location = new System.Drawing.Point(85, 23);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(112, 13);
            this.labelHint.TabIndex = 11;
            this.labelHint.Text = "leave empty for Global";
            // 
            // progressBarUser
            // 
            this.progressBarUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarUser.Location = new System.Drawing.Point(0, 81);
            this.progressBarUser.Name = "progressBarUser";
            this.progressBarUser.Size = new System.Drawing.Size(195, 20);
            this.progressBarUser.Step = 1;
            this.progressBarUser.TabIndex = 12;
            // 
            // progressBarTotal
            // 
            this.progressBarTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarTotal.Location = new System.Drawing.Point(0, 61);
            this.progressBarTotal.Maximum = 50;
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Size = new System.Drawing.Size(195, 20);
            this.progressBarTotal.Step = 1;
            this.progressBarTotal.TabIndex = 13;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(126, 45);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(71, 13);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "info on github";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 297);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.progressBarTotal);
            this.Controls.Add(this.progressBarUser);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.textBoxCountryTag);
            this.Controls.Add(this.labelTag);
            this.Controls.Add(this.labelKeymode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.numericUpDownKeymode);
            this.Controls.Add(this.textBoxKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "KeyRankings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKeymode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.NumericUpDown numericUpDownKeymode;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelKeymode;
        private System.Windows.Forms.Label labelTag;
        private System.Windows.Forms.TextBox textBoxCountryTag;
        private System.Windows.Forms.Label labelHint;
        private System.Windows.Forms.ProgressBar progressBarUser;
        private System.Windows.Forms.ProgressBar progressBarTotal;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

