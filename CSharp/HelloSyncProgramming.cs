using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloSyncProgramming
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private CancellationTokenSource _cts = new CancellationTokenSource();

        private async void _btn1_Click(object sender, System.EventArgs e)
        {
            var context = TaskScheduler.FromCurrentSynchronizationContext();
            await Task.Run(() => GetHello(_cts)).ContinueWith(x =>
            {
                // 非同期で呼び出した関数の戻り値にアクセスできる。
                _textBox1.Text = x.Result;
            }, context);
            if (_cts.IsCancellationRequested)
            {
                _cts.Dispose();
                _cts = new CancellationTokenSource();
                return;
            }
            MessageBox.Show("Complete");
        }

        static void ShowNumbers()
        {
            Enumerable.Range(0, 100).ToList().ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

        static string GetHello(object obj)
        {
            var cts = obj as CancellationTokenSource;
            Thread.Sleep(5000);

            if (cts.IsCancellationRequested) return "";
            return "Hello World";
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
        }
    }
}
