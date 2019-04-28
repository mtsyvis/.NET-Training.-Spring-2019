using WatchImitation;
using System;

namespace TimerImitationTest
{
    class Program
    {
        private class TimerSubscriber1
        {
            public void DoWhenTimeIsOver(object sender, TimeIsOverEventArgs e)
            {
                var s = sender as Timer;
                Console.WriteLine($"{nameof(TimerSubscriber1)} {e.Message}. Waiting time {s?.StopTime}");
            }
        }

        private class TimerSubscriber2
        {
            public void DoWhenTimeIsOver(object sender, TimeIsOverEventArgs e)
            {
                var s = sender as Timer;
                Console.WriteLine($"{nameof(TimerSubscriber2)} {e.Message}. Waiting time {s?.StopTime}");
            }
        }

        static void Main(string[] args)
        {
            var timer = new Timer(3);
            var subscriber1 = new TimerSubscriber1();
            var subscriber2 = new TimerSubscriber2();

            timer.TimerHasStopped += subscriber1.DoWhenTimeIsOver;
            timer.TimerHasStopped += subscriber2.DoWhenTimeIsOver;

            timer.Start();
        }
    }
}
