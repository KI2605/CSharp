using System;
using System.Threading.Tasks;

namespace Chapter20
{
    class Program
    {
        static void Main(string[] args)
        {
             Test();
            //класс,созданный в main будет жить до конца
            Person p = new Person() { Name = "Joe" };
           Task t=new Task(p.Dispose);
            t.Start();
            t.Wait();
            p = null;
            Console.WriteLine($"Name= {p.Name}");
           
            Console.ReadLine();

            unsafe
            {
                int* x; // определение указателя
                int y = 10; // определяем переменную

                x = &y; // указатель x теперь указывает на адрес переменной y
                int** z = &x; // указатель z теперь указывает на адрес, который указывает и указатель x
                **z = **z + 40; // изменение указателя z повлечет изменение переменной y
                Console.WriteLine(y); // переменная y=50
                Console.WriteLine(**z); // переменная **z=50
            }
            Console.WriteLine("---------------");
            unsafe
            {
                Person person = new Person();
                person.Age = 28;
                person.Height = 178;
                // блок фиксации указателя
                fixed (int* per = &person.Age)
                {
                    if (*per < 30)
                    {
                        *per = 30;
                    }
                }
                Console.WriteLine(person.Age); // 30
            }
        }

        private static void Test()
        {
            //using автоматически вызовет dispose в конце віполнения метода
            using Person tom = new Person { Name = "Tom" };
            using Person bob = new Person { Name = "Bob" };

            Console.WriteLine($"Person1: {tom.Name}    Person2: {bob.Name}");

            Console.WriteLine("Конец метода Test");
        }
    }
    public class Person : IDisposable
    {
        private bool disposed = false;
        public string Name { get; set; }
        public int Age;
        public int Height { get; set; }

        public void Dispose()
        {
            //Console.Beep();
            //Console.WriteLine("Disposed");

            Dispose(true);
            GC.SuppressFinalize(this);
            Console.WriteLine("Disposed");
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // this.Name = null;
                    // int i = GC.GetGeneration(this);
                    //// GC.Collect();
                    // GC.Collect(2, GCCollectionMode.Forced);
                    // Console.WriteLine(i);


                    // Освобождаем управляемые ресурсы
                }
                // освобождаем неуправляемые объекты
                disposed = true;
               
            }
          
        }
        ~Person()
        {
            Dispose(false);
        }
    }
}
