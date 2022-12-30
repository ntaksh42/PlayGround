using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public static class WarningTimer
    {
        private static System.Threading.Timer _timer;
        public static event Action<bool> WarningStateChanged; 
        static WarningTimer()
        {
            _timer = new System.Threading.Timer(TimerCallback);
        }

        private static bool _isWaring = false;
        public static bool IsWarning
        {
            get { return _isWaring; } 
            private set 
            {   
                if(_isWaring != value)
                {
                    _isWaring = value;
                    WarningStateChanged?.Invoke(_isWaring);
                }
            }
        }

        public static void Start()
        {
            _timer.Change(0, 5000);
        }

        private static void TimerCallback(object state)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            var lines = System.IO.File.ReadAllLines("warning.txt");
            if (lines.Length == 0) return;
            IsWarning = (lines[0] == "1");
        }
    }
}
