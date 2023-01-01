using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Observer
{
    public partial class MainForm : Form, IObserver
    {
        public MainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            timer1.Interval = 5000;
            timer1.Enabled = true;

            //WarningTimer.WarningStateChanged += WarningTimer_WarningStateChanged;
            //this.Disposed += MainForm_Disposed;

            WarningTimer.AddObserver(this);
            this.Disposed += MainForm_Disposed;
        }

        private void MainForm_Disposed(object sender, EventArgs e)
        {
            WarningTimer.RemoveObserver(this);
        }


        public  void Update(bool isWarning)
        {
            this.Invoke((Action)delegate ()
            {
                if (isWarning)
                {
                    WarningLabel.Text = "警報";
                    WarningLabel.BackColor = Color.Red;
                }
                else
                {
                    WarningLabel.Text = "正常";
                    WarningLabel.BackColor = Color.Lime;
                }
            });
        }

        //private void WarningTimer_WarningStateChanged(bool isWarning)
        //{
        //    this.Invoke((Action)delegate()
        //    {
        //        if (isWarning)
        //        {
        //            WarningLabel.Text = "警報";
        //            WarningLabel.BackColor = Color.Red;
        //        }
        //        else
        //        {
        //            WarningLabel.Text = "正常";
        //            WarningLabel.BackColor = Color.Lime;
        //        }
        //    });
        //}

        private void SubButton_Click(object sender, EventArgs e)
        {
            var f = new SubForm();
            f.Show();
        }
    }
}
