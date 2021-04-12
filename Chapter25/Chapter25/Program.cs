using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Chapter25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();

            Console.WriteLine("Введите возраст");
            int age = Int32.Parse(Console.ReadLine());

            User user = new User { Name = name, Age = age };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            Console.WriteLine("---");
            Console.WriteLine("Input login");
            string login = Console.ReadLine();
            Console.WriteLine("Input password");
            string password = Console.ReadLine();
            Console.WriteLine("Confirm password");
            string confirmpassword = Console.ReadLine();
            RegisterModel register = new RegisterModel() { Login = login, Password = password, ConfirmPassword = confirmpassword };
           
            var results2 = new List<ValidationResult>();
            var context2 = new ValidationContext(register);
            if (!Validator.TryValidateObject(register, context2, results2, true))
            {
                foreach (var error in results2)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            User user2 = new User { Id = "d3io", Name = "Alice", Age = 33 };
            Validate(user2);

            Employee employee1 = new Employee { Name = "Tom Jackson", Age = 12, Position = Employee.Pos.Middle };
            Console.WriteLine("input your Name");
            string empname2 = Console.ReadLine();
            Console.WriteLine("Input your age");
            int empage2 = Int32.Parse(Console.ReadLine());
            Employee employee2 = new Employee { Name = empname2, Age = empage2};
            Console.WriteLine("Input your position, where: ");
            Console.WriteLine("1 - Trainee");
            Console.WriteLine("2 - Junior");
            Console.WriteLine("3 - Middle");
            Console.WriteLine("4 - Senior");
            int numPos = Int32.Parse(Console.ReadLine());
            while (numPos < 1 && numPos > 4)
            {
                Console.WriteLine("Input your position, where: ");
                Console.WriteLine("1 - Trainee");
                Console.WriteLine("2 - Junior");
                Console.WriteLine("3 - Middle");
                Console.WriteLine("4 - Senior");
                numPos = Int32.Parse(Console.ReadLine());
            }
                if (numPos == 1)
                {
                    employee2.Position = Employee.Pos.Trainee;
                }
                if (numPos == 2)
                {
                    employee2.Position = Employee.Pos.Junior;
                }
                if (numPos == 3)
                {
                    employee2.Position = Employee.Pos.Middle;
                }
                if (numPos == 1)
                {
                    employee2.Position = Employee.Pos.Senior;
                }
            
            var results3 = new List<ValidationResult>();
            var context3 = new ValidationContext(employee1);
            if (!Validator.TryValidateObject(employee1, context3, results3, true))
            {
                foreach (var error in results3)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("Пользователь прошел валидацию");
            }
            var results4 = new List<ValidationResult>();
            var context4 = new ValidationContext(employee2);
            //employee2.Validate(context4);
            if (!Validator.TryValidateObject(employee2, context4, results4, true))
            {
                foreach (var error in results4)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("Пользователь прошел валидацию");
            }
        }
        private static void Validate(User user)
        {
            var results = new List<ValidationResult>();

            //создаем контекст валидации - объект ValidationContext
            var context = new ValidationContext(user);
            //валидацию производит класс Validator и его метод TryValidateObject().
            //В этот метод передается валидируемый объект(в данном случае объект user),
            //контекст валидации, список объектов ValidationResult и булевый параметр, указывающий,
            //надо ли валидировать все свойства.
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            else
                Console.WriteLine("Пользователь прошел валидацию");
        }
    }
    [PersonAtribute]
    public class User
    {
        [Required(ErrorMessage = "Идентификатор пользователя не установлен", AllowEmptyStrings =true)]
        public string Id { get; set; }
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина имени")]
        public string Name { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
    }
    public class PersonAtribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            User user = value as User;
            if (user.Name == "Alice" && user.Age == 33)
            {
                this.ErrorMessage = "Имя не должно быть Alice и возраст одновременно не должен быть равен 33";
                return false;
            }
            return true;
        }
    }
     public class Employee : IValidatableObject
    {
       public  enum Pos
        {
            Trainee,
            Junior,
            Middle,
            Senior
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public Pos Position { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                errors.Add(new ValidationResult("Не указано имя"));
            }
            if (this.Age < 18 && this.Age > 100)
            {
                errors.Add(new ValidationResult("Недопустимый возраст"));
            }
            if (this.Age > 18 && this.Age < 21 && Position == Pos.Senior)
            {
                errors.Add(new ValidationResult("Too young for this position"));
            }
            return errors;
        }
    }
    public class RegisterModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
