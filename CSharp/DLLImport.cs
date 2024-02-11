using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace WinFormsApp1
{
    internal class NativeMethods
    {
        [DllImport("user32.dll")]
        // BOOL型扱うときはおまじない。
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

        // Stirng扱うときはStringBuilder使うのがベターらしい。
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern int GetCurrentDirectory(
                                    int nBufferLength,　
                                    [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder lpPathName);
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            NativeMethods.GetWindowRect(this.Handle, out var rect);

            var msg = $"Width:{rect.Width}, Height:{rect.Height}";

            MessageBox.Show(msg);
        }
    }
}