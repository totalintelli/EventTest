using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    delegate void EventHandler(string message);

    class MainApp
    {
        static void Main(string[] args)
        {
            Notifier Notifier = new Notifier();
            Notifier.PlayGameEvent += new EventHandler(MyHandler);

            for(int i = 0; i < 30; i++)
            {
                Notifier.DoSomething(i);
            }

        }

        static void MyHandler(string message)
        {
            Console.WriteLine(message);
        }
        
    }

    class Notifier
    {
        public event EventHandler PlayGameEvent;

        public void DoSomething(int number)
        {
            int tmp = number % 10;

            if(tmp != 0 && tmp % 3 == 0)
            {
                PlayGameEvent(String.Format("{0} : 짝", number));
            }
        }
    }
}
