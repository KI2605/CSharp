using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter16
{
    class Program
    {
        static void Main(string[] args)
        {
//            string[] teams = { "Челси", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
//            var selectedteams = from t in teams
//                                where t.ToUpper().StartsWith("Б")
//                                orderby t
//                                select t;
//            var selectedteams1 = teams.Where(t => t.ToUpper().StartsWith("Ч")).OrderBy(t => t);
//            foreach (var s in selectedteams)
//            {
//                Console.WriteLine(s);
//            }
//            Thread.Sleep(5000);
//            foreach (var s in selectedteams1)
//            {
//                Console.WriteLine(s);
//            }
//            Thread.Sleep(5000);
//            var cards = from s in Suits()
//                        from r in Ranks()
//                        select new { Suits = s, Ranks = r };
//            foreach (var card in cards)
//            {
//                Console.WriteLine(card);
//            }
//            var startingDeck = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));
//            foreach (var card in cards)
//            {
//                Console.WriteLine(card);
//            }
//            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
//            IEnumerable<int> evens = numbers.Where(i => i % 2 == 0);
//            foreach (int i in evens)
//            {
//                Console.WriteLine(i);
//            }
//            Thread.Sleep(5000);
//            List<User> users = new List<User>()
//            {
//                new User(){Name="Anton",Age=21,Languages={"english","russian" } },
//                new User(){Name="Michael",Age=32,Languages={"english","russian","german" } },
//                new User(){Name="Jeka",Age=17,Languages={"english","russian","german"}},
//                 new User(){Name="Viktor",Age=18,Languages={"english","russian","ukrainian" } },
//                 new User(){Name="Oleh",Age=32,Languages={"english","russian","german" } }
//        };
//            var NeededUsers = from u in users
//                              where u.Age >= 18 && u.Languages.Count > 2 && u.Languages.Contains("german")
//                              orderby u.Age
//                              select u;
//            foreach (var i in NeededUsers)
//            {
//                Console.WriteLine($"Name:{i.Name} Age:{i.Age} Languages:{i.Languages}");
//            }
//            var people = from u in NeededUsers
//                         let name = "Mr/Miss " + u.Name
//                         select new
//                         {
//                             Name = name,
//                             Age = u.Age,
//                             Language = u.Languages
//                         };
//            foreach (var p in people)
//            {
//                Console.WriteLine(p.Name);
//            }
//            List<Phone> phones = new List<Phone>()
//            {
//               new Phone {Name="Lumia 630", Company="Microsoft" },
//               new Phone {Name="iPhone 6", Company="Apple"},
//             };
//            var richusers = from u in NeededUsers
//                            from ph in phones
//                            select new { Name = u.Name, Phone = ph.Name };
//            foreach(var r in richusers)
//            {
//                Console.WriteLine($"Name:{r.Name} Phone:{r.Phone}");
//            }

//            string[] soft = { "Microsoft", "Google", "Apple" };
//            string[] hard = { "Apple", "IBM", "Samsung" };
//            var result = soft.Except(hard);//исключает значения soft, которые совпадают с hard
//            var result1 = soft.Intersect(hard);//ищем совпадения(пересечения)
//            var result2 = soft.Concat(soft).Distinct();

//            foreach (string s in result)
//            {
//                Console.WriteLine(s);
//            }
//            Console.WriteLine("----------");
//            foreach (string s in result1)
//            {
//                Console.WriteLine(s);
//            }
//            Console.WriteLine("------------");

//            int[] numbers2 = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
//            List<User> users2 = new List<User>()
//            {
//               new User { Name = "Tom", Age = 23 },
//               new User { Name = "Sam", Age = 43 },
//               new User { Name = "Bill", Age = 35 }
//              };
//            int query = numbers.Aggregate((x, y) => x - y);
//            Console.WriteLine(query);
//            int size = (from i in numbers where i % 2 == 0 && i > 10 select i).Count();
//            Console.WriteLine(size);
//            int sum1 = numbers.Sum();
//            decimal sum2 = users.Sum(n => n.Age);
//            int min1 = numbers.Min();
//            int min2 = users.Min(n => n.Age); // минимальный возраст

//            int max1 = numbers.Max();
//            int max2 = users.Max(n => n.Age); // максимальный возраст

//            double avr1 = numbers.Average();
//            double avr2 = users.Average(n => n.Age); //средний возраст

//            var result3 = numbers.Skip(4).Take(3);

//            foreach (int i in result3)
//                Console.WriteLine(i);

           
//            foreach (var t in teams.TakeWhile(x => x.StartsWith("Б")))
//                Console.WriteLine(t);

//            List<Phone> phones2 = new List<Phone>
//{
//    new Phone {Name="Lumia 430", Company="Microsoft" },
//    new Phone {Name="Mi 5", Company="Xiaomi" },
//    new Phone {Name="LG G 3", Company="LG" },
//    new Phone {Name="iPhone 5", Company="Apple" },
//    new Phone {Name="Lumia 930", Company="Microsoft" },
//    new Phone {Name="iPhone 6", Company="Apple" },
//    new Phone {Name="Lumia 630", Company="Microsoft" },
//    new Phone {Name="LG G 4", Company="LG" }
//};

//            var phoneGroups = from phone in phones2
//                              group phone by phone.Company;

//            foreach (IGrouping<string, Phone> g in phoneGroups)
//            {
//                Console.WriteLine(g.Key);
//                foreach (var t in g)
//                    Console.WriteLine(t.Name);
//                Console.WriteLine();
//            }
//            var phoneGroups2 = from phone in phones2
//                               group phone by phone.Company into g
//                               select new { Name = g.Key, Count = g.Count() };         //phoneGroups2 and phonegroups3 are the same
//            var phoneGroups3 = phones2.GroupBy(p => p.Company)
//                        .Select(g => new { Name = g.Key, Count = g.Count() });
//            foreach (var group in phoneGroups2)
//                Console.WriteLine($"{group.Name} : {group.Count}");
//            foreach (var group in phoneGroups3)
//                Console.WriteLine($"{group.Name} : {group.Count}");

//            Console.WriteLine("-----------");
//            List<Team> teams3 = new List<Team>()
//{
//    new Team { Name = "Бавария", Country ="Германия" },
//    new Team { Name = "Барселона", Country ="Испания" }
//};
//            List<Player> players = new List<Player>()
//{
//    new Player {Name="Месси", Team="Барселона"},
//    new Player {Name="Неймар", Team="Барселона"},
//    new Player {Name="Роббен", Team="Бавария"}
//};
//            var res = from pl in players
//                      join t in teams3 on pl.Team equals t.Name
//                      select new { Name = pl.Name, Team = pl.Team, Country = t.Country };
//            /* var result = players.Join(teams, // второй набор
//             p => p.Team, // свойство-селектор объекта из первого набора
//             t => t.Name, // свойство-селектор объекта из второго набора
//             (p, t) => new { Name = p.Name, Team = p.Team, Country = t.Country }); // результат*/

//            //Метод Join() принимает четыре параметра:

//            //второй список, который соединяем с текущим

//            //свойство объекта из текущего списка, по которому идет соединение

//            //свойство объекта из второго списка, по которому идет соединение

//            //новый объект, который получается в результате соединения


//            foreach (var item in res)
//                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");

//            var res2 = teams3.GroupJoin(
//                        players, // второй набор
//                        t => t.Name, // свойство-селектор объекта из первого набора
//                        pl => pl.Team, // свойство-селектор объекта из второго набора
//                        (team, pls) => new  // результирующий объект
//                        {
//                            Name = team.Name,
//                            Country = team.Country,
//                            Players = pls.Select(p => p.Name)
//                        });

//            foreach (var team in res2)
//            {
//                Console.WriteLine(team.Name);
//                foreach (string player in team.Players)
//                {
//                    Console.WriteLine(player);
//                }
//                Console.WriteLine();

//            }
//            List<User> users4 = new List<User>()
//{
//    new User { Name = "Tom", Age = 23 },
//    new User { Name = "Sam", Age = 43 },
//    new User { Name = "Bill", Age = 35 }
//};

//            bool result4 = users4.All(u => u.Age > 20); // true
//            if (result4)
//                Console.WriteLine("У всех пользователей возраст больше 20");
//            else
//                Console.WriteLine("Есть пользователи с возрастом меньше 20");

//            bool result5 = users4.All(u => u.Name.StartsWith("T")); //false
//            if (result5)
//                Console.WriteLine("У всех пользователей имя начинается с T");
//            else
//                Console.WriteLine("Не у всех пользователей имя начинается с T");


//            bool result6 = users4.Any(u => u.Age <18);
//            if (result6)
//                Console.WriteLine("Есть пользователи с возрастом меньше 18");
//            else
//                Console.WriteLine("У всех пользователей возраст больше 18");
//            //отложенный запрос
//            var selectedTeams2 = from t in teams where t.ToUpper().StartsWith("Б") orderby t select t;
//            teams[1] = "Милан";
//            foreach(var s in selectedTeams2)
//            {
//                Console.WriteLine(s);
//            }
//            //немедленный запрос
//            int y = (from t in teams
//                     where t.ToUpper().StartsWith("Б")
//                     orderby t
//                     select t).Count();
//            Console.WriteLine(y); //1
//            teams[1] = "Боруссия";
//            Console.WriteLine(y); //1
//            Console.WriteLine();
//            //отложенный
//            var selectedTeams3 = from t in teams
//                                where t.ToUpper().StartsWith("Б")
//                                orderby t
//                                select t;
//            // выполнение запроса
//            Console.WriteLine(selectedTeams3.Count()); //2
//            teams[1] = "Ювентус";
//            // выполнение запроса
//            Console.WriteLine(selectedTeams3.Count()); //1

//            //немедленный запрос
//            var selectedTeams4 = (from t in teams
//                                 where t.ToUpper().StartsWith("Б")
//                                 orderby t
//                                 select t).ToList<string>();
//            // изменение массива никак не затронет список selectedTeams
//            teams[1] = "Боруссия";

//            foreach (string s in selectedTeams4)
//                Console.WriteLine(s);

//            int[] numbs = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
//            var re = numbs.Where(i => i > 0).Select(Factorial);
//            foreach(int i in re)
//            {
//                Console.WriteLine(i);
//            }
//            Console.WriteLine("-----");
//            Console.WriteLine("------CHAPTER 17-----");
//            (from n in numbs.AsParallel() where n > 0 select Factorial(n)).ForAll(Console.WriteLine);
//            Console.WriteLine("------");
//            var fnum1 = from n in numbs.AsParallel().AsOrdered() where n > 0 select Factorial(n);
//            foreach(int i in fnum1)
//            {
//                Console.WriteLine(i);
//            }
//            Console.WriteLine("----");
//            var fnum2 = from n in fnum1.AsUnordered()
//                        where n > 100
//                        select n;
//            foreach (int i in fnum2)
//            {
//                Console.WriteLine(i);
//            }
//            Console.WriteLine("------");

            //cANCELL 
            CancellationTokenSource cts = new CancellationTokenSource();
            new Task(() =>
            {
                Thread.Sleep(400);
                cts.Cancel();
            }).Start();
            int[] numbers4 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            try
            {  
                var factorials = from n in numbers4.AsParallel().WithCancellation(cts.Token)
                                 select Factorial1(n);
                foreach (var n in factorials)
                    Console.WriteLine(n);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Операция была прервана");
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions != null)
                {
                    foreach (Exception e in ex.InnerExceptions)
                        Console.WriteLine(e.Message);
                }
            }
            finally
            {
                cts.Dispose();
            }
            Console.ReadLine();
        }
        static int Factorial1(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал числа {x} равен {result}");
            Thread.Sleep(400);
            return result;
        }
        static int Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
            static IEnumerable<string> Suits()
            {
                yield return "clubs";
                yield return "diamonds";
                yield return "hearts";
                yield return "spades";
            }
            static IEnumerable<string> Ranks()
            {
                yield return "two";
                yield return "three";
                yield return "four";
                yield return "five";
                yield return "six";
                yield return "seven";
                yield return "eight";
                yield return "nine";
                yield return "ten";
                yield return "jack";
                yield return "queen";
                yield return "king";
                yield return "ace";

            }
        }
    public class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public class Player
    {
        public string Name { get; set; }
       public  string Team { get; set; }
    }
    public class Phone
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }
    public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
            public User()
            {
                Languages = new List<string>();
            }
            //public override string ToString()
            //{
            //    foreach (string s in Languages)
            //    {
            //        Console.WriteLine(s);

            //    }
            //    return base.ToString();
            //}
        }
    }

