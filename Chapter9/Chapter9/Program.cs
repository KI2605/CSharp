using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace Chapter9
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add(2.3);
            list.Add(2);
            list.AddRange(new string[] { "Hello" });
           
            list.Insert(3, 28);
           // list.Sort();
            foreach (object o in list)
            {
                Console.WriteLine(o);
            }
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, };
            numbers.Add(6);
            numbers.AddRange(new int[] { 7, 8, 9 });
            numbers.Insert(0, 0);
            numbers.Insert(8, 12);
            numbers.RemoveAt(1);
            numbers.Sort();
            foreach(int i in numbers)
            {
                Console.WriteLine(i);
            }

            List<Person> people = new List<Person>(3);
            people.Add(new Person() {Name="Tom",Age=18 });
            people.Add(new Person() { Name = "Bob", Age = 20 });
            foreach (Person p in people)
            {
                Console.WriteLine($"Name:{p.Name} Age:{p.Age}");
            }

            LinkedList<int> nums = new LinkedList<int>();
            nums.AddFirst(24);
            nums.AddAfter(nums.Last, 34);
            nums.AddLast(22);
            foreach(int i in nums)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("---------");
            Queue<int> cars = new Queue<int>();
            cars.Enqueue(1);
            cars.Enqueue(4);
            cars.Enqueue(2);
            cars.Dequeue();
            foreach(int i in cars)
            {
                Console.WriteLine(i);
            }
            Queue<Person> line = new Queue<Person>();
            line.Enqueue(new Person() { Name = "Tommy", Age = 34 });
            line.Enqueue(new Person() { Name = "Mett", Age = 21 });
            Person p1=line.Peek();
            Console.WriteLine(p1.Name);
            Console.WriteLine("-----------");
            Stack<int> digits = new Stack<int>();
            digits.Push(3);
            digits.Push(1);
            digits.Push(4);
            digits.Pop();
            foreach(int i in digits)
            {
                Console.WriteLine(i);
            }
            Dictionary<string, Person> pers = new Dictionary<string, Person>() { ["ukrainian"] = new Person() { Name = "Olga", Age = 23 } };
            pers.Add("american", new Person() { Name = "Bella", Age = 27 });
            pers.Add("english", new Person() { Name = "Judy", Age = 22 });
            foreach (KeyValuePair<string, Person> keyValue in pers)
            {
                // keyValue.Value представляет класс Person
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value.Name);
            }
            foreach(string s in pers.Keys)
            {
                Console.WriteLine(s);
            }
            foreach(Person p in pers.Values)
            {
                Console.WriteLine(p.Name);
            }
            ObservableCollection<Person> classroom = new ObservableCollection<Person>()
            {
            new Person(){Name="Egor",Age=12},
            new Person() { Name = "Eva", Age = 11 },
            new Person(){Name="Alex",Age=11}
            };
            classroom.CollectionChanged += Collection_Changed;
            classroom.RemoveAt(0);
            classroom[1] = new Person() { Name = "Denis", Age = 11 };
            foreach(Person p in classroom)
            {
                Console.WriteLine(p.Name);
            }

            Week week = new Week();
            foreach (var day in week)
            {
                Console.WriteLine(day);
            }

            Library library = new Library();
 
foreach (Book b in library.GetBooks(5))
{
    Console.WriteLine(b.Name);
}
            Console.Read();
        }
        private static void Collection_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Person newstudent = e.NewItems[0] as Person;
                    Console.WriteLine($"Добавлен новый объект: {newstudent.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Person oldstudent = e.OldItems[0] as Person;
                    Console.WriteLine($"Удален один обьект: {oldstudent.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    Person replacedStudent = e.OldItems[0] as Person;
                    Person replacingStudent = e.NewItems[0] as Person;
                    Console.WriteLine($"Объект {replacedStudent.Name} заменен объектом {replacingStudent.Name}");
                    break;


            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Week
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                            "Friday", "Saturday", "Sunday" };
 
        public IEnumerator<string> GetEnumerator()
        {
            return new WeekEnumerator(days);
        }
    }
    class WeekEnumerator : IEnumerator<string>
    {
        string[] days;
        int position = -1;
        public WeekEnumerator(string[] days)
        {
            this.days = days;
        }
         
        public string Current
        {
            get
            {
                if (position == -1 || position >= days.Length)
                    throw new InvalidOperationException();
                return days[position];
            }
        }
 
        object IEnumerator.Current => throw new NotImplementedException();
         
        public bool MoveNext()
        {
            if(position < days.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
 
        public void Reset()
        {
            position = -1;
        }
        public void Dispose() { }
    }
    class Book
    {
        public Book(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

    class Library
    {
        private Book[] books;

        public Library()
        {
            books = new Book[] { new Book("Отцы и дети"), new Book("Война и мир"),
            new Book("Евгений Онегин") };
        }

        public int Length
        {
            get { return books.Length; }
        }

        public IEnumerable GetBooks(int max)
        {
            for (int i = 0; i < max; i++)
            {
                if (i == books.Length)
                {
                    yield break;
                }
                else
                {
                    yield return books[i];
                }
            }
        }
    }
}
