using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerSinglton
{
    internal class TimerChecker
    {
        private readonly Timer _timer;

        //private static TimerChecker _instance;
        //public static TimerChecker GetInstance()
        //{
        //    return _instance ?? (_instance = new TimerChecker());
        //}

        public static TimerChecker Instance { get; } = new TimerChecker();

        private  TimerChecker()
        {
            _timer = new Timer(TimerCallBack);
        }

        public  void Start()
        {
            _timer.Change(0, 5000);
        }

        private void TimerCallBack(object sender)
        {
            Console.WriteLine(DateTime.Now.ToString());
        }
    }
}
