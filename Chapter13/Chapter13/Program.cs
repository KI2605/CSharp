using System;
using System.Threading;

namespace Chapter13
{
    class Program
    {
        static int x = 0;
        static object locker = new object();
        static readonly int Foo = 42;
        static void Main(string[] args)
        { 
        //{
        //    Thread t = Thread.CurrentThread;
        //    Console.WriteLine(t.Name);
        //    Console.WriteLine(t.Priority);
        //    Console.WriteLine(t.ThreadState);
        //    Console.WriteLine($"Домен приложения: {Thread.GetDomainID()}");
        //    t.Name = "Main Thread";
        //    t.Priority = ThreadPriority.AboveNormal;
        //    Console.WriteLine(t.Name);
        //    Console.WriteLine(t.Priority);
        //    Thread.Sleep(10000);
        //    Console.WriteLine(t.ThreadState);

        //    Thread myThread = new Thread(new ThreadStart(Count));
        //    myThread.Start(); // запускаем поток

        //    for (int i = 1; i < 9; i++)
        //    {
        //        Console.WriteLine("Главный поток:");
        //        Console.WriteLine(i * i);
        //        Thread.Sleep(300);
        //    }
            
        //    Console.ReadLine();
        //    int number = 4;
        //    Thread nthread = new Thread(new ParameterizedThreadStart(NCount));
        //    nthread.Start(number);
        //    for (int i = 1; i < 9; i++)
        //    {
        //        Console.WriteLine("Главный поток:");
        //        Console.WriteLine(i * i);
        //        Thread.Sleep(300);
        //    }
        //    Console.WriteLine("-----------");
        //    Counter counter = new Counter(5, 4);

        //    Thread myTh= new Thread(new ThreadStart(counter.Count));
        //    myTh.Start();
            //........................
            //for(int i = 0; i < 5; i++)
            //{
            //    Thread thread = new Thread(Operation);
            //    thread.Name = "Поток " + i.ToString();
            //    thread.Start();
            //}
            var thread1 = new Thread(() => Console.WriteLine(Foo));
            thread1.Start();
            thread1.Join();
            Console.WriteLine("-------------");
            for (int i = 0; i < 5; i++)
            {
                Thread thread2 = new Thread(Count);
                thread2.Name = $"Поток {i.ToString()}";
                thread2.Start();
            }

        }
        public static void Count2()
        {
            bool acquired = false;
            try
            {
                Monitor.Enter(locker, ref acquired);
                x = 1;
                for (int i = 1; i < 9; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Thread.Sleep(100);
                }
            }
            finally
            {
                if (acquired)
                {
                    Monitor.Exit(locker);
                }
            }
        }
        public static void Operation()
        {
            lock (locker)
            {
                x = 1;
                for (int i = 1; i < 9; i++)
                {
                    Console.WriteLine("{0}: {1}",Thread.CurrentThread.Name,x);
                    x++;
                    Thread.Sleep(100);
                }            
            }
            
        }
        public static void Count()
        {
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(400);
            }
        }
        public static void NCount(object x)
        {
            for (int i = 0; i < 9; i++)
            {
                int n = (int)x;
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * n);
                Thread.Sleep(400);
            }
        }
        //public static void DCount(object x)
        //{
        //    for (int i = 1; i < 9; i++)
        //    {
        //        Counter c = (Counter)x;

        //        Console.WriteLine("Второй поток:");
        //        Console.WriteLine($"{i * c.x} {i * c.y}");
        //    }
        //}
    }

    public class Counter
    {
        private int x;
        private int y;

        public Counter(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public void Count()
        {
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * x * y);
                Thread.Sleep(400);
            }
        }

        
    }
    
}