using System;

namespace Chapter6and7
{
    interface IAccount
    {
        int CurrentSum { get; }  // Текущая сумма на счету
        void Put(int sum);      // Положить деньги на счет
        void Withdraw(int sum); // Взять со счета
    }
    interface IClient
    {
        string Name { get; set; }
    }
    class Client : IAccount, IClient
    {
        int _sum; // Переменная для хранения суммы
        public string Name { get; set; }
        public Client(string name, int sum)
        {
            Name = name;
            _sum = sum;
        }

        public int CurrentSum { get { return _sum; } }

        public void Put(int sum) { _sum += sum; }

        public void Withdraw(int sum)
        {
            if (_sum >= sum)
            {
                _sum -= sum;
            }
        }
    }
    class Transaction<T>where T : IAccount, IClient
    {
        public void Operate(T acc1,T acc2,int sum)
        {
            if (acc1.CurrentSum >= sum)
            {
                    acc1.Withdraw(sum);
                    acc2.Put(sum);
                    Console.WriteLine($"{acc1.Name} : {acc1.CurrentSum}\n{acc2.Name} : {acc2.CurrentSum}");
                
            }
        }
    }
    class Bike:IMovable
    {
     
    }
    class Car : IMovable
    {
        private int maxSpeed = 0;
        public int MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                if (value > 0) maxSpeed = value;
            }
        }
        public void Move()
        {
            Console.WriteLine("Driving with speed" + MaxSpeed);
        }
    }
    interface IAction
    {
        void Move()
        {

        }
    }

    class BaseAction : IAction
    {
        public void Move()
        {
            Console.WriteLine("Moves with BaseSpeed");
        }
    }
    class HeroAction : BaseAction,IAction
    {
        void IAction.Move()
        {
            Console.WriteLine("Moves with HeroSpeed");
        }
    }

    interface IMable
    {
        protected internal void Move();
        protected internal string Name { get; set; }
        delegate void MoveHandler();
        protected internal event MoveHandler MoveEvent;
    }
    class Person : IMable
    {
        string IMable.Name { get; set; }
        // явная реализация события - дополнительно создается переменная
        IMable.MoveHandler _moveEvent;
        event IMable.MoveHandler IMable.MoveEvent
        {
            add => _moveEvent += value;
            remove => _moveEvent -= value;
        }
        // явная реализация метода
        void IMable.Move()
        {
            Console.WriteLine("Person is walking");
            _moveEvent();
        }
    }

    class RunAction : IRunAction
    {
        public void Move()
        {
            Console.WriteLine("I am running");
        }
    }

    interface Iction
    {
        void Move()
        {
            Console.WriteLine("move1");
        }
    }
    interface IRunAction : Iction
    {
        new void Move()
        {
            Console.WriteLine("move2");
        }
    }
    interface IClientAccount : IAccount, IClient
    {

    }
    class ClientAccount : IClientAccount
    {
        int _sum;
        public ClientAccount(string name, int sum)
        {
            _sum = sum; Name = name;
        }
        public int CurrentSum { get { return _sum; } }

        public string Name { get; set; }

        public void Put(int sum)
        {
            _sum += sum;
        }
        public void Withdraw(int sum)
        {
            if (_sum >= sum) _sum -= sum;
        }
    }
    interface IUser<T>
    {
        T Id { get; }
    }
    class User<T> : IUser<T>
    {
        T _id;
        public User(T id)
        {
            _id = id;
        }
        public T Id { get { return _id; } }
    }
    class IntUser : IUser<int>
    {
        int _id;
        public IntUser(int id)
        {
            _id = id;
        }
        public int Id { get { return _id; } }
    }
    class Company
    {
        public string Name { get; set; }
    }
     class Human : ICloneable,IComparable<Human>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Work { get; set; }
        public object Clone()
        {
            return new Human
            {
                Name = this.Name,
                Age = this.Age,
                Work = this.Work
            };
        }
        public int CompareTo(Human h)
        {
            return this.Age.CompareTo(h.Age);
        }
    }
    public static class HumanSallary
    {
        internal static int SallaryCount(this Human h)
        {
            int sallary = 0;
            if (h.Age < 21 && h.Work.Name == "Apple")
            {
                sallary = 3000;
            }
            if (h.Age >= 21 && h.Work.Name == "Apple")
            {
                sallary = 6000;
            }
            return sallary;
        }
    }
    class Employee
    {
        public virtual void Work()
        {
            Console.WriteLine("Да работаю я, работаю");
        }
    }

    class Manager : Employee
    {
        public override void Work()
        {
            Console.WriteLine("Отлично, работаем дальше");
        }
        public bool IsOnVacation { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IMovable b = new Bike();
           
            Car c = new Car() { MaxSpeed = 100 };
            Console.WriteLine(IMovable.MaxSpeed);
            IMovable.MaxSpeed = 80;
            Console.WriteLine(IMovable.MaxSpeed);
            Console.WriteLine(IMovable.GetTime(17.5,70));
            b.Move();
            c.Move();

            Client client = new Client("Tom", 200);
            client.Put(30);
            Console.WriteLine(client.CurrentSum); //230
            client.Withdraw(100);
            Console.WriteLine(client.CurrentSum); //130
            Console.Read();

            // Все объекты Client являются объектами IAccount 
            IAccount account = new Client("Том", 200);
            account.Put(200);
            Console.WriteLine(account.CurrentSum); // 400
            // Не все объекты IAccount являются объектами Client, необходимо явное приведение
            Client client1 = (Client)account;
            // Интерфейс IAccount не имеет свойства Name, необходимо явное приведение
            string clientName = ((Client)account).Name;
            HeroAction her = new HeroAction();
            her.Move(); //реализует BaseAction
            ((IAction)her).Move(); //реализует HeroAction


            IAction action2 = new HeroAction();  //реализует HeroAction
            action2.Move();

            IMable mable = new Person();
            // подписываемся на событие
            mable.MoveEvent += () => Console.WriteLine("IMovable is moving");
            mable.Move();

            RunAction run = new RunAction();
            ((Iction)run).Move();
            Console.Read();
            Client account1 = new Client("Tom", 200);
            Client account2 = new Client("Bob", 300);
            Transaction<Client> transaction = new Transaction<Client>();
            transaction.Operate(account1, account2, 150);
            IClientAccount acc3 = new ClientAccount("Jack", 400);
            IClientAccount acc4 = new ClientAccount("Vanessa", 350);
            Transaction<IClientAccount> transaction1 = new Transaction<IClientAccount>();
            transaction1.Operate(acc3, acc4, 25);

            IUser<int> user = new User<int>(333);
            IUser<string> user1 = new User<string>("3232");
            Console.WriteLine(user.Id);
            Console.WriteLine(user1.Id);
            IUser<int> user3 = new IntUser(3333);
            Console.WriteLine(user3.Id);
            Human h1 = new Human { Name = "Bill", Age = 21, Work=new Company {Name="Apple" } };
            Human h2 = (Human)h1.Clone();
            h2.Name = "Michael";
            Console.WriteLine($"Name:{h2.Name} Age:{h2.Age} WorkCompany:{h2.Work.Name}");
            Console.WriteLine($"Name:{h1.Name} Age:{h2.Age} WorkCompany:{h2.Work.Name}");
            Console.WriteLine($"/n");
            Human h3=new Human { Name = "Ben", Age = 25, Work = new Company { Name = "Apple" } };
            Human h4 = new Human { Name = "Rick", Age = 27, Work = new Company { Name = "Apple" } };
            Human[] humen = new Human[] { h1, h2, h3, h4 };
            Array.Sort(humen);
            foreach(Human h in humen)
            {
                Console.WriteLine($"Name:{h.Name} Age:{h.Age} WorkCompany:{h.Work.Name}");
            }
            Console.WriteLine(h3.SallaryCount());

            Plane p = new Plane();
            p.Move();
            var man = new { Name = "Lee", Age = 33, Work = new Company { Name = "Google" },car="Ford" };
            Console.WriteLine(man.Name);
            Console.WriteLine(man.car);
            var result = GetResult(new int[] { -3, -2, -1, 0, 1, 2, 3 });
            Console.WriteLine(result);  //6
            Console.Read();

            Employee emp = new Manager(); //Employee();
            UseEmployee(emp);

            Console.Read();
        }
        static int GetResult(int[] numbers)
        {
            int limit = 0;
            // локальная функция
            bool IsMoreThan(int number)
            {
                return number > limit;
            }

            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsMoreThan(numbers[i]))
                {
                    result += numbers[i];
                }
            }

            return result;
        }
        static void UseEmployee(Employee emp)
        {
            if (emp is Manager manager && manager.IsOnVacation == false)
            {
                manager.Work();
            }
            else
            {
                Console.WriteLine("Преобразование не допустимо");
            }
        }
        static void UseEmployee1(Employee emp)
        {
            switch (emp)
            {
                case Manager manager when manager.IsOnVacation == false:
                    manager.Work();
                    break;
                case null:
                    Console.WriteLine("Объект не задан");
                    break;
                default:
                    Console.WriteLine("Объект не менеджер");
                    break;
            }
        }
    }
}
