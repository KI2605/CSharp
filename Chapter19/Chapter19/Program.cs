using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Chapter19
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pers = new Person() { Name = "Vasya", Age = 21 };
            Console.WriteLine(pers.Age);
            pers.Age += 5;
            Console.WriteLine(pers.Age);
            dynamic person1 = new Person() { Name = "Том", Age = 27 };
            Console.WriteLine(person1);
            Console.WriteLine(person1.getSalary(28.09, "int"));

            dynamic person2 = new Person() { Name = "Билл", Age = "Двадцать два года" };
            Console.WriteLine(person2);
            Console.WriteLine(person2.getSalary(30, "string"));

            dynamic viewbag = new System.Dynamic.ExpandoObject();
            viewbag.Name = "Tom";
            viewbag.Age = 21;
            viewbag.Languages = new List<string> { "english", "russian" };
            Console.WriteLine($"{viewbag.Name} - {viewbag.Age}");
            foreach (var lang in viewbag.Languages)
                Console.WriteLine(lang);

            viewbag.IncrementAge = (Action<int>)(x => viewbag.Age += x);
            viewbag.IncrementAge(6); // увеличиваем возраст на 6 лет
            Console.WriteLine($"{viewbag.Name} - {viewbag.Age}");

            Console.ReadLine();

            dynamic person = new PersonObject();
            person.Name = "Tom";   //Выражение person.Name = "Tom" будет вызывать метод TrySetMember,
                                   //в который в качестве второго параметра будет передаваться строка "Tom".
            
            person.Age = 23;      //Выражение return person.Age; вызывает метод TryGetMember.
            Func<int, int> Incr = delegate (int x) { person.Age += x; return person.Age; }; //Также у объекта person определен метод IncrementAge,
                                                                                            //который представляет действия анонимного делегата delegate (int x) { person.Age+=x; return person.Age; }.
                                                                                            //Делегат принимает число x, увеличивает на это число свойство Age и возвращает новое значение person.Age.
                                                                                            //И при вызове этого метода будет происходить обращение к методу TryInvokeMember.
                                                                                            //И, таким образом, произойдет приращение значения свойства person.Age.
            person.IncrementAge = Incr;
            Console.WriteLine($"{person.Name} - {person.Age}"); // Tom - 23
            person.IncrementAge(4);
            Console.WriteLine($"{person.Name} - {person.Age}"); // Tom - 27

           // Console.Read();

            Console.WriteLine("введите число");
            int x = Int32.Parse(Console.ReadLine());
            ScriptEngine engine = Python.CreateEngine(); //Для создания движка, выполняющего скрипт, применяется класс ScriptEngine. 
            ScriptScope scope = engine.CreateScope();   //Объект ScriptScope позволяет взаимодействовать со скриптом
            engine.ExecuteFile("D://python//factorial.py",scope);
            dynamic function = scope.GetVariable("factorial");
            // вызываем функцию и получаем результат
            dynamic res = function(x);
            Console.WriteLine(res);
        }
    }
    class PersonObject : DynamicObject
    {
        Dictionary<string, object> members = new Dictionary<string, object>();

        // установка свойства
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            members[binder.Name] = value;
            return true;
        }
        // получение свойства
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (members.ContainsKey(binder.Name))
            {
                result = members[binder.Name];
                return true;
            }
            return false;
        }
        // вызов метода
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            dynamic method = members[binder.Name];
            result = method((int)args[0]);
            return result != null;
        }
    }
    class Person
    {
        public string Name { get; set; }
        public dynamic Age { get; set; }

        // выводим зарплату в зависимости от переданного формата
        public dynamic getSalary(dynamic value, string format)
        {
            if (format == "string")
            {
                return value + " рублей";
            }
            else if (format == "int")
            {
                return value;
            }
            else
            {
                return 0.0;
            }
        }

        public override string ToString()
        {
            return Name + ", " + Age.ToString();
        }
    }
}
