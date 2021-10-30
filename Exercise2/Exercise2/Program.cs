using System;
using System.Threading;

namespace Exercise2
{
    class Program
    {
        private static void Main()
        {
            EventHandler h = new EventHandler(MyEventHandler);
            AsyncCaller ac = new AsyncCaller(h);

            if (ac.Invoke(3000, null, EventArgs.Empty))
            {
                Console.WriteLine("Succes");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            EventHandler h1 = new EventHandler(MyEventHandler);
            AsyncCaller ac1 = new AsyncCaller(h1);

            if (ac.Invoke(1, null, EventArgs.Empty))
            {
                Console.WriteLine("Succes");
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }

        private static void MyEventHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Enter MyEventHandler");
            Thread.Sleep(1000);
            Console.WriteLine("Exit MyEventHandler");
        }
    }
}
