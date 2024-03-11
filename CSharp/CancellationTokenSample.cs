using System.Diagnostics;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var c = new CancelSample();
            c.StartTask();

            Console.ReadKey();
        }
    }

    internal class CancelSample
    {
        public void StartTask()
        {
            var tokenSrc = new CancellationTokenSource();
            var token = tokenSrc.Token;

            Task.Run(() => DoAction(token));

            Thread.Sleep(1000);

            Debug.WriteLine("Cancelを投げる");
            tokenSrc.Cancel();
        }

        private void DoAction(CancellationToken token)
        {
            Debug.WriteLine("Do Action Start");

            var cnt = 0;
            while (true) { 
                Debug.WriteLine($"counter = {cnt}");
                Thread.Sleep(100);
                
                if (token.IsCancellationRequested)
                {
                    break;
                }
                cnt++;
            }
            Debug.WriteLine("Do Action Finish");
        }
    }
}
