using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelloApp
{
    class Program
    {
        static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            
            return result;
            //Thread.Sleep(8000);
        }
        static void Factor(int n, CancellationToken token)
        {
            int result = 1;
            if (n < 1)
            {
                throw new Exception("The value shoud be more then 1");
            }
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Операция прервана токеном");
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал равен {result}");
        }
        // определение асинхронного метода
        static async void FactorialAsync(int n,CancellationToken token)
        {
            try
            {

                if (token.IsCancellationRequested)
                    return;
                await Task.Run(() => Factor(n, token));
            }
            catch(Exception ex)
            {
                await Task.Run(() => Console.WriteLine(ex.Message));
            }
            finally
            {
                await Task.Run(() => Console.WriteLine("await в блоке finally"));
            }
        }
        static async Task FactorialAs(int n)
        {
            await Task.Run(() => Factorial(n));
        }
        static async Task<int> FactAs(int n)
        {
            return await Task.Run(() => Factorial(n));
        }

        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            //FactorialAsync(-5,token);
            FactorialAsync(6,token);
           // FactorialAs(4);
            Thread.Sleep(3000);
            cts.Cancel();
            //int n1 = await FactAs(3);
            //Console.WriteLine(n1);
           // Console.WriteLine("Некоторая работа");
            // Console.Read();
            
        }
    }
}

