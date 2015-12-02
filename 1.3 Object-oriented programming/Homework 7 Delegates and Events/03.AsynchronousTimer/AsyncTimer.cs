using System;
using System.Threading;

namespace _03.AsynchronousTimer
{
    public class AsyncTimer
    {
        public AsyncTimer(Action<int> methodToExecute, int ticks, int intervalInMilliseconds)
        {
            this.MethodToExecute = methodToExecute;
            this.Ticks = ticks;
            this.IntervalInMilliseconds = intervalInMilliseconds;
        }

        private Action<int> MethodToExecute { get; set; }

        public int Ticks { get; private set; }

        public int IntervalInMilliseconds { get; private set; }

        public void ExecuteAction()
        {
            var run = new Thread(this.Run);
            run.Start();
        }

        private void Run()
        {
            for (int i = 0; i < this.Ticks; i++)
            {
                Thread.Sleep(this.IntervalInMilliseconds);

                if (this.MethodToExecute != null)
                {
                    this.MethodToExecute(i);
                }
            }
        }
    }
}
