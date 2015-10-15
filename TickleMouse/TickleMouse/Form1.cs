using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TickleMouse
{
    public partial class frm_TickleMouse : Form
    {
        int minutes = 60;
        int seconds = 0;
        int size = 0;

        public frm_TickleMouse()
        {
            InitializeComponent();
            nud_Minutes.Value = minutes;
            nud_Size.Value = size;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!cbx_Indefinitely.Checked)
            {
                seconds++;
                if (seconds == 60)
                {
                    nud_Minutes.Value--;
                    seconds = 0;
                }
                if (minutes == 0)
                {
                    cbx_Tickle.Checked = false;
                    nud_Minutes.Value = TickleMouse.Properties.Settings.Default.Minutes;
                }
            }
            lbl_Seconds.Text = seconds.ToString();
            Tickler.MoveMouse(size, size);
        }

        private void nud_Minutes_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = (NumericUpDown)sender;
            minutes = (int)n.Value;
        }

        private void nud_Size_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = (NumericUpDown)sender;
            size = (int)n.Value;
        }

        private void cbx_Tickle_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if (c.Checked)
                timer1.Enabled = true;
            else
                timer1.Enabled = false;
        }

        private void cbx_Indefinitely_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if (c.Checked)
                nud_Minutes.Enabled = false;
            else
                nud_Minutes.Enabled = true;
        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            AboutBox1 AboutBox = new AboutBox1();
            AboutBox.ShowDialog();
        }
    }
}
