using System.Diagnostics;

namespace StudyVSInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var helpFullPath = Path.Combine(Environment.CurrentDirectory, @"HELP\help.html");

            ProcessStartInfo pi = new ProcessStartInfo()
            {
                FileName = helpFullPath,
                UseShellExecute = true,
            };

            Process.Start(pi);
        }
    }
}