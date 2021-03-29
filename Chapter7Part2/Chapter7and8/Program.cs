using System;

namespace Chapter7Part2
{
    class Person
    {
        public string Name { get; init; }
        public int Age { get; set; }
        public string Status { get; set; }      // статус пользователя
        public string Language { get; set; }    // язык пользователя
        public void Deconstruct(out string name, out int age)
        {
            name = this.Name;
            age = this.Age;
        }

    }

    class Program
    {
        static string GetMessage(Person p) => p switch
        {
            { Language: "german", Status: "admin" } => "Hallo, admin!",
            { Language: "french", Name: var name } => $"Salut, {name}!",
            { Language: var lang } => $"Unknown language: {lang}",
            null => "null"
        };
        static string GetWelcome(string lang, string daytime, string status) => (lang, daytime, status) switch
        {
            ("english", "morning", _) => "Good morning",
            ("english", "evening", _) => "Good evening",
            ("german", "morning", _) => "Guten Morgen",
            ("german", "evening", _) => "Guten Abend",
            (_, _, "admin") => "Hello, Admin",
            _ => "Здрасьть"
        };
        static decimal Calculate(decimal sum)
        {
            return sum switch
            {
                <= 0 => 0,              // если sum меньше или равно 0, возвращаем 0
                < 50000 => sum * 0.05m, // если sum меньше 50000, возвращаем sum * 0.05m
                < 100000 => sum * 0.1m, // если sum меньше 100000, возвращаем sum * 0.1m
                _ => sum * 0.2m        // в остальных случаях возвращаем sum * 0.2m
            };
        }
        static string CheckAge(int age)
        {
            return age switch
            {
                < 1 or > 110 => "Недействительный возраст",   // если age больше 110 и меньше 1
                >= 1 and < 18 => "Доступ запрещен",           // если age равно или больше 1 и меньше 18
                _ => "Доступ разрешен"                      // в остальных случаях
            };

        }
        static ref int Find(int number, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                {
                    return ref numbers[i]; // возвращаем ссылку на адрес, а не само значение
                }
            }
            throw new IndexOutOfRangeException("число не найдено");
        }
        static ref int Max(ref int n1, ref int n2)
        {
            if (n1 > n2)
                return ref n1;
            else
                return ref n2;
        }
        static void Main(string[] args)
        {
            Person person = new Person { Language = "French", Status = "User", Name = "Tom", Age = 33 };

            (string name, int age) = person;

            Console.WriteLine(name);    // Tom
            Console.WriteLine(age);     // 33        }

            Person pierre = new Person { Language = "french", Status = "user", Name = "Pierre" };
            string message = GetMessage(pierre);
            Console.WriteLine(message);             // Salut, Pierre!

            Person tomas = new Person { Language = "german", Status = "admin", Name = "Tomas" };
            Console.WriteLine(GetMessage(tomas));     // Hallo, admin!

            Person pablo = new Person { Language = "spanish", Status = "user", Name = "Pablo" };
            Console.WriteLine(GetMessage(pablo));     // Unknown language: spanish

            Person bob = null;
            Console.WriteLine(GetMessage(bob));

            string mes = GetWelcome("english", "evening", "user");
            Console.WriteLine(mes);  // Good evening

            mes = GetWelcome("french", "morning", "admin");
            Console.WriteLine(mes);  // Hello, Admin
            Console.WriteLine(CheckAge(21));
            int? x = null;
            if (x.HasValue)
                Console.WriteLine(x.Value);
            else
                Console.WriteLine("x is equal to null");
            Person p = null;
            Console.WriteLine(p);
            int? figure = null;
            Console.WriteLine(figure.GetValueOrDefault()); // по умолчанию используется 0
            Console.WriteLine(figure.GetValueOrDefault(10)); // по умолчанию используется 10
            //явные сужающие преобразования от V к T?
            long x1 = 4;
            int? x2 = (int?)x1;

            int a = 5;
            int b = 8;
            ref int pointer = ref a;
            pointer = 34;
            pointer = ref b;    // до версии 7.3 так делать было нельзя
            pointer = 6;
            Console.WriteLine(a);
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            ref int refnumber = ref Find(4, numbers);
            refnumber = 9;
            Console.WriteLine(numbers[3]);

            ref int po = ref Max(ref a, ref b);
            po = 3;   // меняем значением максимального числа
            Console.WriteLine($"a: {a}  b: {b}"); // a: 5   b: 34

            var pers = new Pers("Tom", 36);
            Console.WriteLine(pers.Name); // Tom

            var (userName, userAge) = pers;

            Console.WriteLine(userAge);     // 36
            Console.WriteLine(userName);    // Tom

            var h1 = new Human() { Name = "Joe" };
            var h2 = new Human() { Name = "Joe" };

            var user1 = new User() { Name = "Alex" };
            var user2 = new User() { Name = "Tony" };
            Console.WriteLine(h1.Equals(h2));
            Console.WriteLine(user1.Equals(user2));

            var h3 = new Human() { Name = "Frank", Age = 12 };
            var h4 = h3 with { Name = "Daniel" };
            Console.WriteLine(h4.Age);
        }
        public record Pers(string Name, int Age);
       
    }
        public record Human
        {
            public string Name { get; init; }
            public int Age { get; set; }
        }
        public class User
        {
            public string Name { get; init; }
            public int Age { get; init; }
        }
    }
