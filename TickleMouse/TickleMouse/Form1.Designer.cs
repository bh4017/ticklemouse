namespace TickleMouse
{
    partial class frm_TickleMouse
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbx_Tickle = new System.Windows.Forms.CheckBox();
            this.nud_Minutes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_Size = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_Indefinitely = new System.Windows.Forms.CheckBox();
            this.lbl_Seconds = new System.Windows.Forms.Label();
            this.btn_About = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Size)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbx_Tickle
            // 
            this.cbx_Tickle.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbx_Tickle.AutoSize = true;
            this.cbx_Tickle.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cbx_Tickle.FlatAppearance.BorderSize = 2;
            this.cbx_Tickle.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.cbx_Tickle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_Tickle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Tickle.Location = new System.Drawing.Point(10, 13);
            this.cbx_Tickle.Name = "cbx_Tickle";
            this.cbx_Tickle.Size = new System.Drawing.Size(68, 23);
            this.cbx_Tickle.TabIndex = 0;
            this.cbx_Tickle.Text = "TICKLE! ";
            this.cbx_Tickle.UseVisualStyleBackColor = true;
            this.cbx_Tickle.CheckedChanged += new System.EventHandler(this.cbx_Tickle_CheckedChanged);
            // 
            // nud_Minutes
            // 
            this.nud_Minutes.Location = new System.Drawing.Point(11, 42);
            this.nud_Minutes.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nud_Minutes.Name = "nud_Minutes";
            this.nud_Minutes.Size = new System.Drawing.Size(67, 20);
            this.nud_Minutes.TabIndex = 1;
            this.nud_Minutes.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nud_Minutes.ValueChanged += new System.EventHandler(this.nud_Minutes_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "How much tickling? (minutes)";
            // 
            // nud_Size
            // 
            this.nud_Size.Location = new System.Drawing.Point(11, 68);
            this.nud_Size.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nud_Size.Name = "nud_Size";
            this.nud_Size.Size = new System.Drawing.Size(67, 20);
            this.nud_Size.TabIndex = 3;
            this.nud_Size.ValueChanged += new System.EventHandler(this.nud_Size_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Size of tickle (0 = phantom tickling)";
            // 
            // cbx_Indefinitely
            // 
            this.cbx_Indefinitely.AutoSize = true;
            this.cbx_Indefinitely.Location = new System.Drawing.Point(87, 17);
            this.cbx_Indefinitely.Name = "cbx_Indefinitely";
            this.cbx_Indefinitely.Size = new System.Drawing.Size(104, 17);
            this.cbx_Indefinitely.TabIndex = 5;
            this.cbx_Indefinitely.Text = "Indefinite Tickle!";
            this.cbx_Indefinitely.UseVisualStyleBackColor = true;
            this.cbx_Indefinitely.CheckedChanged += new System.EventHandler(this.cbx_Indefinitely_CheckedChanged);
            // 
            // lbl_Seconds
            // 
            this.lbl_Seconds.AutoSize = true;
            this.lbl_Seconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Seconds.ForeColor = System.Drawing.Color.Red;
            this.lbl_Seconds.Location = new System.Drawing.Point(212, 8);
            this.lbl_Seconds.Name = "lbl_Seconds";
            this.lbl_Seconds.Size = new System.Drawing.Size(24, 24);
            this.lbl_Seconds.TabIndex = 6;
            this.lbl_Seconds.Text = "--";
            // 
            // btn_About
            // 
            this.btn_About.Location = new System.Drawing.Point(165, 97);
            this.btn_About.Name = "btn_About";
            this.btn_About.Size = new System.Drawing.Size(75, 23);
            this.btn_About.TabIndex = 7;
            this.btn_About.Text = "ABOUT";
            this.btn_About.UseVisualStyleBackColor = true;
            this.btn_About.Click += new System.EventHandler(this.btn_About_Click);
            // 
            // frm_TickleMouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 125);
            this.Controls.Add(this.btn_About);
            this.Controls.Add(this.lbl_Seconds);
            this.Controls.Add(this.cbx_Indefinitely);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nud_Size);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_Minutes);
            this.Controls.Add(this.cbx_Tickle);
            this.Name = "frm_TickleMouse";
            this.Text = "TICKLE MOUSE";
            ((System.ComponentModel.ISupportInitialize)(this.nud_Minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbx_Tickle;
        private System.Windows.Forms.NumericUpDown nud_Minutes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_Size;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbx_Indefinitely;
        private System.Windows.Forms.Label lbl_Seconds;
        private System.Windows.Forms.Button btn_About;
    }
}

