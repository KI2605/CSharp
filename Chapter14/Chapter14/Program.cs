using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter14
{
    class Program
    {
        static void Main(string[] args)
        {
            //var outer = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Outer task starting...");
            //    Task task = new Task(Display,TaskCreationOptions.AttachedToParent);
            //    task.Start();
                
            //   // task.Wait();
            //});
            //outer.Wait();
           
            //Console.WriteLine("Hello World!");

            //Task[] tasks = new Task[3]
            //{
            //    new Task(()=>Console.WriteLine("First Task")),
            //    new Task(()=>Console.WriteLine("Second Task")),
            //    new Task(()=>Console.WriteLine("Third Task"))
            //};
            //foreach(var t in tasks)
            //{
            //    t.Start();

            //}
            //Task.WaitAll(tasks);
            //Task[] tasks1 = new Task[3];
            //int j = 1;
            //for (int i = 0; i < tasks1.Length; i++)
            //{
            //    tasks1[i] = Task.Factory.StartNew(() => Console.WriteLine($"Task{j++}"));
            //}
            //Task<int> task2 = new Task<int>(() => Factorial(5));
            //task2.Start();

            //Console.WriteLine($"Факториал числа 5 равен {task2.Result}");
            //task2.Wait();
            //Task<Book> task3 = new Task<Book>(()=> {
            //    return new Book { Title = "Война и мир", Author = "Л. Толстой" };

            //});
            //task3.Start();
            //Book b = task3.Result;  // ожидаем получение результата
            //Console.WriteLine($"Название книги: {b.Title}, автор: {b.Author}");
            //Task.WaitAll(task3);
Task task1 = new Task(()=>{
        Console.WriteLine($"Id задачи: {Task.CurrentId}");
    });
 
    // задача продолжения
    Task task2 = task1.ContinueWith(Display);
 
    Task task3 = task1.ContinueWith((Task t) =>
    {
        Console.WriteLine($"Id задачи: {Task.CurrentId}");
    });
 
    Task task4 = task2.ContinueWith((Task t) =>
    {
        Console.WriteLine($"Id задачи: {Task.CurrentId}");
    });
 
    task1.Start();
            task1.Wait();  
    Console.ReadLine();

            ParallelLoopResult result = Parallel.For(1, 10, Factorial);

            if (!result.IsCompleted)
                Console.WriteLine($"Выполнение цикла завершено на итерации {result.LowestBreakIteration}");
            Console.ReadLine();

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            int number = 6;

            Task task = new Task(() =>
            {
                int result = 1;
                for (int i = 1; i <= number; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }

                    result *= i;
                    Console.WriteLine($"Факториал числа {number} равен {result}");
                    Thread.Sleep(5000);
                }
            });
            

            Console.WriteLine("Введите Y для отмены операции или другой символ для ее продолжения:");
            string s = Console.ReadLine();
            task.Start();
            if (s == "Y")
                cancelTokenSource.Cancel();

        }
        static void Factorial(int x, ParallelLoopState pls)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
                if (i == 5)
                    pls.Break();
            }
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Console.WriteLine($"Факториал числа {x} равен {result}");
        }
        static void Display(Task t)
{
    Console.WriteLine($"Id задачи: {Task.CurrentId}");
}
        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }

            return result;
        }
        static void Display()
        {
            Console.WriteLine("Начало работы метода Display");

            Console.WriteLine("Завершение работы метода Display");
        }
    }
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
