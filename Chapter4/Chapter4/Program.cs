using System;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            int y = 0;

            try
            {
                int result = x / y;
            }

            catch (DivideByZeroException) when (y == 0 && x == 0)
            {
                Console.WriteLine("y не должен быть равен 0");
            }
            catch (DivideByZeroException) when (y == 0)
            {
                Console.WriteLine("y не должен быть равен 0!!!");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                int x1 = 5;
                int y1 = x1 / 0;
                Console.WriteLine($"Результат: {y1}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");
                Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            }
            try
            {
                object obj = "you";
                int num = (int)obj;     // InvalidCastException
                Console.WriteLine($"Результат: {num}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Возникло исключение DivideByZeroException");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Возникло исключение IndexOutOfRangeException");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
            try
            {
                Person p = new Person("Tom", 17);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            try
            {
                Human h = new Human { Name = "Tom", Age = 13 };
            }
            catch (MyExceptions ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Incorrect value: {ex.Value}");
            }


            Console.WriteLine("/n/n");
            try
            {
                TestClass.Method1();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Catch в Main : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally в Main");
            }
            Console.WriteLine("Конец метода Main");
            Console.Read();

            try
            {
                Console.Write("Введите строку: ");
                string message = Console.ReadLine();
                if (message.Length > 6)
                {
                    throw new Exception("Длина строки больше 6 символов");
                }
            }            
            catch
            {
                Console.WriteLine("Возникло исключение");
                throw;
            }
            
        }
    }
    class TestClass
    {
        public static void Method1()
        {
            try
            {
                Method2();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Catch в Method1 : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally в Method1");
            }
            Console.WriteLine("Конец метода Method1");
        }
        static void Method2()
        {
            try
            {
                int x = 8;
                int y = x / 0;
            }
            finally
            {
                Console.WriteLine("Блок finally в Method2");
            }
            Console.WriteLine("Конец метода Method2");
        }
    }
    class Person
    {
        private int age;
        public string Name
        {
            get; set;
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age < 18)
                {
                    throw new Exception("You are too young, come back after 18");
                }
                else
                {
                    age = value;
                }
            }
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

    }
    class MyExceptions : Exception
    {
        public int Value { get; }
        public MyExceptions(string message, int val) : base(message)
        {
            Value = val;
        }
    }
    class Human
    {
        public string Name { get; set; }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18)
                    throw new MyExceptions("You can't register under 18", value);
                else
                    age = value;
            }
        }
    }
        
    }
