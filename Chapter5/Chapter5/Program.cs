using System;

namespace Chapter5
{
    
    class Program
    {
        delegate int Operat(int a, int b);
        delegate T Operation<T, K>(K val);
        delegate int Operation(int x, int y);
        delegate bool IsEqual(int x);
        private static int Add(int a, int b)
        {
            return a + b;
        }
        private static int Multiple(int a, int b)
        {
            return a * b;
        }
        static decimal Square(int n)
        {
            return n * n;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Operat operat = Add;
            int result = operat(4, 5);
            Console.WriteLine(operat);
            Console.WriteLine(result);
            operat += Multiple;
            result = operat(4, 5);
            Console.WriteLine(result);
            operat -= Multiple;
            result = operat(3, 4);
            Console.WriteLine(result);
            operat -= Add;
            Console.WriteLine($"{operat?.Invoke(6, 4)}");

            Operation<decimal, int> op = Square;

            Console.WriteLine(op(5));



            Account account = new Account(200);
            // Account.AccountStateHandler colorDelegate = new Account.AccountStateHandler(Color_Message);

            // Добавляем в делегат ссылку на методы
            //account.RegisterHandler(new Account.AccountStateHandler(Show_Message));
            //account.RegisterHandler(colorDelegate);
            // Два раза подряд пытаемся снять деньги
            account.Notify += Show_Message;
            account.Withdraw(100);
            account.Notify += Show_Message;
            account.Withdraw(150);
           // account.Notify += Show_Message;
            // Удаляем делегат
            //account.DeleteHandler(colorDelegate);
            account.Withdraw(50);
            account.Notify += Show_Message;

            //Operation operation = delegate (int x, int y)
            //{
            //    return x + y;
            //};
            //int d = operation(4, 5);
            //Console.WriteLine(d);

            int z = 8;
            Operation operation = delegate (int x, int y)
            {
                return x + y + z;
            };
            int d = operation(4, 5);
            Console.WriteLine(d);

            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // найдем сумму чисел больше 5
            int result1 = Sum(integers, x => x > 5);
            Console.WriteLine(result1); // 30

            // найдем сумму четных чисел
            int result2 = Sum(integers, x => x % 2 == 0);
            Console.WriteLine(result2);  //2

            PersonFactory personDel;
            personDel = BuildClient; // ковариантность
            Person p = personDel("Tom");
            Console.WriteLine(p.Name);
            Console.Read();


            /*Несмотря на то, что делегат в качестве параметра принимает объект Client, 
             * ему можно присвоить метод, принимающий в качестве параметра объект базового типа Person.
             * Может показаться на первый взгляд, что здесь есть некоторое противоречие,
             * то есть использование более универсального тип вместо более производного. 
             * Однако в реальности в делегат при его вызове мы все равно можем передать только объекты типа Client,
             * а любой объект типа Client является объектом типа Person, который используется в методе.*/

            ClientInfo clientInfo = GetPersonInfo; // контравариантность
            Client client = new Client { Name = "Alice" };
            clientInfo(client);

            Predicate<int> isPositive = delegate (int x) { return x > 0; };

            Console.WriteLine(isPositive(20));
            Console.WriteLine(isPositive(-20));

            Func<int, int> retFunc = Factorial;
            int n1 = GetInt(6, retFunc);
            Console.WriteLine(n1);  // 720

            int n2 = GetInt(6, x => x * x);
            Console.WriteLine(n2); // 36
            Console.Read();
        }
        private static void GetPersonInfo(Person p)
        {
            Console.WriteLine(p.Name);
        }
        private static int Sum(int[] numbers, IsEqual func)
        {
            int result = 0;
            foreach (int i in numbers)
            {
                if (func(i))
                    result += i;
            }
            return result;
        }
        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }
        private static void Color_Message(string message)
        {
            // Устанавливаем красный цвет символов
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            // Сбрасываем настройки цвета
            Console.ResetColor();
        }
        private static Client BuildClient(string name)
        {
            return new Client { Name = name };
        }
        static int GetInt(int x1, Func<int, int> retF)
        {
            int result = 0;
            if (x1 > 0)
                result = retF(x1);
            return result;
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
    }
    class Person
    {
        public string Name { get; set; }
    }
    class Client : Person
    {
        
    }
   
    delegate Person PersonFactory(string name);
    delegate void ClientInfo(Client client);
}
