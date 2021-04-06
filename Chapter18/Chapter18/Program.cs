using System;
using System.Reflection;
//using ClassLibrary1;
namespace Chapter18
{
    class Program
    {
        static void Main(string[] args)
        {
            // Type myType = typeof(User);

            // Console.WriteLine(myType.ToString());
            // Console.WriteLine(myType.Namespace); 
            // Console.WriteLine(myType.Name);
            // Console.WriteLine(myType.FullName);
            // Console.ReadLine();

            // Console.WriteLine("-------------");

            //Type t = typeof(Container.Nested);
            // Console.WriteLine(t.Namespace); 
            // Console.WriteLine(t.Name); 
            // Console.WriteLine(t.FullName);

            // Console.WriteLine("-------------");

            // Type myT = Type.GetType("Chapter18.User", false, true);

            // foreach (MemberInfo mi in myT.GetMembers())
            // {
            //     Console.WriteLine($"{mi.DeclaringType} {mi.MemberType} {mi.Name}");
            // }
            // Console.WriteLine("------------------");
            // foreach(MethodInfo method in myT.GetMethods())
            // {
            //     string modificator = "";
            //     if (method.IsStatic)
            //     {
            //         modificator += "static";
            //     }
            //     if (method.IsPublic)
            //     {
            //         modificator += "public";
            //     }
            //     if (method.IsVirtual)
            //     {
            //         modificator+="virtual";
            //     }
            //     Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");
            //     ParameterInfo[] parameters = method.GetParameters();

            //     for (int i = 0; i < parameters.Length; i++)
            //     {
            //         Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
            //         if (i + 1 < parameters.Length) Console.Write(", ");
            //     }
            //     Console.WriteLine(")");
            // }
            // Console.ReadLine();
            // Console.WriteLine("Конструкторы:");
            // foreach (ConstructorInfo ctor in myT.GetConstructors())
            // {
            //     Console.Write(myT.Name + " (");
            //     // получаем параметры конструктора
            //     ParameterInfo[] parameters = ctor.GetParameters();
            //     for (int i = 0; i < parameters.Length; i++)
            //     {
            //         Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
            //         if (i + 1 < parameters.Length) Console.Write(", ");
            //     }
            //     Console.WriteLine(")");
            // }
            // Console.WriteLine("Поля:");
            // foreach (FieldInfo field in myT.GetFields())
            // {
            //     Console.WriteLine($"{field.FieldType} {field.Name}");
            // }

            // Console.WriteLine("Свойства:");
            // foreach (PropertyInfo prop in myT.GetProperties())
            // {
            //     Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            // }
            try
            {
                //получаем сборку
                Assembly asm = Assembly.LoadFrom("ClassLibrary1.dll");
                //получаем тип - класс Program
                Type type = asm.GetType("ClassLibrary1.Program", true, true);
                // создаем экземпляр класса Program
                object obj = Activator.CreateInstance(type);
                //получаем метод GetResult
                MethodInfo method = type.GetMethod("GetResult");
                // вызываем метод, передаем ему значения для параметров и получаем результат
                object result = method.Invoke(obj, new object[] { 6, 100, 2 });
                Console.WriteLine(result);
                Console.WriteLine("Вызов метода Main");
                method = type.GetMethod("Main", BindingFlags.DeclaredOnly
    | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
                object result1=method.Invoke(obj, new object[] { new string[] { } });
                Console.WriteLine(result1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            User tom = new User("Tom", 35);
            User bob = new User("Bob", 16);
            bool TomIsValid = ValidateUser(tom);
            bool BobIsValid = ValidateUser(bob);
            Console.WriteLine($"Реультат валидации Тома: {TomIsValid}");
            Console.WriteLine($"Реультат валидации Боба: {BobIsValid}");
            Console.ReadLine();
        }
        static bool ValidateUser(User user)
        {
            Type t1=typeof(User);
            object[] attrs = t1.GetCustomAttributes(false);
            foreach(AgeValidationAttribute attr in attrs)
            {
                if (user.Age >= attr.Age)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class Container
    {
       public  class Nested
        {
            Nested() { }
        }
    }
    public class AgeValidationAttribute : System.Attribute
    {
        public int Age { get; set; }

        public AgeValidationAttribute()
        { }

        public AgeValidationAttribute(int age)
        {
            Age = age;
        }
    }
    [AgeValidation(18)]
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public User(string n, int a)
        {
            Name = n;
            Age = a;
        }
        public void Display()
        {
            Console.WriteLine($"Имя: {Name}  Возраст: {Age}");
        }
        public int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }
    }
}
