using System;
using System.Collections;
using System.Globalization;
using System.Text;

namespace Chapter12
{
    class Reader
    {
        Lazy<Library> library = new Lazy<Library>();
        public void ReadBook()
        {
            library.Value.GetBook();
            Console.WriteLine("Читаем бумажную книгу");
        }

        public void ReadEbook()
        {
            Console.WriteLine("Читаем книгу на компьютере");
        }
    }
    class Library
    {
        ArrayList books = new ArrayList();
        public void GetBook()
        {
            Console.WriteLine("Выдаем книгу читателю");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            reader.ReadEbook();
            reader.ReadBook();
            ArrayList array = new ArrayList();
            int choice = 0, value = 0;
            RecInput(array, value, choice);
            for (int i = 0; i < array.Count; i++)
            {
                int el = (int)array[i];
                double val = (double)el;
                val = Math.Pow(val,2);
                el = (int)val;
                array.Insert(i,el);
                array.RemoveAt(i+1);
            }
            foreach(int i in array)
            {
                Console.WriteLine(i);
            }
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            double b = double.Parse("23.56", formatter);
            int number;
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            bool result = int.TryParse(input, out number);
            if (result == true)
                Console.WriteLine("Преобразование прошло успешно");
            else
                Console.WriteLine("Преобразование завершилось неудачно");
            Console.WriteLine("---------");
            int[] numbers = { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            int[] numbers2 = new int[3];
            // расположим в обратном порядке
            Array.Reverse(numbers);

            // уменьшим массив до 4 элементов
            Array.Resize(ref numbers, 4);

            foreach (int num in numbers)
            {
                Console.Write($"{num} \t");
            }
            Console.WriteLine("------------");
            Array.Copy(numbers, 1, numbers2, 0, 3);
            foreach(int i in numbers2)
            {
                Console.Write($"{i} \t");
            }
            int[] month = new int[30];
            Span<int> monSpan = month;
            Span<int> firstDecade = monSpan.Slice(0, 10);
            Span<int> secondDecade = monSpan.Slice(10, 10);
            Span<int> thirdDecade = monSpan.Slice(20, 10);
            foreach(int i in firstDecade)
            {
                Console.WriteLine(i);
            }

            string text = "hello, world";
            string worldString = text.Substring(startIndex: 7, length: 5);           // есть выделение памяти под символы
            ReadOnlySpan<char> worldSpan = text.AsSpan().Slice(start: 7, length: 5); // нет выделения памяти под символы
                                                                                     //worldSpan[0] = 'a'; // Нельзя изменить
            Console.WriteLine(worldSpan[0]); // выводим первый символ

            // перебор символов
            foreach (var c in worldSpan)
            {
                Console.Write(c);
            }
            Console.WriteLine("------");
            Index start = 1;
            Index end = 4;
            Range myRange1 = start..end;

            Range myRange2 = 1..4;
            string[] people = { "Tom", "Bob", "Sam", "Kate", "Alice" };
            string[] peopleRange = people[1..^1]; // получаем 2, 3 и 4-й элементы из массива
            foreach (var person in peopleRange)
            {
                Console.WriteLine(person);
            }
        }
        static int RecInput(ArrayList array,int value,int choice)
        {
            Console.WriteLine("Input your choice");
            choice=Int32.Parse(Console.ReadLine());
            if (choice == 0)
            {
                return 0;
            }
            else 
            {
                Console.WriteLine("Input value");
                value = Int32.Parse(Console.ReadLine());
                array.Add(value);
               return  RecInput(array,value,choice);
            }
           

        }
    }
 
}
